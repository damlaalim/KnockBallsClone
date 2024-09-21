using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace _knockBalls.Scripts.Sound
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private SerializedDictionary<Data.AudioType, AudioClip> audioClipDict;

        private void Awake()
        {
            Instance ??= this;
        }
        
        public void PlayEffect(Data.AudioType type)
        {
            var audioSource = Instantiate(_audioSource);
            audioSource.clip = audioClipDict[type];
            audioSource.Play();
            var clipLength = audioClipDict[type].length;
            Destroy(audioSource.gameObject, clipLength);
        }

    }
}