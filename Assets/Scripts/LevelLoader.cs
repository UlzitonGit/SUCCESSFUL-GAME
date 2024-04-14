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
        wideObject.SetActive(true);
    }

    public void StartGame()
    {
        StartCoroutine(LoadLevel(1));
    }
    public void StartNewGame()
    {
        PlayerPrefs.SetInt("CheckPoint", 0);
        StartCoroutine(LoadLevel(1));
    }
    IEnumerator LoadLevel(int index)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
    }
}
