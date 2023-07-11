using UnityEngine;
using UnityEngine.EventSystems;

namespace Main_Menu
{
    public class MainMenuButtonsEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
