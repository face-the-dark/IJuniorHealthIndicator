using System.Collections;
using UnityEngine;

namespace UI
{
    public class HealthSmoothSliderView : HealthSliderView
    {
        [SerializeField] private float _smoothSpeed = 0.5f;
        
        private Coroutine _moveCoroutine;
        
        protected override void UpdateView(int currentValue, int maxValue)
        {
            float currentPercentHealth = CalculateCurrentPercentHealth(currentValue, maxValue);

            StopMoveCoroutine();

            _moveCoroutine = StartCoroutine(MoveSliderValue(currentPercentHealth));
        }

        private void StopMoveCoroutine()
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
                _moveCoroutine = null;
            }
        }

        private IEnumerator MoveSliderValue(float currentPercentHealth)
        {
            while (Mathf.Approximately(Slider.value, currentPercentHealth) == false)
            {
                Slider.value = Mathf.MoveTowards(Slider.value, currentPercentHealth, Time.deltaTime * _smoothSpeed);  
            
                yield return null;
            }
        }
    }
}