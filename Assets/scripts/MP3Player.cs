using UnityEngine;
using TMPro; // если используешь TextMeshPro

public class MP3Player : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] playlist;
    public TMP_Text trackInfo; // текст на плеере

    private int currentTrack = 0;
    private bool isPlayerActive = false; // плеер не активен по умолчанию

    void Start()
    {
        // Не запускаем трек сразу
        audioSource.Stop();
        UpdateUI();
    }

    void Update()
    {
        // Игрок достал плеер
        if (Input.GetKeyDown(KeyCode.R))
        {
            isPlayerActive = !isPlayerActive;

            // Если плеер включается впервые и есть треки
            if (isPlayerActive && audioSource.clip == null && playlist.Length > 0)
            {
                audioSource.clip = playlist[currentTrack];
            }
        }

        if (!isPlayerActive) return; // если плеер не в руках — ничего не делаем

        // Управление треком
        if(Input.GetKeyDown(KeyCode.Space))
            PlayPause();

        if(Input.GetKeyDown(KeyCode.RightArrow))
            NextTrack();

        if(Input.GetKeyDown(KeyCode.LeftArrow))
            PreviousTrack();

        UpdateUI();
    }

    void PlayTrack(int index)
    {
        if(index < 0 || index >= playlist.Length) return;

        audioSource.clip = playlist[index];
        audioSource.Play();
    }

    void PlayPause()
    {
        if(audioSource.isPlaying)
            audioSource.Pause();
        else
        {
            if(audioSource.clip == null && playlist.Length > 0)
                audioSource.clip = playlist[currentTrack];

            audioSource.Play();
        }
    }

    void NextTrack()
    {
        if (playlist.Length == 0) return;

        currentTrack = (currentTrack + 1) % playlist.Length;
        PlayTrack(currentTrack);
    }

    void PreviousTrack()
    {
        if (playlist.Length == 0) return;

        currentTrack--;
        if(currentTrack < 0) currentTrack = playlist.Length - 1;
        PlayTrack(currentTrack);
    }

    void UpdateUI()
    {
        if(trackInfo != null)
        {
            if (playlist.Length > 0 && audioSource.clip != null)
                trackInfo.text = $"Track: {playlist[currentTrack].name}\nTime: {audioSource.time:F1}s";
            else
                trackInfo.text = "No track playing";
        }
    }
}
