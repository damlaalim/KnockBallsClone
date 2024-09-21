using UnityEngine;

namespace _knockBalls.Scripts.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; } 
        public int GetHighScore, GetScore;
        
        private void Awake()
        {
            Instance ??= this;
        }
    }
}