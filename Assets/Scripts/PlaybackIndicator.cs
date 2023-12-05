using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaybackIndicator : MonoBehaviour
{
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private Slider playbackSlider;
    [SerializeField] private TextMeshProUGUI currentTimeText;
    [SerializeField] private TextMeshProUGUI totalTimeText;

    private void Start()
    {
        musicManager = MusicManager.Instance;

        Button playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        Button stopButton = GameObject.Find("StopButton").GetComponent<Button>();

        playButton.onClick.AddListener(PlayMusic);
        stopButton.onClick.AddListener(StopMusic);
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
        Debug.Log($"IsPlaying: {musicManager.IsPlaying()}, CurrentPosition: {musicManager.GetCurrentPosition()}, TotalDuration: {musicManager.GetTotalDuration()}");

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


    private string FormatTime(float seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60F);
        int remainingSeconds = Mathf.FloorToInt(seconds - minutes * 60);
        return $"{minutes:0}:{remainingSeconds:00}";
    }
    
}