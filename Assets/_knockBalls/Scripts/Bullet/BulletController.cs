using UnityEngine;

namespace _knockBalls.Scripts.Bullet
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private float _fireForce, _upwardForce = 5f; 
        
        public void Move(Vector3 targetPos)
        {
            var direction = (targetPos - transform.position).normalized; 
            var force = new Vector3(direction.x, _upwardForce, direction.z) * _fireForce;
            _rb.AddForce( force , ForceMode.VelocityChange); 
        }
    }
}