namespace Helpers
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class ButtonVisualEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Button button;
        [SerializeField] private VisualEffectsHandler effectsHandler;

        private void Awake()
        {
            button.onClick.AddListener(effectsHandler.TurnOnGlow);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            effectsHandler.ShowHoverObject(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            effectsHandler.ShowHoverObject(false);
        }
    }
}