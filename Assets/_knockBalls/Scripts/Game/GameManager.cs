using UnityEngine;

namespace _knockBalls.Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; } 
        public bool gameIsStart;
        
        private void Awake()
        {
            Instance ??= this;
        }
    }
}