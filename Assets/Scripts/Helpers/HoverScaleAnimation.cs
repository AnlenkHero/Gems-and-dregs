using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Helpers
{
    public class HoverScaleAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Vector3 _initialScale;
        private Tweener _tween;
    
        [SerializeField] float scaleMultiplier = 1.2f;
        [SerializeField] float animationDuration = 0.2f;

        void Start()
        {
            _initialScale = transform.localScale;
        }
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_tween != null) _tween.Kill();
            _tween = transform.DOScale(new Vector3(scaleMultiplier, scaleMultiplier, _initialScale.z), animationDuration)
                .SetEase(Ease.OutQuad);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_tween != null) _tween.Kill();
            _tween = transform.DOScale(_initialScale, animationDuration)
                .SetEase(Ease.OutQuad);
        }
    }
}