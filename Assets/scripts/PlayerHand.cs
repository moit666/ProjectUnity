using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public GameObject mp3Player;  // рука с плеером
    public Animator handAnimator; // анимация руки
    private bool playerOut = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) // пример кнопки "достать"
        {
            ToggleMP3Player();
        }
    }

    void ToggleMP3Player()
    {
        playerOut = !playerOut;
        mp3Player.SetActive(playerOut);
        if(handAnimator != null)
            handAnimator.SetBool("HoldingMP3", playerOut);
    }
}
