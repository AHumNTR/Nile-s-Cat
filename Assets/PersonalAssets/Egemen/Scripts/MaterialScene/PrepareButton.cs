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
    public int totalSpeedToChange;
    public int totalWeightToChange;
    
    [SerializeField] private string sceneToGo;

    public bool CheckValuesForShip1()
    {
        return totalDurabilityToChange == GameData.Ship1.NeededDurability && 
               totalSpeedToChange == GameData.Ship1.NeededSpeed && totalWeightToChange == GameData.Ship1.NeededWeight;
    }
    public bool CheckValuesForShip2()
    {
        return totalDurabilityToChange == GameData.Ship2.NeededDurability && 
               totalSpeedToChange == GameData.Ship2.NeededSpeed && totalWeightToChange == GameData.Ship2.NeededWeight;
    }
    public bool CheckValuesForShip3()
    {
        return totalDurabilityToChange == GameData.Ship3.NeededDurability && 
               totalSpeedToChange == GameData.Ship3.NeededSpeed && totalWeightToChange == GameData.Ship3.NeededWeight;
    }

    private void SetValuesForGameData()
    {
        GameData.Durability = totalDurabilityToChange;
        GameData.Speed = totalSpeedToChange;
        GameData.Weight = totalDurabilityToChange;
    }
    public void OnPrepareButtonPressed()
    {
        AudioManager.Instance.PlayButtonSound(0);
        switch (Scheme.Instance.selectedSchemeIndex)
        {
            case 0 when totalDurabilityToChange != 0 && Scheme.Instance.mainSchemeImage.sprite != null &&
                        CheckValuesForShip1():
                
                SetValuesForGameData();
                Debug.Log(totalDurabilityToChange);
                GameData.selectedShip=0;
                SceneManager.LoadScene($"{sceneToGo}");
                break;
            case 1 when totalDurabilityToChange != 0 && Scheme.Instance.mainSchemeImage.sprite != null &&
                        CheckValuesForShip2():
                
                SetValuesForGameData();
                GameData.selectedShip=1;
                Debug.Log(totalDurabilityToChange);

                SceneManager.LoadScene($"{sceneToGo}");
                break;
            case 2 when totalDurabilityToChange != 0 && Scheme.Instance.mainSchemeImage.sprite != null &&
                        CheckValuesForShip3():
                
                SetValuesForGameData();
                GameData.selectedShip=2;
                Debug.Log(totalDurabilityToChange);

                SceneManager.LoadScene($"{sceneToGo}");
                break;
        }
    }
}
