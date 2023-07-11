using UnityEngine;
using UnityEngine.Audio;

namespace Main_Menu.SettingsSetUp
{
    public class VolumeSettingsSetUp : MonoBehaviour
    {
        [SerializeField] 
        private AudioMixer audioMixer;

        [SerializeField] 
        private float mutedVolumeValue = -80f;

        [SerializeField] 
        private float defaultVolumeValue = -30f;

        private const string VOLUME_PREFS_KEY = "volume";

        private const string MUTED_PREFS_KEY = "muted";

        private void Start()
        {
            if (PlayerPrefs.HasKey(VOLUME_PREFS_KEY))
            {
                LoadVolumeSettingsFromPlayerPrefs();
                return;
            }

            SetDefaultVolumeSettings();
        }

        private void LoadVolumeSettingsFromPlayerPrefs()
        {
            if (PlayerPrefs.GetInt(MUTED_PREFS_KEY) == 1)
            {
                audioMixer.SetFloat(VOLUME_PREFS_KEY, mutedVolumeValue);
                return;
            }

            var volumeValue = PlayerPrefs.GetFloat(VOLUME_PREFS_KEY);

            audioMixer.SetFloat("volume", volumeValue);
        }

        private void SetDefaultVolumeSettings()
        {
            audioMixer.SetFloat(VOLUME_PREFS_KEY, defaultVolumeValue);
        }
    }
}