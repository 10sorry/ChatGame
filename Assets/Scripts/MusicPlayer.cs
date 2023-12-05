using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void MusicPlay()
    {
        audioSource.Play();
    }

    public void MusicStop()
    {
        audioSource.Stop();
    }
    
}
