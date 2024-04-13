using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundsVolume : MonoBehaviour
{
    #region [SerializeField]
    /*[SerializeField] private AudioSource frogs;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource sfx;*/

    [SerializeField] private TextMeshProUGUI frogsPercentText;
    [SerializeField] private TextMeshProUGUI musicPercentText;
    [SerializeField] private TextMeshProUGUI sfxPercentText;

    [SerializeField] private Slider frogsSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    #endregion

    private void Awake()
    {
        //frogsSlider.value = frogs.volume;
        //musicSlider.value = music.volume;
        //sfxSlider.value = sfx.volume;
    }

    public void FrogsVolumeChange()
    {
        //frogs.volume = frogsSlider.value;
        frogsPercentText.text = Mathf.RoundToInt(frogsSlider.value) + "%";
    }
    public void MusicVolumeChange()
    {
        //music.volume = musicSlider.value;
        musicPercentText.text = Mathf.RoundToInt(musicSlider.value) + "%";
    }
    public void SFXVolumeChange()
    {
        //sfx.volume = sfxSlider.value;
        sfxPercentText.text = Mathf.RoundToInt(sfxSlider.value) + "%";
    }
}
