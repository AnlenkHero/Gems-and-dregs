using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Global;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public partial class GameController : MonoBehaviour
    {
        private const int AMOUNT_OF_GEMS_TO_WIN = 2;
        private List<FlipButton> _gameButtons = new();
        private readonly List<FlipButton> _selectedButtons = new();

        [SerializeField]
        private GameObject CompletedObject;

        private void Awake()
        {
            SetUp();
            foreach (var gameButton in _gameButtons)
            {
                gameButton.onButtonFlipped.AddListener(ButtonEventHandler);
            }
        }

        private void ButtonEventHandler(bool isGem, int id)
        {
            AddSelectedButton(id);

            if (_selectedButtons.Count == AMOUNT_OF_GEMS_TO_WIN)
            {
                foreach (var button in _selectedButtons)
                {
                    StartCoroutine(button.FlipCard());
                }

                var gemsSelected = _selectedButtons.Where(button => button.IsGem).ToArray();
                switch (gemsSelected.Length)
                {
                    case 2:
                        HandleWinCondition();
                        break;
                    case 1:
                        HandleOneGemSelected(gemsSelected.First());
                        break;
                }

                _selectedButtons.RemoveAll(x => x);
            }
        }

        private void HandleWinCondition()
        {
            gameState.selectedGem.CompleteLevel();
            StartCoroutine(WaitForAllButtons());

            if (gameState.selectedLevel != gameState.selectedGem.LevelsToUnlock)
                nextLevelButton.gameObject.SetActive(true);
        }

        private IEnumerator WaitForAllButtons()
        {
            List<Coroutine> coroutines = new List<Coroutine>();

            foreach (var gameButton in _gameButtons)
            {
                coroutines.Add(StartCoroutine(gameButton.FadeAndDestroy()));
            }

            foreach (Coroutine coroutine in coroutines)
            {
                yield return coroutine;
            }

            CompletedObject.SetActive(true);
        }

        private void AddSelectedButton(int id)
        {
            if (!_selectedButtons.Any(x => x.Id == id))
                _selectedButtons.Add(_gameButtons[id]);
        }

        private void HandleOneGemSelected(FlipButton selectedGemButton)
        {
            var randomDregButton = SwapGemWithRandomDreg(selectedGemButton);

            randomDregButton.PlayAnimation();
            selectedGemButton.PlayAnimation();
        }

        private FlipButton SwapGemWithRandomDreg(FlipButton selectedGemButton)
        {
            var randomDregButton = GetRandomNotSelectedDregButton(selectedGemButton);
            var dregSprite = randomDregButton.ForegroundSprite;

            randomDregButton.SetGemSprite(selectedGemButton.ForegroundSprite);
            selectedGemButton.SetDregSprite(dregSprite);
            return randomDregButton;
        }

        private FlipButton GetRandomNotSelectedDregButton(FlipButton selectedGemButton)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, _gameButtons.Count);
            } while (randomIndex == selectedGemButton.Id || _gameButtons[randomIndex].IsGem);

            var randomButton = _gameButtons[randomIndex];
            return randomButton;
        }

        private void GoToNextLevel()
        {
            gameState.selectedLevel++;
            SceneController.Instance.LoadScene(GameScene.MemoryGameplay);
        }
    }
}