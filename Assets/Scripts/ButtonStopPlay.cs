using UnityEngine;
using UnityEngine.UI;

public class ButtonStopPlay : MonoBehaviour
{
    private MusicManager musicManager;

    private void Start()
    {
        musicManager = MusicManager.Instance;

        Button playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        Button stopButton = GameObject.Find("StopButton").GetComponent<Button>();

        playButton.onClick.AddListener(PlayMusic);
        stopButton.onClick.AddListener(StopMusic);
    }

    public void PlayMusic()
    {
        int trackIndexToPlay = musicManager.GetCurrentTrackIndex();
        musicManager.PlayMusic(trackIndexToPlay);
    }

    public void StopMusic()
    {
        musicManager.StopMusic();
    }
}