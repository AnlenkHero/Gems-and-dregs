using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public partial class GameController
    {
        [SerializeField]
        private GridLayoutGroup puzzleField;

        [SerializeField]
        private GameObject buttonPrefab;

        [SerializeField]
        private GameState gameState;

        [SerializeField]
        private Button nextLevelButton;
        
        private Sprite _gemSprite;
        private Sprite[] _dregSprites;
        private int _buttonCount;
        private int _columnCount;
        
        private void SetUp()
        {
            SetGridOptions();
            AddGameButtons();
            
            _gemSprite = gameState.selectedGem.GetGemSpriteByLevel(gameState.selectedLevel);
            
            _dregSprites = Resources.LoadAll<Sprite>("Sprites/Dregs/");
            SetGemsAndDregsRandomly();
            
            nextLevelButton.onClick.AddListener(GoToNextLevel);
            nextLevelButton.gameObject.SetActive(false);
        }
        
        private void SetGridOptions()
        {
            CalculateGridOptions();
            puzzleField.constraintCount = _columnCount;

            var fieldRectTransform = puzzleField.GetComponent<RectTransform>().rect;
            var cellWidth = fieldRectTransform.width / _columnCount - puzzleField.spacing.x;
            var cellHeight = fieldRectTransform.height / (_buttonCount / _columnCount) - puzzleField.spacing.y;
            var squareSide = (cellWidth + cellHeight) / 2;
            
            puzzleField.cellSize = new Vector2(squareSide, squareSide);
            
        }
        
        private void CalculateGridOptions()
        {
            switch (gameState.selectedLevel)
            {
                case 1:
                    _buttonCount = 10;
                    _columnCount = 5;
                    break;
                case 2:
                    _buttonCount = 21;
                    _columnCount = 7;
                    break;
                case  3:
                    _buttonCount = 32;
                    _columnCount = 8;
                    break;
            }  
        }

        private void AddGameButtons()
        {
            for (int i = 0; i < _buttonCount; i++)
            {
                AddGameButton(i);
            }
        }

        private void AddGameButton(int buttonNum)
        {
            var currBtn = InstantiateGameButton(buttonNum);
            AddFlipButtonToList(currBtn);
        }

        private Button InstantiateGameButton(int buttonNum)
        {
            var button = Instantiate(buttonPrefab, puzzleField.transform ).GetComponent<Button>();
            button.image.material = Instantiate(button.image.material);
            button.name = buttonNum.ToString();
            return button;
        }

        private void AddFlipButtonToList(Button currBtn)
        {
            var flipButton = currBtn.GetComponent<FlipButton>();
            _gameButtons.Add(flipButton);
        }

        private void SetGemsAndDregsRandomly()
        {
            ShuffleGameButtons();
            SetGemsAndDregs();
        }

        private void ShuffleGameButtons()
        {
            for (int i = _gameButtons.Count - 1; i > 0; i--)
            {
                int randomIndex = Random.Range(0, i + 1);
                (_gameButtons[i], _gameButtons[randomIndex]) = (_gameButtons[randomIndex], _gameButtons[i]);
            }
        }

        private void SetGemsAndDregs()
        {
            for (int i = 0; i < _gameButtons.Count; i++)
            {
                _gameButtons[i].Id = i;

                if (i < 2)
                {
                    _gameButtons[i].SetGemSprite(_gemSprite);
                    continue;
                }

                var randomDregSpriteIndex = Random.Range(0, _dregSprites.Length);
                _gameButtons[i].SetDregSprite(_dregSprites[randomDregSpriteIndex]);
            }
        }
    }
}