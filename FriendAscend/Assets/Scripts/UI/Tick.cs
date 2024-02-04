using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Tick : MonoBehaviour
    {
        [SerializeField] private Image tick;
        
        private float _posY;
        
        private void Update()
        {
            var ap3D = tick.rectTransform.anchoredPosition3D;
            tick.rectTransform.anchoredPosition3D = new Vector3(ap3D.x, _posY, ap3D.z);
        }
        
        public void CalculatePos(float bot)
        {
            _posY = bot * 800f;
        }
    }
}
