using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ShipGame : MonoBehaviour
{
    public FadeScene fadeScene;
    public TextMeshProUGUI scoreText;
    public List<Ship> ships;
    public int shipIndex=0;
    int shipPartIndex=0;
    public float moveSpeed=1;
    float Points;
    
    private void Start() {
        shipIndex=GameData.day;
        ships[shipIndex].gameObject.SetActive(true);
        ships[shipIndex].shipParts[0].GetComponent<SpriteRenderer>().enabled=true;
    }
    public float calculatePoints(){
        return (1-Mathf.Abs(ships[shipIndex].shipParts[shipPartIndex].transform.position.x-ships[shipIndex].shipParts[shipPartIndex-1].transform.position.x)/3)/(ships[shipIndex].shipParts.Count-1);
    }   
    void Update()
    {
        ships[shipIndex].shipParts[shipPartIndex].transform.position+=Vector3.right*moveSpeed*Time.deltaTime;
        if(ships[shipIndex].shipParts[shipPartIndex].transform.position.x>5||ships[shipIndex].shipParts[shipPartIndex].transform.position.x<-5)moveSpeed*=-1;
        if(Input.GetButtonDown("Jump")){
            if(shipPartIndex>0){
                Points+=calculatePoints();
                scoreText.text=Points.ToString();
            }
            ships[shipIndex].shipParts[shipPartIndex].GetComponent<Rigidbody2D>().simulated=true;
            if(shipPartIndex+1<ships[shipIndex].shipParts.Count){
                shipPartIndex++;
                ships[shipIndex].shipParts[shipPartIndex].GetComponent<SpriteRenderer>().enabled=true;
            }
            else{
                enabled=false;
                GameData.shipCondition=Points;
                fadeScene.fadeInText(2);
                Invoke("loadSailingScene",5);
            }
        }
    }
    void loadSailingScene(){
        SceneManager.LoadScene("SailingScene");
    }
}
