using UnityEngine;

public class Ui_ProfilePicture : MonoBehaviour
{
    [SerializeField] private GameObject goodSideImage;
    [SerializeField] private GameObject badSideImage;

    private bool _isGood = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            ChangePicture();
    }

    private void ChangePicture()
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
