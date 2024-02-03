using System;
using UnityEngine;
using TMPro;

namespace UI
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private GameObject clockHand;

        private bool _paused;
        private float _time;

        private void Update()
        {
            if (_paused)
            {
                return;
            }

            _time += Time.deltaTime;
            
            var eulerAngles = clockHand.transform.eulerAngles;
            clockHand.transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, _time * -60f);

            var ts = new TimeSpan((long) (_time * 10_000_000));
            text.text = ts.ToString(@"h\:mm\:ss\.fff");
        }

        public void ResetTimer() => _time -= _time;
        public void Pause() => _paused = true;
        public void Continue() => _paused = false;
    }
}
