using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public bool LightOff;
    public bool TakePlayer;
    public bool Seadiary;



    public bool keyMessageShown = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    void Update()
    {
  
        if (LightOff & TakePlayer   && !keyMessageShown)
        {
            DialogueManager.instance.ShowMessage("Всё, теперь могу пописать дневник...");
            keyMessageShown = true;
        }

    }
}