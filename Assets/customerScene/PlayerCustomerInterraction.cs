using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCustomerInterraction : MonoBehaviour
{
    public List<Sprite> shipSprites,customerSprites;
    Animator anim;
<<<<<<< HEAD
    SpriteRenderer image;
    public void askForAShip(){
        GameData.mixtureColor=Random.ColorHSV(0,1,0,1,0,1,1,1);
        image.sprite=shipSprites[GameData.day];
        image.color=GameData.mixtureColor;
=======
    public SpriteRenderer customerImage,shipImage;
    public void refuse(){
        Invoke("resetRun",4);
    }
    void resetRun(){
        GameData.day=0;
        SceneManager.LoadScene("CustomerScene");
    }
    public void accept(){
        SceneManager.LoadScene("MaterialScene(Egemen)");
>>>>>>> humus/shipbuilding
    }
    void Start()
    {
        customerImage.sprite=customerSprites[GameData.day];
        shipImage.sprite=shipSprites[GameData.day];
    }
}
