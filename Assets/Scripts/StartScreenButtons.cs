using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenButtons : MonoBehaviour
{
    public void StartNewGame()
    {
        PlayerPrefs.SetInt("CheckPoint", 0);
        SceneManager.LoadScene(1);

    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
