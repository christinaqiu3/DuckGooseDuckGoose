using UnityEngine;
using UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    
    [SerializeField] private GameObject goose;
    [SerializeField] private GameObject duck;
    [SerializeField] private ProgressBar progressBar;

    [SerializeField] private ProgressRing gooseRing;
    [SerializeField] private ProgressRing duckRing;

    public float _maxHeight;
    private bool _isRestarting;

    private void Update()
    {
        if (_isRestarting || sceneLoader.IsExiting)
        {
            return;
        }

        var gooseHeight = goose.transform.position.y - 1f;
        var duckHeight = duck.transform.position.y - 1f;

        if (gooseHeight < -5f || duckHeight < -5f)
        {
            sceneLoader.LoadScene("Level 1");
            _isRestarting = true;
        }
        
        progressBar.SetProgress((gooseHeight) / _maxHeight, (duckHeight) / _maxHeight);

        if (Input.GetKeyDown(KeyCode.R))
        {
            sceneLoader.LoadScene("Level 1");
            _isRestarting = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            sceneLoader.LoadScene("MainMenu");
            _isRestarting = true;
        }
    }

    public void fillGooseRing(float f)
    {
        if (f == 0)
            gooseRing.gameObject.SetActive(false);
        else
            gooseRing.gameObject.SetActive(true);
        gooseRing.Fill = f;
    }

    public void fillDuckRing(float f)
    {
        if (f == 0)
            duckRing.gameObject.SetActive(false);
        else
            duckRing.gameObject.SetActive(true);
        duckRing.Fill = f;
    }

}
