using UnityEngine;
using UnityEngine.SceneManagement;

public class PrepareButton : MonoBehaviour
{
    #region Singleton

    public static PrepareButton Instance;
        
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
    
    [HideInInspector]
    public int totalDurabilityToChange;
    
    [SerializeField] private string sceneToGo;
    
    public void OnPrepareButtonPressed()
    {
        GameData.shipCondition = totalDurabilityToChange;
        Debug.Log(totalDurabilityToChange);

        SceneManager.LoadScene($"ShipBuildiingScene");
    }
}
