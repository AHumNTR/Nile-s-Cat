using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipGameGround : MonoBehaviour
{
    public bool allowForFirstPart;
    public FadeText fadeText;
    private void OnCollisionEnter2D(Collision2D other) {
        if(!allowForFirstPart){
            Invoke("loadGameOverScene",1);
        }
        if(other.transform.tag!="FirstShipPart"){

            GameData.Day=0;
            Invoke("loadGameOverScene",1);
        }
    }
    void loadGameOverScene(){
        Reincarnate.deathMessage="You failed to assemble the ship";
        SceneManager.LoadScene("GameOver");
    }
}
