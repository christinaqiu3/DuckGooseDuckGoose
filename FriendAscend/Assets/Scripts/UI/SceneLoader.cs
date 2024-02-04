using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

namespace UI
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Image arrow;
        [SerializeField] private Image heart;
        [SerializeField] private bool animateExit = true;
        
        public bool IsExiting { get; private set; }
        
        private Coroutine _animEnter;
        private Coroutine _animExit;
        private bool _exitAnimPlayed;

        private const float Length = 0.5f;

        private void Update()
        {
            if (!animateExit || _exitAnimPlayed)
            {
                return;
            }
            
            StartExitAnim();
            _exitAnimPlayed = true;
        }

        private IEnumerator TransitionScene(string sceneName)
        {
            StartEnterAnim();

            yield return new WaitForSecondsRealtime(Length);

            var asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

        private IEnumerator AnimEnter()
        {
            var progress = 0f;

            var init = new Vector3(0, -2000, 0);
            var final = new Vector3(0, 0, 0);

            while (progress < Length)
            {
                progress += Time.unscaledDeltaTime;
                var arrowRatio = Easing.InOutPower(Mathf.Clamp(progress / Length, 0f, 1f), 5);
                var heartRatio = Easing.OutPower(Mathf.Clamp((progress / Length) - 0.2f, 0f, 1f), 4);

                arrow.rectTransform.anchoredPosition3D = Vector3.Lerp(init, final, arrowRatio);
                heart.rectTransform.anchoredPosition3D = Vector3.Lerp(init, final, heartRatio);
                heart.rectTransform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, -90), Quaternion.Euler(0, 0, 0), heartRatio);

                yield return null;
            }

            arrow.rectTransform.anchoredPosition3D = final;
            heart.rectTransform.anchoredPosition3D = final;
            heart.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
        private IEnumerator AnimExit()
        {
            var progress = 0f;

            var init = new Vector3(0, 0, 0);
            var final = new Vector3(0, 2000, 0);

            while (progress < Length)
            {
                progress += Time.unscaledDeltaTime;
                var arrowRatio = Easing.InOutPower(Mathf.Clamp(progress / Length, 0f, 1f), 5);
                var heartRatio = Easing.InPower(Mathf.Clamp((progress / Length) - 0.2f, 0f, 1f), 2);

                arrow.rectTransform.anchoredPosition3D = Vector3.Lerp(init, final, arrowRatio);
                heart.rectTransform.anchoredPosition3D = Vector3.Lerp(init, final, heartRatio);
                heart.rectTransform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), heartRatio);

                yield return null;
            }
            
            arrow.rectTransform.anchoredPosition3D = final;
            heart.rectTransform.anchoredPosition3D = final;
            heart.rectTransform.rotation = Quaternion.Euler(0, 0, 90);

            IsExiting = false;
        }

        public void StartEnterAnim()
        {
            if (_animEnter != null)
            {
                StopCoroutine(_animEnter);
            }
            if (_animExit != null)
            {
                StopCoroutine(_animExit);
            }

            _animEnter = StartCoroutine(AnimEnter());
        }
        
        public void StartExitAnim()
        {
            if (_animExit != null)
            {
                StopCoroutine(_animExit);
            }
            if (_animEnter != null)
            {
                StopCoroutine(_animEnter);
            }

            _animExit = StartCoroutine(AnimExit());
            IsExiting = true;
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(TransitionScene(sceneName));
        }
    }
}