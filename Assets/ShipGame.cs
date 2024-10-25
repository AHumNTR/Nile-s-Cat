using System.Collections.Generic;
using UnityEngine;

public class ShipGame : MonoBehaviour
{
    public List<Ship> ships;
    public int shipIndex=0;
    int shipPartIndex=0;
    public float moveSpeed=1;
    
    private void Start() {
        ships[shipIndex].gameObject.SetActive(true);
        ships[shipIndex].shipParts[0].GetComponent<SpriteRenderer>().enabled=true;
    }
    void Update()
    {
        ships[shipIndex].shipParts[shipPartIndex].transform.position+=Vector3.right*moveSpeed*Time.deltaTime;
        if(ships[shipIndex].shipParts[shipPartIndex].transform.position.x>5||ships[shipIndex].shipParts[shipPartIndex].transform.position.x<-5)moveSpeed*=-1;
        if(Input.GetButtonDown("Jump")){
            ships[shipIndex].shipParts[shipPartIndex].GetComponent<Rigidbody2D>().simulated=true;
            if(shipPartIndex+1<ships[shipIndex].shipParts.Count){
                shipPartIndex++;
                ships[shipIndex].shipParts[shipPartIndex].GetComponent<SpriteRenderer>().enabled=true;
            }
        }
    }
}
