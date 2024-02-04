using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

namespace UI
{
    public class DoubleJumpText : MonoBehaviour
    {
        [SerializeField] private Image bg;
        [SerializeField] private TMP_Text text;
        [SerializeField] private RectTransform rectTransform;

        private IEnumerator AnimAppear()
        {
            const float length = 1.5f;
            var progress = 0f;
            
            var position = rectTransform.anchoredPosition3D;
            var final = position.y + 100f;

            while (progress < length)
            {
                progress += Time.deltaTime;
                var ratio = progress / length;
                
                var bgCol = bg.color;
                bg.color = new Color(bgCol.r, bgCol.g, bgCol.b, Mathf.Lerp(0.5f, 0, ratio));

                var textCol = text.color;
                text.color = new Color(textCol.r, textCol.g, textCol.b, Easing.OutPower(Mathf.Lerp(1f, 0f, ratio), 5));

                rectTransform.anchoredPosition3D = new Vector3(position.x, Mathf.Lerp(position.y, final, ratio), position.z);
                
                yield return null;
            }
            
            var bgColor = bg.color;
            bg.color = new Color(bgColor.r, bgColor.g, bgColor.b, 0f);

            var textColor = text.color;
            text.color = new Color(textColor.r, textColor.g, textColor.b, 0f);
        }

        public void Appear()
        {
            var bgCol = bg.color;
            bg.color = new Color(bgCol.r, bgCol.g, bgCol.b, 0.5f);

            var textCol = text.color;
            text.color = new Color(textCol.r, textCol.g, textCol.b, 1f);
            
            StartCoroutine(AnimAppear());
        }
    }
}
