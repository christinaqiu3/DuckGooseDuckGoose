using UI;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    
    public void StartGame() {
        sceneLoader.LoadScene("Level 1");
    }

    public void QuitGame()  {
        Application.Quit();
    }
}
