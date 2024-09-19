using UnityEngine;

namespace _knockBalls.Scripts.Bullet
{
    public class BulletManager : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _initTransform;

        public void ShootTheBullet(Vector3 targetPos)
        {
            var bullet = Instantiate(_bullet, transform);
            bullet.transform.position = _initTransform.position;
            bullet.GetComponent<BulletController>().Move(targetPos);
        }
    }
}