using Coffee.UIEffects;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Level_Chooser.Animations
{
    public class UnlockedAnimationHandler : IAnimationHandler
    {
        private readonly Color _initialColor;
        private readonly Color _hoverColor;
        private readonly Image _imageToGrow;
        private readonly Image _borderImage;
        private readonly float _animationDuration;
        
        private readonly UIShiny _uiShiny;
        
        public UnlockedAnimationHandler(Color hoverColor, Image imageToGrow, Image borderImage, float duration)
        {
            _hoverColor = hoverColor;
            _imageToGrow = imageToGrow;
            _borderImage = borderImage;
            _initialColor = _borderImage.color;
            _uiShiny = _imageToGrow.transform.gameObject.AddComponent<UIShiny>();
            _animationDuration = duration;
        }

        public void PlayEnterAnimation()
        {
            _imageToGrow.transform.DOScale(new Vector3(1.25f, 1.25f, 1.25f), _animationDuration)
                .SetEase(Ease.InQuart);
            
            _borderImage.color = _hoverColor;

            _uiShiny.effectPlayer.loop = true;
            _uiShiny.Play();
        }

        public void PlayExitAnimation()
        {
            _imageToGrow.transform.DOScale(Vector3.one, _animationDuration).SetEase(Ease.OutCirc);
            _uiShiny.Stop();
            _borderImage.color = _initialColor;
        }
    }
}