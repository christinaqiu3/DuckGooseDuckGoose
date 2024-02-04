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
        
        private void Start()
        {
            progGoose = 0.5f;
            progDuck = 0.75f;

            // TODO: delete this for actual game
            EnableWarning();
        }

        private void Update()
        {
            if (progGoose <= progDuck)
            {
                warning.CalculateHeight(progGoose, progDuck);
            }
            else
            {
                warning.CalculateHeight(progDuck, progGoose);
            }
            
            gooseTick.CalculatePos(progGoose);
            duckTick.CalculatePos(progDuck);
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
    }
}
