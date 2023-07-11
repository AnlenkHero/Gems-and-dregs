using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Helpers
{
    public class StupidOnMouseOverToggle : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {


        public void OnPointerEnter(PointerEventData eventData)
        {
            GetComponent<Image>().color = Color.white;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            GetComponent<Image>().color = Color.gray;
        }

    }
}
