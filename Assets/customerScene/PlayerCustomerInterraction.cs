using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCustomerInterraction : MonoBehaviour
{
    public List<Sprite> shipSprites,customerSprites;
    Animator anim;
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
    }
    void Start()
    {
        customerImage.sprite=customerSprites[GameData.day];
        shipImage.sprite=shipSprites[GameData.day];
    }
}
