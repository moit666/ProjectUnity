using System.Collections.Generic;
using UnityEngine;

public class MP3Player : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;

    [Header("Controls")]
    public KeyCode togglePlayerKey = KeyCode.E;      // достать / убрать плеер
    public KeyCode playPauseKey = KeyCode.Space;     // play / pause
    public KeyCode nextKey = KeyCode.RightArrow;     // следующий трек

    [Header("State")]
    public bool playerInHand = false;                // плеер в руках?

    public List<AudioClip> playlist = new List<AudioClip>();
    private int currentTrackIndex = 0;

    void Start()
    {
        audioSource.playOnAwake = false;
        gameObject.SetActive(false); // плеер изначально убран
    }

    void Update()
    {
        // достать / убрать плеер
        if (Input.GetKeyDown(togglePlayerKey))
        {
            TogglePlayer();
        }

        if (!playerInHand) return;

        // play / pause
        if (Input.GetKeyDown(playPauseKey))
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
            else
                PlayCurrent();
        }

        // следующий трек
        if (Input.GetKeyDown(nextKey))
        {
            NextTrack();
        }
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
        }
    }

    void PlayCurrent()
    {
        if (playlist.Count == 0) return;

        audioSource.clip = playlist[currentTrackIndex];
        audioSource.Play();
    }

    void NextTrack()
    {
        if (playlist.Count == 0) return;

        currentTrackIndex = (currentTrackIndex + 1) % playlist.Count;
        PlayCurrent();
    }
}
