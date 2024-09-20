using _knockBalls.Scripts.Data;
using UnityEngine;

namespace _knockBalls.Scripts.CanvasSystem
{
    public class CanvasController : MonoBehaviour
    {
        public virtual CanvasType CanvasType => CanvasType.StartGameCanvas;
        
        [SerializeField] protected CanvasManager CanvasManager;
        protected Canvas Canvas; 

        public virtual void Initialize()
        {
            Canvas = GetComponent<Canvas>();
            Close();
        }

        public virtual void Close() => Canvas.enabled = false;

        public virtual void Open() => Canvas.enabled = true;

        public virtual void Back() => CanvasManager.Back();
    }
}