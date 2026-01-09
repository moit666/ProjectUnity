using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWITCH_lamps : MonoBehaviour, IInteractable
{
    public bool isOnLight;

    public List<GameObject> lamps = new List<GameObject>();

    public string GetDescription()
    {
        if (isOnLight)
            return "Press [E] to off";
        else
            return "Press [E] to on";
    }

    public void Interact()
    {
        isOnLight = !isOnLight;

        foreach (GameObject lamp in lamps)
        {
            lamp.SetActive(isOnLight);
            GameManager.Instance.LightOff = true;
        }
    }
}
