using System;
using Global;
using UnityEngine;
using UnityEngine.UI;

namespace Helpers
{
    public class BackButton : MonoBehaviour
    {
        private void Awake()
        {
            var button = GetComponent<Button>();
            
            if (button == null)
                throw new InvalidOperationException("This script should be attached to button");
            
            button.onClick.AddListener(SwitchSceneToPrevious);
        }
        
        private void SwitchSceneToPrevious()
        {
            SceneController.Instance.LoadPreviousScene();
        }
    }
}