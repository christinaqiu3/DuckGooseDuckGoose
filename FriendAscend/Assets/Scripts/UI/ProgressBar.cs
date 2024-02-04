using System;
using UnityEngine;

namespace UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Warning warning;
        [SerializeField] private WarningSign warningSign;
        [SerializeField] private Tick gooseTick;
        [SerializeField] private Tick duckTick;

        [SerializeField, Range(0f, 1f)] private float progGoose;
        [SerializeField, Range(0f, 1f)] private float progDuck;

        private bool _warningEnabled;

        private void Update()
        {
            if (Math.Abs(progGoose - progDuck) >= 0.15f)
            {
                if (!_warningEnabled)
                {
                    _warningEnabled = true;
                    EnableWarning();
                }
            }
            else
            {
                if (_warningEnabled)
                {
                    _warningEnabled = false;
                    DisableWarning();
                }
            }
            
            gooseTick.CalculatePos(progGoose);
            duckTick.CalculatePos(progDuck);

            if (!_warningEnabled)
            {
                return;
            }
            
            if (progGoose <= progDuck)
            {
                warning.CalculateHeight(progGoose, progDuck);
            }
            else
            {
                warning.CalculateHeight(progDuck, progGoose);
            }
        }

        public void EnableWarning()
        {
            warningSign.Enable();
            warning.SetOpacity(1f);
        }

        public void DisableWarning()
        {
            warningSign.Disable();
            warning.SetOpacity(0f);
        }

        public void SetProgress(float goose, float duck)
        {
            progGoose = Mathf.Clamp(goose, 0f, 1f);
            progDuck = Mathf.Clamp(duck, 0f, 1f);
        }
    }
}
