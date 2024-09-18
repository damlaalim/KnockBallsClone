using UnityEngine;

namespace _knockBalls.Scripts.Bullet
{
    public class BulletManager : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        
        public void ShootTheBullet(Vector3 targetPos)
        {
            var bullet = Instantiate(_bullet, transform);
            bullet.transform.position = Vector3.zero;
            bullet.GetComponent<BulletController>().Move(targetPos);
        }
    }
}