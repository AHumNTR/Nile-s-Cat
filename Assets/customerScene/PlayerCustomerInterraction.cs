using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCustomerInterraction : MonoBehaviour
{
    public List<Sprite> shipSprites;
    Animator anim;
    SpriteRenderer image;
    public void askForAShip(){
        GameData.mixtureColor=Random.ColorHSV(0,1,0,1,0,1,1,1);
        image.sprite=shipSprites[GameData.day];
        image.color=GameData.mixtureColor;
    }
   
    void Start()
    {
        image=GetComponentsInChildren<SpriteRenderer>()[1];
        print(image.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
