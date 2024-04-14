using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
