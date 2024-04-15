using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundsVolume : MonoBehaviour
{
    #region [SerializeField]
    //[SerializeField] private AudioSource frogs;
    AudioSource[] music;
    //[SerializeField] private AudioSource sfx;

    [SerializeField] private TextMeshProUGUI frogsPercentText;
    [SerializeField] private TextMeshProUGUI musicPercentText;
    [SerializeField] private TextMeshProUGUI sfxPercentText;

    [SerializeField] private Slider frogsSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    #endregion

    private void Awake()
    {
        music = FindObjectsOfType<AudioSource>();
        //frogsSlider.value = frogs.volume;
        for (int i = 0; i < music.Length; i++)
        {
            musicSlider.value = music[i].volume * 100;
        }
        
        //sfxSlider.value = sfx.volume;
    }

    public void FrogsVolumeChange()
    {
        if (Input.GetMouseButton(0))
        {
            //frogs.volume = frogsSlider.value;
            frogsPercentText.text = Mathf.RoundToInt(frogsSlider.value) + "%";
        }
    }
    public void MusicVolumeChange()
    {
        if (Input.GetMouseButton(0))
        {
            music = FindObjectsOfType<AudioSource>();
            for (int i = 0; i < music.Length; i++)
            {
                music[i].volume = musicSlider.value / 100;
            }
            //musicSlider.value = music[0].volume * 100;
            musicPercentText.text = Mathf.RoundToInt(musicSlider.value) + "%";
        }
    }
    public void SFXVolumeChange()
    {
        if (Input.GetMouseButton(0))
        {
            //sfx.volume = sfxSlider.value;
            sfxPercentText.text = Mathf.RoundToInt(sfxSlider.value) + "%";
        }

    }
}
