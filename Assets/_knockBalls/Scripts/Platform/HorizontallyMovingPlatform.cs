using UnityEngine;

namespace _knockBalls.Scripts.Platform
{
    public class HorizontallyMovingPlatform : MonoBehaviour
    {
        public float speed = 2f; 
        public float leftLimit = -5f;
        public float rightLimit = 5f;

        void Update()
        {
            var xPosition = Mathf.PingPong(Time.time * speed, rightLimit - leftLimit) + leftLimit;

            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        }
    }
}