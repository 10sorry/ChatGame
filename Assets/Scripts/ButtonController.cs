using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public int trackIndex;
    [SerializeField] private MusicManager musicManager;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlayTrack);
    }

    private void PlayTrack()
    {
        musicManager.PlayMusic(trackIndex);
        Debug.Log($"Play track {trackIndex}");
    }
}
