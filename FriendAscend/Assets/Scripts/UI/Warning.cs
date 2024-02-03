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

        // takes in two floats 0.0-1.0, calculates: PosY, Height, and uvRect's H
        public void CalculateHeight(float bot, float top)
        {
            var diff = top - bot;
            
            _posY = bot * 800f;
            _height = diff * 800f;
            _uvH = _height / 50f;
        }
    }
}
