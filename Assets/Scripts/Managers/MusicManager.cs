using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;
    public static MusicManager instance;
    public bool isPlaying;

    public AudioClip HitSound()
    {
        return clips[Random.Range(3, 5)];
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        source = GetComponent<AudioSource>();
    }
}
