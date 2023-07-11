using System;
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Level_Chooser
{
    public class GemToggle : MonoBehaviour
    {
        [SerializeField] 
        private Gem gem;

        [SerializeField]
        private Toggle toggle;
        
        public bool IsOn { get => toggle.isOn; set => toggle.isOn = value; }
        
        public Gem Gem => gem;
        
        public event EventHandler<Gem> OnToggledOn;
        
        private void Awake()
        {
            toggle.onValueChanged.AddListener(RaiseEvent);
        }

        private void RaiseEvent(bool isToggledOn)
        {
            if(isToggledOn)
                OnToggledOn?.Invoke(this,gem);     
        }
    }
}
