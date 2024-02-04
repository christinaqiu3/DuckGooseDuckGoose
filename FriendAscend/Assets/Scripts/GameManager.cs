using System;
using UnityEngine;
using UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject goose;
    [SerializeField] private GameObject duck;
    [SerializeField] private ProgressBar progressBar;

    [SerializeField] private ProgressRing gooseRing;
    [SerializeField] private ProgressRing duckRing;

    public float _maxHeight;
    
    private void Awake()
    {
        _maxHeight = 50f;
    }

    private void Update()
    {
        progressBar.SetProgress(goose.transform.position.y / _maxHeight, duck.transform.position.y / _maxHeight);
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
