namespace Helpers
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class ToggleVisualEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Toggle toggle;
        [SerializeField] private VisualEffectsHandler effectsHandler;

        private void Awake()
        {
            toggle.onValueChanged.AddListener(HandleToggled);
        }

        private void HandleToggled(bool isOn)
        {
            if (isOn)
            {
                effectsHandler.TurnOnGlow();
            }
            else
            {
                effectsHandler.TurnOffGlow();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!toggle.isOn)
                effectsHandler.ShowHoverObject(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!toggle.isOn)
                effectsHandler.ShowHoverObject(false);
        }
    }
}