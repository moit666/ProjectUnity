using UnityEngine;

public class Record : MonoBehaviour, IInteractable
{
    public AudioClip clip; 

    public string GetDescription()
    {
        return "take Music";
    }

    public void Interact()
    {
        MP3Player player = FindObjectOfType<MP3Player>();
        if (player != null)
        {
            player.AddTrack(clip);
            Destroy(gameObject);
        }

    }

}





