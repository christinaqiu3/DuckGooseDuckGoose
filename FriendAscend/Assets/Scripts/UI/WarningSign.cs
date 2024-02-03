using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WarningSign : MonoBehaviour
    {
        [SerializeField] private Image sign;
        [SerializeField] private TMP_Text excl;

        private bool _enabled;
        private Coroutine _animOpacity;

        private void Update()
        {
            if (!_enabled)
            {
                return;
            }
            
            SetOpacity((float) (Math.Sin((Math.PI / 2f) + Time.time * 6.5f) + 0.5f));
        }

        private void SetOpacity(float opacity)
        {
            var signCol = sign.color;
            sign.color = new Color(signCol.r, signCol.g, signCol.b, opacity);

            var exclCol = excl.color;
            excl.color = new Color(exclCol.r, exclCol.g, exclCol.b, opacity);
        }
        
        private IEnumerator AnimOpacity(float opacity)
        {
            var original = sign.color.a;
            var progress = 0f;
            const float length = 0.1f;
            
            while (progress < length)
            {
                progress += Time.deltaTime;
                SetOpacity(Mathf.Lerp(original, opacity, progress / length));
                
                yield return null;
            }

            var color = sign.color;
            sign.color = new Color(color.r, color.g, color.b, opacity);
        }

        private void StartAnimOpacity(float opacity)
        {
            if (_animOpacity != null)
            {
                StopCoroutine(_animOpacity);
            }

            _animOpacity = StartCoroutine(AnimOpacity(opacity));
        }

        public void Enable()
        {
            _enabled = true;
            StartAnimOpacity(1f);
        }

        public void Disable()
        {
            _enabled = false;
            StartAnimOpacity(0f);
        }
    }
}
