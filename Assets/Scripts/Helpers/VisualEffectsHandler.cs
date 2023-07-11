using UnityEngine;

namespace Helpers
{
    public class VisualEffectsHandler : MonoBehaviour
    {
        [SerializeField] private GameObject defaultBorder;
        [SerializeField] private GameObject effectObject;
        [SerializeField] private GameObject hoverObject;

        public void TurnOnGlow()
        {
            defaultBorder.SetActive(false);
            effectObject.SetActive(true);
            hoverObject.SetActive(false);
        }

        public void TurnOffGlow()
        {
            defaultBorder.SetActive(true);
            effectObject.SetActive(false);
        }

        public void ShowHoverObject(bool show)
        {
            hoverObject.SetActive(show);
        }
    }
}