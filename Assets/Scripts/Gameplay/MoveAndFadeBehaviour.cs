using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class MoveAndFadeBehaviour : MonoBehaviour
    {
        [SerializeField] private float moveDuration = 1f;
        [SerializeField] private float moveDistance = 100f;
        [SerializeField] private Ease moveEase = Ease.InExpo;

        [SerializeField] private float fadeDuration = 1f;
        [SerializeField] private Ease fadeEase = Ease.InExpo;

        private Image spriteRenderer;
        private Vector3 initialPosition;
        private float initialAlpha;

        private void Start()
        {
            spriteRenderer = GetComponent<Image>();
            initialAlpha = spriteRenderer.color.a;

        }

        public void PlayAnimation()
        {
            initialPosition = transform.localPosition;
            MoveAndFadeOut()
                .OnComplete(() => MoveAndFadeIn());
        }
    
        private Sequence MoveAndFadeOut()
        {
            Sequence moveAndFadeOutSequence = DOTween.Sequence();

            // Move the object up
            moveAndFadeOutSequence.Append(transform.DOLocalMoveY(initialPosition.y + moveDistance, moveDuration)
                .SetEase(moveEase));

            // Fade out the object
            moveAndFadeOutSequence.Join(spriteRenderer.DOFade(0, fadeDuration)
                .SetEase(fadeEase));

            return moveAndFadeOutSequence;
        }

        private Sequence MoveAndFadeIn()
        {
            Sequence moveAndFadeInSequence = DOTween.Sequence();

            // Move the object back to the initial local position
            moveAndFadeInSequence.Append(transform.DOLocalMoveY(initialPosition.y, moveDuration)
                .SetEase(moveEase));

            // Fade the object back in
            moveAndFadeInSequence.Join(spriteRenderer.DOFade(initialAlpha, fadeDuration)
                .SetEase(fadeEase));

            return moveAndFadeInSequence;
        }
    }
}