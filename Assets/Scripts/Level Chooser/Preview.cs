using System;
using Core;
using Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Level_Chooser
{
    public class Preview : MonoBehaviour
    {
        [SerializeField] private Image previewImage;
        [SerializeField] private Image borderImage;
        [SerializeField] private GameObject previewPrefab;
        [SerializeField] private Button button;
        [SerializeField] private Material lockedMaterial;
        [SerializeField] private Color hoverColor;
        [SerializeField] private float unlockedScaleDuration = 0.2f;
        [SerializeField] private float lockedScaleDuration = 0.25f;

        private int _levelNum;
        private LockableImageEffects _mouseGrowEffect;

        public event EventHandler<int> OnButtonPressed;

        public Preview Initialize(Transform parent, Gem gem, int levelNum)
        {
            var instantiatedObject = Instantiate(previewPrefab, parent);
            var instantiatedPreview = instantiatedObject.GetComponent<Preview>();

            instantiatedPreview._levelNum = levelNum;
            
            instantiatedPreview.SetUp(gem);

            return instantiatedPreview;
        }

        private void SetUp(Gem gem)
        {
           SetPreviewSprite(gem); 
           SetupMouseGrowEffect();
           SetUnlocked(gem.IsLevelUnlocked(_levelNum));
           AddListenerToButton();
        }
        
        private void SetPreviewSprite(Gem gem)
        {
            previewImage.sprite = gem.GetPreviewByLevel(_levelNum);
        }

        private void SetupMouseGrowEffect()
        {
            _mouseGrowEffect = gameObject.AddComponent<LockableImageEffects>();
            _mouseGrowEffect.Initialize(borderImage,previewImage, hoverColor,
                unlockedScaleDuration, lockedScaleDuration);
        }

        private void SetUnlocked(bool unlocked)
        {
            _mouseGrowEffect.SetUnlocked(unlocked, lockedMaterial);

            if (!unlocked)
            {
                var unlockedMaterial = Instantiate(lockedMaterial);
                previewImage.material = unlockedMaterial;
                button.interactable = false;
            }
        }

        private void AddListenerToButton()
        {
            button.onClick.AddListener(() => OnButtonPressed?.Invoke(this, _levelNum));
        }
    }
}