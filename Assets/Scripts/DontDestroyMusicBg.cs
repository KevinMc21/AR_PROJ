using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusicBg : MonoBehaviour
{
    private AudioSource _audio;
    private void Awake()
    {

        DontDestroyOnLoad(transform.gameObject);
        _audio = GetComponent<AudioSource>();
        
    }

    public void PlayMusic()
    {
        if (_audio.isPlaying) return;
        _audio.Play();
    }

    public void StopMusic()
    {
        _audio.Stop();
    }

}
