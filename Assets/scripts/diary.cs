using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diary : MonoBehaviour, IInteractable
{
    public GameObject ListDiary;
    public GameObject _Kanvas;

    private bool IsList;
    private bool keyMessageShown1;
    
    public string GetDescription()
    {
        return "Sea to Diary";
    }
    
    public void Interact()
    {
        GameManager.Instance.Seadiary = true;
        ListDiary.SetActive(true);
        _Kanvas.SetActive(false);
        IsList = true;
        keyMessageShown1 = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ListDiary.activeSelf)
        {
            
            ListDiary.SetActive(false);
            _Kanvas.SetActive(true);
            IsList = false;
        }
        if(IsList & !keyMessageShown1)
        {
            DialogueManager.instance.ShowMessage("I'm not really in the mood to write anymore, I'd better go to bed...");
            keyMessageShown1 = true;
        }
        
    }
}


