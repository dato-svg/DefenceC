using System;
using UnityEngine;

public class BackGroundMusicController : MonoBehaviour
{
    public static BackGroundMusicController instance;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioSource source;

    private int index;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            if (index >= clips.Length)
            {
                index = 0;
            }
            
            source.clip = clips[index];
            source.Play();
            index++;
            
        }
        
    }
}
