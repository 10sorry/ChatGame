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
    [SerializeField] private AudioClip[] sfx;
    private AudioSource audioSource;
    private int currentTrackIndex = -1; // Индекс текущего трека
    private float trackPosition = 0f;
    private float currentVolume = 1.0f;// Позиция текущего трека

    
    private void Awake()
    {
        // Переключает объект, на котором находится этот скрипт, так, чтобы он не уничтожался при загрузке новой сцены
        DontDestroyOnLoad(gameObject);
    }
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
    
    public float GetVolume()
    {
        return currentVolume;
    }
    public void SetVolume(float volume)
    {
        // Ensure that the volume value is within the valid range (0 to 1)
        volume = Mathf.Clamp01(volume);

        // Set the volume of the current AudioSource
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }


    public float GetCurrentPosition()
    {
        return audioSource.time;
    }

    public float GetTotalDuration()
    {
        return audioSource.clip != null ? audioSource.clip.length : 0f;
    }

    public void StartButton()
    {
        audioSource.PlayOneShot(sfx[0]);
    }
    
    public void UIButton()
    {
        audioSource.PlayOneShot(sfx[2]);
    }

    public void ErrorButton()
    {
        audioSource.PlayOneShot(sfx[3]);
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