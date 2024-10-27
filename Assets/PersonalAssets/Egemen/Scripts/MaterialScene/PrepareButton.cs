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
    public void OnPrepareButtonPressed()
    {
        // if (totalDurabilityToChange == 0 || Scheme.Instance.mainSchemeImage.sprite == null ||
        //     !CheckValuesForShip1() || !CheckValuesForShip2() || !CheckValuesForShip3()) return;

        switch (GameData.Day)
        {
            case 0 when totalDurabilityToChange != 0 && Scheme.Instance.mainSchemeImage.sprite != null &&
                        CheckValuesForShip1():
                GameData.Durability = totalDurabilityToChange * .1f;
                Debug.Log(totalDurabilityToChange);

                SceneManager.LoadScene($"{sceneToGo}");
                break;
            case 1 when totalDurabilityToChange != 0 && Scheme.Instance.mainSchemeImage.sprite != null &&
                        CheckValuesForShip1():
                GameData.Durability = totalDurabilityToChange * .1f;
                Debug.Log(totalDurabilityToChange);

                SceneManager.LoadScene($"{sceneToGo}");
                break;
            case 2 when totalDurabilityToChange != 0 && Scheme.Instance.mainSchemeImage.sprite != null &&
                        CheckValuesForShip1():
                GameData.Durability = totalDurabilityToChange * .1f;
                Debug.Log(totalDurabilityToChange);

                SceneManager.LoadScene($"{sceneToGo}");
                break;
        }
    }
}
