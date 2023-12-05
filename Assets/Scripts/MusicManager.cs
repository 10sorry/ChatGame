using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    public static MusicManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MusicManager>();

                if (instance == null)
                {
                    Debug.LogError("MusicManager is not present in the scene.");
                }
            }

            return instance;
        }
    }

    [SerializeField] private AudioClip[] musicTracks;
    private AudioSource audioSource;
    private int currentTrackIndex = -1; // Индекс текущего трека
    private float trackPosition = 0f;  // Позиция текущего трека

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public int GetCurrentTrackIndex()
    {
        return currentTrackIndex;
    }

    public void PlayMusic(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < musicTracks.Length)
        {
            if (!audioSource.isPlaying || currentTrackIndex != trackIndex)
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
                
                audioSource.clip = musicTracks[trackIndex];
                Debug.Log($"Now track {trackIndex} is playing");
                
                audioSource.time = trackPosition;
                audioSource.Play();
                
                currentTrackIndex = trackIndex;
                trackPosition = 0f;
            }
        }
    }

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }

    public float GetCurrentPosition()
    {
        return audioSource.time;
    }

    public float GetTotalDuration()
    {
        return audioSource.clip != null ? audioSource.clip.length : 0f;
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            trackPosition = audioSource.time;
            audioSource.Stop();
        }
    }
}