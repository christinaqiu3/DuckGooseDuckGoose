using UnityEngine;
using UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject goose;
    [SerializeField] private GameObject duck;
    [SerializeField] private ProgressBar progressBar;

    private float _maxHeight;
    
    private void Awake()
    {
        _maxHeight = 50f;
    }

    private void Update()
    {
        progressBar.SetProgress(goose.transform.position.y / _maxHeight, duck.transform.position.y / _maxHeight);
    }
}
