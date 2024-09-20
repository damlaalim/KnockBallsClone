using UnityEngine;

namespace _knockBalls.Scripts.Target
{
    public class TntTargetController : TargetController
    {
        [SerializeField] private float _radius = 5f, _power = 100f, _upForce = 1f;
        public void Explode()
        {
            var explosionPos = transform.position;
            var colliders = Physics.OverlapSphere(explosionPos, _radius);
            
            foreach (var hit in colliders)
            {
                if (hit.TryGetComponent<TargetController>(out var targetController))
                {
                    targetController.Explode(_power, explosionPos, _radius, _upForce);
                }
            }
        }
    }
}