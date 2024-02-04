using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Warning : MonoBehaviour
    {
        [SerializeField] private RawImage warning;

        private float _posY;
        private float _height;
        private float _uvH;
        
        private Coroutine _animOpacity;
        
        private void Update()
        {
            var uvRect = warning.uvRect;
            var rt = warning.rectTransform;
            var ap3D = rt.anchoredPosition3D;
            
            var position = new Vector2(uvRect.position.x, uvRect.position.y - Time.deltaTime);
            var size = new Vector2(uvRect.size.x, _uvH);
            
            warning.uvRect = new Rect(position, size);
            warning.rectTransform.anchoredPosition3D = new Vector3(ap3D.x, _posY, ap3D.z);
            warning.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _height);
        }

        public void CalculateHeight(float bot, float top)
        {
            var diff = top - bot;
            
            _posY = bot * 800f;
            _height = diff * 800f;
            _uvH = _height / 50f;
        }

        private IEnumerator AnimOpacity(float opacity)
        {
            var original = warning.color.a;
            var progress = 0f;
            const float length = 0.1f;
            
            while (progress < length)
            {
                progress += Time.deltaTime;

                var c = warning.color;
                c.a = Mathf.Lerp(original, opacity, progress / length);
                warning.color = c;
                
                yield return null;
            }

            var color = warning.color;
            warning.color = new Color(color.r, color.g, color.b, opacity);
        }

        public void SetOpacity(float opacity)
        {
            if (_animOpacity != null)
            {
                StopCoroutine(_animOpacity);
            }

            _animOpacity = StartCoroutine(AnimOpacity(opacity));
        }
    }
}
