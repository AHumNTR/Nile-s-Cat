using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ShipGame : MonoBehaviour
{
    public FadeScene fadeScene;
    public Transform ufoLight;
    public TextMeshProUGUI scoreText;
    public List<Ship> ships;
    public int shipIndex=0;
    int shipPartIndex=0;
    public float moveSpeed=1,penaltyScaling;
    float Points;
    public Vector2 ufoOffset;
    public FadeText perfectText, startInfoText;
    
    private void Start() {
        shipIndex=GameData.selectedShip;
        ships[shipIndex].gameObject.SetActive(true);
        ships[shipIndex].shipParts[0].GetComponent<SpriteRenderer>().enabled=true;
        startInfoText.fadeWaitThenOutText(2f,2f);
    }
    public float calculatePoints(){
        ShipPartConnectionPoint scp=ships[shipIndex].shipParts[shipPartIndex-1].GetComponent<ShipPartConnectionPoint>();
        return (1-penaltyScaling*Mathf.Abs(ships[shipIndex].shipParts[shipPartIndex].transform.position.x-scp.xOffset-ships[shipIndex].shipParts[shipPartIndex-1].transform.position.x))/(ships[shipIndex].shipParts.Count-1);
    }   
    void Update()
    {
        ships[shipIndex].shipParts[shipPartIndex].transform.position+=Vector3.right*moveSpeed*Time.deltaTime;
        ufoLight.transform.position=ships[shipIndex].shipParts[shipPartIndex].transform.position+(Vector3)ufoOffset;
        if(ships[shipIndex].shipParts[shipPartIndex].transform.position.x>5&&moveSpeed>0)moveSpeed*=-1;
        else if(ships[shipIndex].shipParts[shipPartIndex].transform.position.x<-5&& moveSpeed<0)moveSpeed*=-1;
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) {
            if(shipPartIndex>0){
                float pointsToAdd=calculatePoints();
                if(pointsToAdd>0.9/(ships[shipIndex].shipParts.Count-1)){
                    perfectText.fadeInThenOutText(2,2);
                    Points+=1.0f/(ships[shipIndex].shipParts.Count-1);
                }
                else Points+=calculatePoints();
                scoreText.text= "Score: " + (Mathf.Round(Points * 100) / 10 ).ToString();
            }
            ships[shipIndex].shipParts[shipPartIndex].GetComponent<Rigidbody2D>().simulated=true;
            if(shipPartIndex+1<ships[shipIndex].shipParts.Count){
                shipPartIndex++;
                ships[shipIndex].shipParts[shipPartIndex].GetComponent<SpriteRenderer>().enabled=true;
                ships[shipIndex].shipParts[shipPartIndex-1].transform.GetChild(0).gameObject.SetActive(true);
                if(shipPartIndex>1)ships[shipIndex].shipParts[shipPartIndex-2].transform.GetChild(0).gameObject.SetActive(false);
            }
            else{
                enabled=false;
                GameData.Steering = Points;


                ships[shipIndex].shipParts[shipPartIndex-1].transform.GetChild(0).gameObject.SetActive(false);
                
                Invoke("fadeSceneFunc",2);
                Invoke("loadSailingScene",5);
            }
        }
    }
    void fadeSceneFunc(){
        fadeScene.fadeInScene(1);
    }
    void loadSailingScene(){
        SceneManager.LoadScene("SailingScene");
    }
}
