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

    }

}
