using UnityEngine;
using UnityEngine.SceneManagement;

public class Reincarnate : MonoBehaviour
{ 
    public void restartGame()
    {
        GameData.Day = 0;
        SceneManager.LoadScene("StartMenu");
    }
}
