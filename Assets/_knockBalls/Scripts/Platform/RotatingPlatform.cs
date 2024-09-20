using UnityEngine;

namespace _knockBalls.Scripts.Platform
{
    public class RotatingPlatform : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotation;

        private void Update()
        {
            transform.Rotate(_rotation * Time.deltaTime);
        }
    }
}