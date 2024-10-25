using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipGameGround : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag!="FirstShipPart"){
            GameData.day=0;
            GameData.money=0;
            GameData.shipCondition=0;
            SceneManager.LoadScene("CustomerScene");
        }
    }
}
