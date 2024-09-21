using _knockBalls.Scripts.Bullet;
using UnityEngine;

namespace _knockBalls.Scripts.Target
{
    public class TargetCollision : MonoBehaviour
    {
        [SerializeField] private TargetController _target;

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag($"Plane"))
            {
                _target.Destroy();
            }
            else if (other.transform.TryGetComponent<BulletController>(out _) &&
                     TryGetComponent<TntTargetController>(out var tntTarget))
            {
                tntTarget.Explode();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag($"Plane") || other.transform.CompareTag($"Wall"))
            {
                _target.Destroy();
            }
        }
    }
}