using Global;
using Helpers;
using UnityEngine;

namespace Main_Menu
{
    public class MainMenuController : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneController.Instance.LoadScene(GameScene.LevelChooser);
        }

        public void LoadSettings()
        {
            SceneController.Instance.LoadScene(GameScene.SettingsMenu);
        }

        public void QuitGame()
        {
            TransitionController.instance.Transition(0, Application.Quit);
        }
    }
}