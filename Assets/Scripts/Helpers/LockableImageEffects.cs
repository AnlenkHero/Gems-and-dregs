using System;
using Level_Chooser.Animations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Helpers
{
    public class LockableImageEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Image _borderImage;
        private Image _imageToGrow;
        private Color _hoverColor;
        private float _unlockedAnimationDuration = 0.2f;
        private float _lockedAnimationDuration = 0.25f;
        private bool _initialized;
        
        private IAnimationHandler _animationHandler;

        public void Initialize(Image borderImage, Image imageToGrow, Color hoverColor, float unlockedScaleDuration,
            float lockedScaleDuration)
        {
            _imageToGrow = imageToGrow;
            _borderImage = borderImage;
            _hoverColor = hoverColor;
            _unlockedAnimationDuration = unlockedScaleDuration;
            _lockedAnimationDuration = lockedScaleDuration;
            _initialized = true;
        }

        public void SetUnlocked(bool unlocked, Material lockedMaterial)
        {
            if (!_initialized)
                throw new InvalidOperationException("You must initialize script first!");
            
            if (unlocked)
            {
                _animationHandler =
                    new UnlockedAnimationHandler(_hoverColor, _imageToGrow, _borderImage, _unlockedAnimationDuration);
            }
            else
            {
                var lockedMaterialCopy = Instantiate(lockedMaterial);
                _animationHandler = new LockedAnimationHandler(lockedMaterialCopy, _hoverColor, _imageToGrow,
                    _borderImage,
                    _lockedAnimationDuration);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _animationHandler?.PlayEnterAnimation();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _animationHandler?.PlayExitAnimation();
        }
    }
}