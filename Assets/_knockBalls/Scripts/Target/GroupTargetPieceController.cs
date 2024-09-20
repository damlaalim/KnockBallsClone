using UnityEngine;

namespace _knockBalls.Scripts.Target
{
    public class GroupTargetPieceController : TargetController
    {
        [SerializeField] private TargetGroup _targetGroup;

        public override void Destroy()
        {
            base.Destroy();
            _targetGroup.TargetDestroyed?.Invoke();
        }
    }
}