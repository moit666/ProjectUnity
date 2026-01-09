using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bad_Trigg : MonoBehaviour, IInteractable
{
    public GameObject _Player;
    public GameObject CameraCast;
    public GameObject _canvas;
    public GameObject Lamps;

    

    public string GetDescription()
    {
        return "Press [E] to Sleep";
    }

    public void Interact()
    {
        if(GameManager.Instance.LightOff == true & GameManager.Instance.TakePlayer == true & GameManager.Instance.Seadiary == true && !Lamps.activeSelf )
        {
            _Player.SetActive(false);
            CameraCast.SetActive(true);
            _canvas.SetActive(false);
        }else{
            DialogueManager.instance.ShowMessage("Надо доделать дела и выключить свет...");           
        }
    }
}
