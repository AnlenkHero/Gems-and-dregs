using System.Collections.Generic;
using System.Linq;
using Exceptions;
using JetBrains.Annotations;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "Gem", menuName = "ScriptableObjects/Gem", order = 1)]
    public class Gem : ScriptableObject
    {
        public string gemName;
        public string gemDescription;
        
        [SerializeField]
        private List<Sprite> gemSprites;

        [Tooltip("The order here matters. Previews will be displayed in the same order as you put it in the inspector")]
        [SerializeField]
        private List<Sprite> previewSprites;

        [SerializeField]
        private int levelsToUnlock = 3;

        public int LevelsToUnlock => levelsToUnlock;

        private int _levelsCompleted;
        public bool IsGemUnlocked => _levelsCompleted >= levelsToUnlock;

        public Sprite GetGemSpriteByLevel(int level)
        {
            return gemSprites[level-1];
        }
        
        public void CompleteLevel()
        {
            if (!IsGemUnlocked)
            {
                _levelsCompleted++;
                SaveProgress();
            }
        }

        public bool IsLevelUnlocked(int level)
        {
            return _levelsCompleted + 1 >= level;
        }

        ///<param name="level">Level number. Must be > 0</param>///
        [CanBeNull]
        public Sprite GetPreviewByLevel(int level)
        {
            if (level < 1 || level > previewSprites.Count)
                return null;

            return previewSprites[level - 1];
        }

        private void OnValidate()
        {
            List<string> errorMessages = PerformValidation();

            if (!errorMessages.Any()) return;

            string combinedErrorMessage = string.Join("\n", errorMessages);
            throw new ValidationException($"Validation failed with the following errors: \n{combinedErrorMessage}");
        }

        private List<string> PerformValidation()
        {
            List<string> errorMessages = new List<string>();

            if (!IsPreviewCountValid())
            {
                errorMessages.Add(
                    $"The count of previewSprites ({previewSprites.Count}) does not match the expected count of levelsToUnlock ({levelsToUnlock}).");
            }

            var nullPreviewsCount = GetNullPreviewsCount();
            if (nullPreviewsCount > 0)
            {
                errorMessages.Add($"There are {nullPreviewsCount} null preview(s) in previewSprites.");
            }

            return errorMessages;
        }


        private bool IsPreviewCountValid()
        {
            return previewSprites.Count == levelsToUnlock;
        }

        private int GetNullPreviewsCount()
        {
            return previewSprites.Count(sprite => sprite == null);
        }

        private string GetPlayerPrefsKey()
        {
            return $"Gem_{gemName}_LevelsCompleted";
        }

        private void LoadProgress()
        {
            _levelsCompleted = PlayerPrefs.GetInt(GetPlayerPrefsKey(), 0);
        }

        private void SaveProgress()
        {
            PlayerPrefs.SetInt(GetPlayerPrefsKey(), _levelsCompleted);
            PlayerPrefs.Save();
        }

        private void OnEnable()
        {
            LoadProgress();
        }
    }
}