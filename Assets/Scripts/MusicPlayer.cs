using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] Musics;
    [SerializeField] AudioClip win, lose;
    AudioSource audioSource;

    void Awake()
    {
        SetUpSingleton();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextSong();
    }

    void PlayNextSong()
    {
        AudioClip audio = Musics[Random.Range(0, Musics.Length)];
        audioSource.clip = audio;
        audioSource.Play();
        Invoke("PlayNextSong", audio.length);
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayWin()
    {
        CancelInvoke();
        audioSource.Stop();
        if (!audioSource.isPlaying)
            GetComponent<AudioSource>().PlayOneShot(win);
        Invoke("PlayNextSong", 2f);
    }
    public void PlayLose()
    {
        CancelInvoke();
        audioSource.Stop();
        if(!audioSource.isPlaying)
            GetComponent<AudioSource>().PlayOneShot(lose);
        Invoke("PlayNextSong", 2f);
    }
}