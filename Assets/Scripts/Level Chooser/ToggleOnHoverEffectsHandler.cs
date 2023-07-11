using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Level_Chooser
{
    public class ToggleOnHoverEffectsHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject defaultBorder;
        [SerializeField] private GameObject effectObject;
        [SerializeField] private GameObject hoverObject;
        [SerializeField] private Toggle toggle;

        
        private void Awake()
        {
            toggle.onValueChanged.AddListener(HandleToggled);
        }

        private void HandleToggled(bool isOn)
        {
            if (isOn)
            {
                TurnOnGlow();
                return;
            }

            TurnOffGlow();
        }

        private void TurnOnGlow()
        {
            defaultBorder.SetActive(false);
            effectObject.SetActive(true);
            hoverObject.SetActive(false);
        }

        private void TurnOffGlow()
        {
            defaultBorder.SetActive(true);
            effectObject.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!toggle.isOn)
                hoverObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!toggle.isOn)
                hoverObject.SetActive(false);
        }
    }
}