using System;
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

    [SerializeField] private DoubleJumpText gooseDouble;
    [SerializeField] private DoubleJumpText duckDouble;

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

        var progGoose = (gooseHeight) / _maxHeight;
        var progDuck = (duckHeight) / _maxHeight;

        if (Math.Abs(progGoose - progDuck) >= 0.25)
        {
            sceneLoader.LoadScene("Level 1");
            _isRestarting = true;
        }

        progressBar.SetProgress(progGoose, progDuck);

        if (Input.GetKeyDown(KeyCode.R))
        {
            sceneLoader.LoadScene("Level 1");
            _isRestarting = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sceneLoader.LoadScene("MainMenu");
            _isRestarting = true;
        }
    }

    public void GooseRingAppear(float fill) => gooseRing.Appear(fill);
    public void GooseRingDisappear() => gooseRing.Disappear();
    
    public void DuckRingAppear(float fill) => duckRing.Appear(fill);
    public void DuckRingDisappear() => duckRing.Disappear();

    public void FillGooseRing(float f) => gooseRing.Fill = f;
    public void FillDuckRing(float f) => duckRing.Fill = f;

    public void GooseGetDoubleJump()
    {
        gooseRing.GetDoubleJump();
        gooseDouble.Appear();
    }

    public void DuckGetDoubleJump()
    {
        duckRing.GetDoubleJump();
        duckDouble.Appear();
    } 
}