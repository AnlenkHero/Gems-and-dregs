using System;
using Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global
{
    public class SceneController : MonoBehaviour
    {
        public static SceneController Instance;

        private string _previousScene;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public void LoadScene(GameScene scene, LoadSceneMode mode = LoadSceneMode.Single)
        {
            LoadScene(scene.ToString(),mode);
        }

        private void LoadScene(string sceneToChangeTo, LoadSceneMode mode = LoadSceneMode.Single)
        {
            var currentScene = SceneManager.GetActiveScene().name;            
            if(currentScene != sceneToChangeTo)
                _previousScene = currentScene;
            
            TransitionController.instance.Transition(0, () => SceneManager.LoadScene(sceneToChangeTo,mode));
        }
        
        public void LoadPreviousScene()
        {
            if(Enum.TryParse(SceneManager.GetActiveScene().name, out GameScene currentScene))
            {
                switch (currentScene)
                {
                    case GameScene.LevelChooser:
                        LoadScene(GameScene.MainMenu);
                        break;
                    case GameScene.SettingsMenu:
                        LoadScene(_previousScene);
                        break;
                    case GameScene.MemoryGameplay:
                        LoadScene(GameScene.LevelChooser);
                        break;
                }
            }
        }
    }
}
