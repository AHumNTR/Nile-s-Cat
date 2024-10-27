using UnityEngine;
using UnityEngine.SceneManagement;

public class Reincarnate : MonoBehaviour
{ 
    public void restartGame()
    {
        GameData.day = 0;
        SceneManager.LoadScene("StartMenu");
    }
}
