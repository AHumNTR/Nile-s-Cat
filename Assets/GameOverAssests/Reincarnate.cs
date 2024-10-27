using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reincarnate : MonoBehaviour
{ 
    public static string deathMessage;
    public TextMeshProUGUI deathText;
    public void restartGame()
    {
        GameData.Day = 0;
        SceneManager.LoadScene("StartMenu");
    }
    private void Start() {
        deathText.text=deathMessage;
    }
}
