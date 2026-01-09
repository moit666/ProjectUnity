using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pleer_item : MonoBehaviour, IInteractable
{
    public string GetDescription()
    {
        
        return "Press [E] to take";
    }
    
    public void Interact()
    {
        GameManager.Instance.TakePlayer = true;
        Destroy(gameObject);
    }
}
