using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaybackIndicator : MonoBehaviour
{
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private Slider playbackSlider;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI currentTimeText;
    [SerializeField] private TextMeshProUGUI totalTimeText;

    private void Start()
    {
        musicManager = MusicManager.Instance;

        Button playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        Button stopButton = GameObject.Find("StopButton").GetComponent<Button>();

        playButton.onClick.AddListener(PlayMusic);
        stopButton.onClick.AddListener(StopMusic);
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        volumeSlider.value = 1f;
    }

    private void Update()
    {
        UpdateUI();
    }

    private void PlayMusic()
    {
        musicManager.PlayMusic(musicManager.GetCurrentTrackIndex());
    }

    private void UpdateUI()
    {

        if (musicManager.IsPlaying())
        {
            playbackSlider.maxValue = musicManager.GetTotalDuration();
            playbackSlider.value = musicManager.GetCurrentPosition();

            currentTimeText.text = FormatTime(musicManager.GetCurrentPosition());
            totalTimeText.text = FormatTime(musicManager.GetTotalDuration());
        }
        else
        {
            playbackSlider.value = 0f;
            currentTimeText.text = "0:00";
            totalTimeText.text = "0:00";
        }
    }

    private void StopMusic()
    {
        musicManager.StopMusic();
    }
    
    private void ChangeVolume(float volume)
    {
        // Ensure that the volume value is within the valid range (0 to 1)
        volume = Mathf.Clamp01(volume);

        // Calculate the new volume based on the slider position
        float newVolume = Mathf.Lerp(0f, 1f, volume);

        // Set the volume of the MusicManager
        musicManager.SetVolume(newVolume);
    }

    private string FormatTime(float seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60F);
        int remainingSeconds = Mathf.FloorToInt(seconds - minutes * 60);
        return $"{minutes:0}:{remainingSeconds:00}";
    }
    
}