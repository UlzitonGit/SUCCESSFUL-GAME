using UnityEngine;

public class UI_StartScreen : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    private void Start()
    {
        settingsPanel.SetActive(false);
    }
}
