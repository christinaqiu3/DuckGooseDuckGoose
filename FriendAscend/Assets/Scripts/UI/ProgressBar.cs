using UnityEngine;

namespace UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Warning warning;
        [SerializeField, Range(0f, 1f)] private float progGoose;
        [SerializeField, Range(0f, 1f)] private float progDuck;
        
        private void Start()
        {
            progGoose = 0.5f;
            progDuck = 0.75f;
            
            warning.CalculateHeight(progGoose, progDuck);
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
        }
    }
}
