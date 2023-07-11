using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Helpers
{
    public class StupidOnMouseOverGlow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private Material glowMaterial;
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            GetComponent<Image>().material = glowMaterial;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            GetComponent<Image>().material = null;
        }
    }
}