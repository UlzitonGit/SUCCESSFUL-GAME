using UnityEngine;
using UnityEngine.UI;

public class UI_Settings : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Button closeButton;

    private bool _isActive = false;

    private void Start()
    {
        settingsPanel.SetActive(false);
        closeButton.onClick.AddListener(IsActive);
    }

    private void IsActive()
    {
        if (_isActive)
        {
            settingsPanel.SetActive(false);
            _isActive = false;
        }
        else
        {
            settingsPanel.SetActive(true);
            _isActive = true;
        }
    }
}
