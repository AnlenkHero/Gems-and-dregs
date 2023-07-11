using UnityEngine;

namespace Helpers
{
    public class TextScrolling : MonoBehaviour
    {
        public float scrollSpeed = 30.0f;
    
        private RectTransform _textRectTransform;
        private float _textWidth;
        private float canvasHeight;
        private Vector2 _initialPos;

        void Start()
        {
            _textRectTransform = GetComponent<RectTransform>();
            _textWidth = _textRectTransform.rect.width;
            canvasHeight = GetComponentInParent<Canvas>().pixelRect.height;
            _initialPos = _textRectTransform.anchoredPosition;
        }

        void Update()
        {
            _textRectTransform.anchoredPosition -= new Vector2(0.0f, scrollSpeed * Time.deltaTime);

            if (_textRectTransform.anchoredPosition.y <= - _textWidth)
            {
                _textRectTransform.anchoredPosition = _initialPos;
            }
        }
    }
}
