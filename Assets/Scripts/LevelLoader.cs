using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject wideObject;
    [SerializeField] private Animator transition;
    private float transitionTime = 1f;
    void Awake()
    {
        Time.timeScale = 1f;
        wideObject.SetActive(true);
    }

    public void StartGame()
    {
        StartCoroutine(LoadLevel(2));
    }
    public void StartNewGame()
    {
        PlayerPrefs.SetInt("CheckPoint", 0);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator LoadLevel(int index)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
    }
}
