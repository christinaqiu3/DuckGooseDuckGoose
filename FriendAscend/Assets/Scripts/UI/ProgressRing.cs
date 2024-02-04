using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProgressRing : MonoBehaviour
    {
        [SerializeField] private Image ring;
        
        public float Fill { private get; set; }
        
        private void Update()
        {
            ring.fillAmount = Mathf.Clamp(Fill, 0f, 1f);
        }
    }
}
