using System.Collections;
using UnityEngine;

namespace _knockBalls.Scripts.CameraSystems
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private AnimationCurve _animationCurve;
        
        private Vector3 _originalPos;
        private Coroutine _shakeRoutine;
        
        public void Shake()
        {
            if (_shakeRoutine is not null)
            {
                StopCoroutine(_shakeRoutine);
                transform.position = _originalPos;
            }

            _shakeRoutine = StartCoroutine(Shake_Routine());
        }
        
        private IEnumerator Shake_Routine()
        {
            _originalPos = transform.position;
            
            var elapsed = 0f;

            while (elapsed < _duration)
            {
                var strength = _animationCurve.Evaluate(elapsed / _duration); 
                transform.position = _originalPos + Random.insideUnitSphere * strength;
                
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.position = _originalPos;
        }
    }
}