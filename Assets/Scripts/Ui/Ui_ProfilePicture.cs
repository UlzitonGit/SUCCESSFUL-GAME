using TMPro;
using UnityEngine;

public class Ui_ProfilePicture : MonoBehaviour
{
    [SerializeField] private GameObject goodSideImage;
    [SerializeField] private GameObject badSideImage;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private TextMeshProUGUI HP_text;

    private bool _isGood = true;

    private void Update()
    {
       

        HP_text.text = Mathf.RoundToInt(playerHealth.health * 100).ToString() + "/" + playerHealth.healthToText;
    }

    public void ChangePicture()
    {
        if (_isGood)
        {
            goodSideImage.SetActive(false);
            badSideImage.SetActive(true);
            _isGood = false;
        }
        else
        {
            goodSideImage.SetActive(true);
            badSideImage.SetActive(false);
            _isGood = true;
        }
    }
}
