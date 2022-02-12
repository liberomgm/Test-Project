using UnityEngine;
using UnityEngine.Audio;

namespace OptionMenu
{
    public class AudoiSettings : MonoBehaviour
    {
        [SerializeField]
        private AudioMixer audioMixer;

        public void SetVolume(float volume)
        {
            if (audioMixer != null)
                audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
            else
                return;
        }

        public void SoundSwitch()
        {
            AudioListener.pause = !AudioListener.pause;
        }
    }
}
