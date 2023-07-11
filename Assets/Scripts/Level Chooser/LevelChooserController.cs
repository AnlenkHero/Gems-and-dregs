using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Global;
using Helpers;
using UnityEngine;
using UnityEngine.UI;


namespace Level_Chooser
{
    public class LevelChooserController : MonoBehaviour
    {
        [SerializeField]
        private ToggleGroup gemToggleGroup;

        [SerializeField]
        private Transform previewParent;

        [SerializeField]
        private Preview previewPrefab;

        [Tooltip("This toggle will be on by default user haven't previously selected any")]
        [SerializeField]
        private GemToggle defaultToggle;

        [SerializeField]
        private GameState gameState;

        private Gem _selectedGem;

        private void Start()
        {
            var gemToggles = gemToggleGroup.GetComponentsInChildren<GemToggle>();
            TurnOnAppropriateToggle(gemToggles);
            SubscribeToToggleEvents(gemToggles);
        }

        private void TurnOnAppropriateToggle(IEnumerable<GemToggle> gemToggles)
        {
            var gemNameFromPlayerPrefs = GetAppropriateToggleName();
            TurnOnGemToggle(gemNameFromPlayerPrefs, gemToggles);
        }

        private string GetAppropriateToggleName()
        {
            var gemNameFromPlayerPrefs = PlayerPrefs.GetString(PlayerPrefsKeys.SELECTED_GEM);

            if (string.IsNullOrEmpty(gemNameFromPlayerPrefs))
                gemNameFromPlayerPrefs = defaultToggle.Gem.gemName;
            return gemNameFromPlayerPrefs;
        }

        private void TurnOnGemToggle(string gemName, IEnumerable<GemToggle> gemToggles)
        {
            var toggle = gemToggles.SingleOrDefault(t => t.Gem.gemName == gemName);

            if (toggle == null)
                throw new InvalidOperationException($"There weren't any toggles found with gem name: {gemName}");

            toggle!.IsOn = true;
            _selectedGem = toggle.Gem;
            ChangePreviews();
        }

        private void SubscribeToToggleEvents(IEnumerable<GemToggle> gemToggles)
        {
            foreach (var gemToggle in gemToggles)
            {
                if (gemToggle != null)
                    gemToggle.OnToggledOn += HandleSeasonToggledOn;
            }
        }

        private void HandleSeasonToggledOn(object sender, Gem gem)
        {
            _selectedGem = gem;
            ChangePreviews();
            SaveSelectedGem();
        }

        private void ChangePreviews()
        {
            RemoveAllPreviews();
            AddNewPreviews();
        }

        private void AddNewPreviews()
        {
            for (int levelNum = 1; levelNum <= _selectedGem.LevelsToUnlock; levelNum++)
            {
                var preview = previewPrefab.Initialize(previewParent, _selectedGem, levelNum);
                preview.OnButtonPressed += HandlePreviewSelected;
            }
        }

        private void RemoveAllPreviews()
        {
            while (previewParent.childCount > 0)
            {
                var child = previewParent.GetChild(0);
                child.SetParent(null);
                Destroy(child.gameObject);
            }
        }

        private void SaveSelectedGem()
        {
            PlayerPrefs.SetString(PlayerPrefsKeys.SELECTED_GEM, _selectedGem.gemName);
        }

        private void HandlePreviewSelected(object sender, int level)
        {
            gameState.selectedLevel = level;
            gameState.selectedGem = _selectedGem;
            SceneController.Instance.LoadScene(GameScene.MemoryGameplay);
        }
    }
}