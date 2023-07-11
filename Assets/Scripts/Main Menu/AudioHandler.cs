using UnityEngine;

namespace Main_Menu
{
    public class AudioHandler : MonoBehaviour
    {
        public static AudioHandler instance;
        
        public AudioSource musicAudioSource;

        public AudioSource audioEffectSource;
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}