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
        shipImage.sprite=shipSprites[GameData.day];
        shipImage.color=GameData.mixtureColor;
    }
    
    public void refuse(){
        Invoke("resetRun",4);
    }
    public void resetRun(){
        GameData.day=0;
        SceneManager.LoadScene("GameOver");
    }
    public void accept(){
        SceneManager.LoadScene("MaterialScene");
    }
    void Start()
    {
        customerImage.sprite=customerSprites[GameData.day];
        shipImage.sprite=shipSprites[GameData.day];
    }
}
