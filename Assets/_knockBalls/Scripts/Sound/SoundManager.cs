using UnityEngine;

namespace _knockBalls.Scripts.Sound
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource GetMusicSource => musicSource;
        public AudioSource GetEffectSource => effectSource;

        [SerializeField] private AudioSource musicSource, effectSource;
        [SerializeField] private <Data.AudioType, AudioClip> audioClipDict;

        public void SetMusicValue(float value) => musicSource.volume = value;
        public void SetEffectValue(float value) => effectSource.volume = value;

        public void ChangeMusic(Data.AudioType type)
        {
            ChangeSound(type, false);
        }

        public void PlayEffect(Data.AudioType type)
        {
            ChangeSound(type, true);
        }

        private void ChangeSound(Data.AudioType type, bool isEffect)
        {
            foreach (var (key, value) in audioClipDict)
            {
                if (key == type)
                {
                    if (isEffect)
                    {
                        effectSource.Stop();
                        effectSource.clip = value;
                        effectSource.Play();
                    }
                    else
                    {
                        musicSource.Stop();
                        musicSource.clip = value;
                        musicSource.Play();
                    }

                    break;
                }
            }
        }

        public void StopMusic()
        {
            musicSource.Stop();
        }
    }
}