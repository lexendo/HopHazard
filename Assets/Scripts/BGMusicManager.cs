using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicManager : MonoBehaviour
{
    private static BGMusicManager instance;
    public static BGMusicManager Instance
    {
        get
        {
            return instance;
        }
    }




    [SerializeField] private AudioSource audioSource;
    public AudioClip[] songs;
    public float volume = 0.2f;
    private bool[] beenPlayed;
    private int songsPlayed = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        beenPlayed = new bool[songs.Length];
    }
    private void Update()
    {
        audioSource.volume = volume;
        if (audioSource.isPlaying == false)
        {
            ChangeSong(Random.Range(0, songs.Length));
        }
    }

    public void ChangeSong(int songPicked)
    {
        if (songsPlayed == songs.Length)
        {
            ResetShuffle();
        }
        if (beenPlayed[songPicked] == false) {
            beenPlayed[songPicked] = true;
            songsPlayed++;
            audioSource.clip = songs[songPicked];
            audioSource.Play();
        }

    }
    private void ResetShuffle()
    {
        for (int i = 0; i < songs.Length; i++)
        {
            beenPlayed[i] = false;
        }
        songsPlayed = 0;
    }
}
