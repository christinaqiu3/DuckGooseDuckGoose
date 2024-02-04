using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProgressRing : MonoBehaviour
    {
        [SerializeField] private Image ring;
        [SerializeField] private Image bg;
        
        private Coroutine _animOpacity;
        private bool _gotDoubleJump;
        
        public float Fill { private get; set; }
        
        private void Update()
        {
            ring.fillAmount = Mathf.Clamp(Fill, 0f, 1f);
        }
        
        private IEnumerator AnimOpacity(float opacity, float length)
        {
            var original = ring.color.a;
            
            var progress = 0f;
            
            while (progress < length)
            {
                progress += Time.deltaTime;

                var ringColor = ring.color;
                var bgColor = bg.color;
                var alpha = Mathf.Lerp(original, opacity, progress / length);
                
                ring.color = new Color(ringColor.r, ringColor.g, ringColor.b, alpha);
                bg.color = new Color(bgColor.r, bgColor.g, bgColor.b, alpha / 2.5f);
                
                yield return null;
            }

            var ringCol = ring.color;
            var bgCol = bg.color;
            
            ring.color = new Color(ringCol.r, ringCol.g, ringCol.b, opacity);
            bg.color = new Color(bgCol.r, bgCol.g, bgCol.b, opacity / 2.5f);
        }

        private void SetOpacity(float opacity, float length)
        {
            if (_animOpacity != null)
            {
                StopCoroutine(_animOpacity);
            }

            _animOpacity = StartCoroutine(AnimOpacity(opacity, length));
        }

        public void Appear(float fill)
        {
            if (_gotDoubleJump)
            {
                return;
            }
            
            SetOpacity(1f, 0.1f);
            Fill = fill;
        }

        public void Disappear()
        {
            SetOpacity(0f, 0.1f);
        }

        public void GetDoubleJump()
        {
            _gotDoubleJump = true;
            
            Fill = 1f;
            ring.color = Color.green;
            SetOpacity(0f, 0.55f);
        }
    }
}
