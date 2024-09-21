using System.Collections.Generic;
using _knockBalls.Scripts.Cannon;
using _knockBalls.Scripts.Level;
using UnityEngine;

namespace _knockBalls.Scripts.Bullet
{
    public class BulletManager : MonoBehaviour
    {
        public static BulletManager Instance { get; private set; } 
        
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _initTransform;
        [SerializeField] private CannonController _cannonController;
        [SerializeField] private List<GameObject> _bulletObjectList;
        
        private Stack<GameObject> _bulletPool = new Stack<GameObject>();
        
        private void Awake()
        {
            Instance ??= this;
        }
        
        public void StartChapter(int bulletCount)
        {
            for (var i = 0; i < _bulletObjectList.Count; i++)
            {
                _bulletObjectList[i].SetActive(i < bulletCount);
            }
        }

        public void CloseLastBulletObject()
        {
            var lastBullet = _bulletObjectList.FindLast(x => x.activeSelf);
            if (lastBullet)
                lastBullet.SetActive(false);
        }
        
        public void ShootTheBullet(Vector3 targetPos)
        {
            if (!LevelManager.Instance.currentChapter!.CanShoot())
                return;
            
            _cannonController.Shoot(targetPos);
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