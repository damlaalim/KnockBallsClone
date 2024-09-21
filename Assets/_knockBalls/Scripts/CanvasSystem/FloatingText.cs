using UnityEngine;

namespace _knockBalls.Scripts.CanvasSystem
{
    public class FloatingText : MonoBehaviour
    {
        [SerializeField] private float _destroyTime, _yPos;
        [SerializeField] private Vector2 _xRandomLimit;
        
        private void Start()
        {
            var randX = Random.Range(_xRandomLimit.x, _xRandomLimit.y);
            transform.localPosition = new Vector3(randX, _yPos, 0);
            Destroy(gameObject, _destroyTime);
        }
    }
}