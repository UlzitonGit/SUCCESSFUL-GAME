using UnityEngine;

public class UI_Settings : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    private bool _isActive = false;

    public void IsActive()
    {
        if (Input.GetMouseButton(0))
        {
            return;
        }
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
