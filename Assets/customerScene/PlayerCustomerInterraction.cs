using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCustomerInterraction : MonoBehaviour
{
    public List<Sprite> shipSprites,customerSprites;
    Animator anim;
    public SpriteRenderer customerImage,shipImage;
    public void askForAShip(){
        GameData.mixtureColor=Random.ColorHSV(0,1,0,1,0,1,1,1);
        shipImage.sprite=shipSprites[GameData.Day];
        shipImage.color=GameData.mixtureColor;
    }
    
    public void refuse(){
        Invoke("resetRun",4);
        AudioManager.Instance.PlayButtonSound(0);
    }
    public void resetRun(){
        GameData.Day=0;
        Reincarnate.deathMessage="You can't just simply refuse gods";
        SceneManager.LoadScene("GameOver");
    }
    public void accept()
    {
        AudioManager.Instance.PlayButtonSound(0);
        SceneManager.LoadScene("MaterialScene");
    }
    void Start()
    {
        customerImage.sprite=customerSprites[GameData.Day];
        shipImage.sprite=shipSprites[GameData.Day];
        AudioManager.Instance.PlaySoundEffect(1);
        AudioManager.Instance.PlayMusic(9);
    }
}
