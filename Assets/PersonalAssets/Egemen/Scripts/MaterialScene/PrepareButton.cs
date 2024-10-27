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
        if (totalDurabilityToChange == 0 || Scheme.Instance.mainSchemeImage.sprite == null) return;
        
        GameData.shipCondition = totalDurabilityToChange * .1f;
        Debug.Log(totalDurabilityToChange);

        SceneManager.LoadScene($"{sceneToGo}");
    }
}
