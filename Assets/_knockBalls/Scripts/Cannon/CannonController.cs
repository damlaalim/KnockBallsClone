using UnityEngine;

namespace _knockBalls.Scripts.Cannon
{
    public class CannonController : MonoBehaviour
    {
        private Animator _anim;
        private static readonly int CannonShoot = Animator.StringToHash("Shoot");

        private void Start()
        {
            _anim = GetComponent<Animator>();
        }

        public void Shoot(Vector3 lookPos)
        {
            transform.LookAt(lookPos);
            _anim.SetTrigger(CannonShoot);
        }
    }
}