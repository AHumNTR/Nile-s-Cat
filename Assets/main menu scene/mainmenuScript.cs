using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("CustomerScene");
        AudioManager.Instance.StopMusic();
    }

    public void QuitButtonPressed()
    {
        AudioManager.Instance.StopMusic();
        Application.Quit();
    }
}
