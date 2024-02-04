using UnityEngine;

namespace UI
{
    public class Follow : MonoBehaviour
    {
        [SerializeField] private Canvas cameraCanvas;
        [SerializeField] private GameObject target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private RectTransform rectTransform;
        
        private Camera _camera;

        private void Awake()
        {
            _camera = cameraCanvas.worldCamera;
        }

        private void Update()
        {
            rectTransform.anchoredPosition3D = _camera.WorldToScreenPoint(target.transform.position) + offset;
        }
    }
}
