using UnityEngine;

public class ShipGameGround : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag!="FirstShipPart"){
            Debug.Log("sad");
        }
    }
}
