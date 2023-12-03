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

    public AudioClip[] musicTracks;
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
            // Если трек не играет или трек изменился, тогда воспроизводим новый трек
            if (!audioSource.isPlaying || currentTrackIndex != trackIndex)
            {
                // Если уже играет трек, останавливаем его
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }

                // Устанавливаем новый трек
                audioSource.clip = musicTracks[trackIndex];
                Debug.Log($"Now track {trackIndex} is playing");

                // Воспроизводим с сохраненной позиции
                audioSource.time = trackPosition;
                audioSource.Play();

                // Обновляем текущий индекс и позицию
                currentTrackIndex = trackIndex;
                trackPosition = 0f;
            }
        }
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            // Сохраняем текущую позицию трека перед остановкой
            trackPosition = audioSource.time;
            audioSource.Stop();
        }
    }
}