using UnityEngine;

namespace _knockBalls.Scripts.Bullet
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private float _fireSpeed;
        
        public void Move(Vector3 targetPos)
        {
            var direction = (targetPos - transform.position).normalized; 
            _rb.velocity = direction * _fireSpeed;
        }
    }
}