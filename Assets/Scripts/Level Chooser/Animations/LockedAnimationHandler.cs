using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Level_Chooser.Animations
{
    public class LockedAnimationHandler : IAnimationHandler
    {
        private readonly Color _hoverColor;
        private readonly Image _imageToGrow;
        private readonly Image _borderImage;
        
        private readonly float _animationDuration;
        private readonly Color _initialColor;
        private static readonly int color = Shader.PropertyToID("_Color");

        public LockedAnimationHandler(Material lockedMaterial, Color hoverColor,
            Image imageToGrow, Image borderImage, float animationDuration)
        {
            _hoverColor = hoverColor;
            _imageToGrow = imageToGrow;
            _borderImage = borderImage;
            _borderImage.material = lockedMaterial;
            _initialColor = lockedMaterial.GetColor(color);
            _animationDuration = animationDuration;
        }

        public void PlayEnterAnimation()
        {
            _imageToGrow.transform.DOScale(new Vector3(1.25f, 1.25f, 1.25f), _animationDuration).SetEase(Ease.InBack);
            _borderImage.material.SetColor(color, _hoverColor);
        }

        public void PlayExitAnimation()
        {
            _imageToGrow.transform.DOScale(Vector3.one, _animationDuration).SetEase(Ease.OutBounce);
            _borderImage.material.SetColor(color, _initialColor);
        }
    }
}