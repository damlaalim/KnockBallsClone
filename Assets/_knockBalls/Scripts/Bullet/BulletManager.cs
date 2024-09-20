using System.Collections.Generic;
using UnityEngine;

namespace _knockBalls.Scripts.Bullet
{
    public class BulletManager : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _initTransform, _ball;
        
        private Stack<GameObject> _bulletPool = new Stack<GameObject>();

        public void ShootTheBullet(Vector3 targetPos)
        {
            _ball.LookAt(targetPos);
            
            var bullet = GetBullet();
            
            var bulletController = bullet.GetComponent<BulletController>();
            
            bulletController.Initialize(_initTransform.position, this);
            bulletController.Move(targetPos);
        }

        private GameObject GetBullet()
        {
            if (_bulletPool.Count > 0)
                return _bulletPool.Pop();

            var newBullet = Instantiate(_bullet, transform);
            return newBullet;
        }

        public void SetBullet(GameObject bullet)
        {
            _bulletPool.Push(bullet);
        }
    }
}