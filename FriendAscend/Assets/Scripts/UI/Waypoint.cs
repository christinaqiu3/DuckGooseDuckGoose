using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] private Image waypoint;
        [SerializeField] private float speed;

        private float _posX;

        private void Start()
        {
            _posX = waypoint.rectTransform.anchoredPosition3D.x;
        }
        
        private void Update()
        {
            var ap3D = waypoint.rectTransform.anchoredPosition3D;
            var posX = _posX + ((float) Math.Sin(Time.time * speed) * 10f);

            waypoint.rectTransform.anchoredPosition3D = new Vector3(posX, ap3D.y, ap3D.z);
        }
    }
}
