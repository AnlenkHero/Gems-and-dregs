using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

// ReSharper disable CompareOfFloatsByEqualityOperator

namespace Gameplay
{
    public class FlipButton : MonoBehaviour
    {
        [Serializable]
        public class ButtonClickEvent : UnityEvent<bool, int> { }
    
        public ButtonClickEvent onButtonFlipped;

        public int Id { get; set; }

        [SerializeField]
        private MoveAndFadeBehaviour _animation;
    
        [SerializeField]
        private Sprite backgroundSprite;
        
        [SerializeField]
        private Sprite baseForegroundSprite;
           
        [FormerlySerializedAs("foregroundObject")]
        [SerializeField]
        private Image foregroundImage;
        
        public Sprite ForegroundSprite { get; private set; }
        
        public bool IsGem { get; private set; }
    
        private const float FLIP_WAIT_TIME = 0.015f;
        private const float REVERSE_FLIP_TIME = 0.5f;
    
        
        private Button _button;
        private static readonly int fade = Shader.PropertyToID("_Fade");

        void Awake()
        {
            _button = GetComponent<Button>();
            if (_button == null)
            {
                Debug.LogError("FlipButtonBehaviour: Button component is missing. Please attach this script to a GameObject with a Button component.");
                return;
            }
            _button.image.sprite = backgroundSprite;
        
        }

        public void PlayAnimation()
        {
            _button.interactable = false;
            _animation.PlayAnimation();
            _button.interactable = true;
        }

        public void SetGemSprite(Sprite gemSprite)
        {
            ForegroundSprite = gemSprite;
            IsGem = true;
        }

        public void SetDregSprite(Sprite dregSprite)
        {
            ForegroundSprite = dregSprite;
            IsGem = false;
        }
        
        public void OnButtonClicked()
        {
            StartCoroutine(FlipCard());
        }

        public IEnumerator FadeAndDestroy()
        {
            Material material = _button.image.material;
            for (float i = 0.97f; i >= 0f; i -= 0.03f)
            {
                material.SetFloat(fade, i);
                yield return new WaitForSeconds(.01f);
            }
            Destroy(gameObject);
        }
    
        public IEnumerator FlipCard()
        {
            var facedUp = _button.image.sprite != backgroundSprite;
            _button.interactable = facedUp;
        
            if (!facedUp)
            {
                yield return FlipForward();
                onButtonFlipped?.Invoke(IsGem, Id);
                yield break;
            }
        
            yield return FlipBackward();
        }

        private IEnumerator FlipBackward()
        {
            for (float i = 180f; i >= 0f; i -= 10f)
            {
                _button.transform.rotation = Quaternion.Euler(0, i, 0);
                if (i == 90f)
                {
                    _button.image.sprite = backgroundSprite;
                    foregroundImage.gameObject.SetActive(false);
                }

                yield return new WaitForSeconds(FLIP_WAIT_TIME);
            }    
        }

        private IEnumerator FlipForward()
        {
            for (var i = 0f; i <= 180f; i += 10f)
            {
                _button.transform.rotation = Quaternion.Euler(0, i, 0);
                if (i == 90f)
                {
                    _button.image.sprite = baseForegroundSprite;
                    foregroundImage.gameObject.SetActive(true);
                    foregroundImage.sprite = ForegroundSprite;
                }

                yield return new WaitForSeconds(FLIP_WAIT_TIME);
            }
        }
    }
}