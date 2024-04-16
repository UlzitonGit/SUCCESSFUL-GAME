using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField] AudioClip[] musicSource;
    AudioSource _sfx;
    int musicIndex;
    // Start is called before the first frame update
    void Awake()
    {
        _sfx = GetComponent<AudioSource>();
        musicIndex = Random.Range(0, musicSource.Length);
        _sfx.PlayOneShot(musicSource[musicIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        if(_sfx.isPlaying == false)
        {
            int newIndex = Random.Range(0, musicSource.Length);
            while (musicIndex == newIndex)
            {
                newIndex = Random.Range(0, musicSource.Length);
            }
            musicIndex = newIndex;
            _sfx.PlayOneShot(musicSource[musicIndex]);
        }
    }
}
