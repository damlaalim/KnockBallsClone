using System;
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
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag($"Plane"))
            {
                _target.Destroy();
            }
        }
    }
}