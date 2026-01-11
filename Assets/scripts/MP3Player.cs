using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MP3Player : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;

    [Header("Controls")]
    public KeyCode togglePlayerKey = KeyCode.E;
    public KeyCode playPauseKey = KeyCode.Space;
    public KeyCode nextKey = KeyCode.RightArrow;

    [Header("State")]
    public bool playerInHand = false;

    [Header("UI")]
    public TextMeshProUGUI trackNameText;

    public List<AudioClip> playlist = new List<AudioClip>();
    private int currentTrackIndex = 0;

    void Start()
    {
        audioSource.playOnAwake = false;
        gameObject.SetActive(false);
        UpdateTrackName();
    }

    void Update()
    {
        if (Input.GetKeyDown(togglePlayerKey))
            TogglePlayer();

        if (!playerInHand) return;

        if (Input.GetKeyDown(playPauseKey))
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
            else
                PlayCurrent();
        }

        if (Input.GetKeyDown(nextKey))
            NextTrack();
    }

    void TogglePlayer()
    {
        playerInHand = !playerInHand;
        gameObject.SetActive(playerInHand);

        if (!playerInHand)
            audioSource.Pause();
    }

    // ===== ПЛЕЙЛИСТ =====

    public void AddTrack(AudioClip clip)
    {
        if (!playlist.Contains(clip))
        {
            playlist.Add(clip);
            Debug.Log("Добавлен трек: " + clip.name);
            UpdateTrackName();
        }
    }

    void PlayCurrent()
    {
        if (playlist.Count == 0) return;

        audioSource.clip = playlist[currentTrackIndex];
        audioSource.Play();
        UpdateTrackName();
    }

    void NextTrack()
    {
        if (playlist.Count == 0) return;

        currentTrackIndex = (currentTrackIndex + 1) % playlist.Count;
        PlayCurrent();
    }

    void UpdateTrackName()
    {
        if (trackNameText == null) return;

        if (playlist.Count == 0)
            trackNameText.text = "NO TRACK";
        else
            trackNameText.text = playlist[currentTrackIndex].name;
    }
}
