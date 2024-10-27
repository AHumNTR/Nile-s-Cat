using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlloyStatHandler : MonoBehaviour
{
    #region Singleton

    public static AlloyStatHandler Instance;
        
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
    
    public Slider[] statSliders;

    private void Start()
    {
        statSliders = GetComponentsInChildren<Slider>();
    }

    private void Update()
    {
        SetSliderValues(Scheme.Instance.selectedSchemeIndex);
    }

    public void SetSliderValues(int schemeIndex)
    {
        switch (schemeIndex)
        {
            case 0:
                statSliders[0].maxValue = GameData.Ship1.NeededDurability;
                statSliders[0].value = PrepareButton.Instance.totalDurabilityToChange;
                statSliders[0].GetComponentInChildren<TextMeshProUGUI>().text =
                    $"{PrepareButton.Instance.totalDurabilityToChange} / {GameData.Ship1.NeededDurability}";
                
                statSliders[1].maxValue = GameData.Ship1.NeededSpeed;
                statSliders[1].value = PrepareButton.Instance.totalSpeedToChange;
                statSliders[1].GetComponentInChildren<TextMeshProUGUI>().text =
                    $"{PrepareButton.Instance.totalSpeedToChange} / {GameData.Ship1.NeededSpeed}";
                
                statSliders[2].maxValue = GameData.Ship1.NeededWeight;
                statSliders[2].value = PrepareButton.Instance.totalWeightToChange;
                statSliders[2].GetComponentInChildren<TextMeshProUGUI>().text =
                    $"{PrepareButton.Instance.totalWeightToChange} / {GameData.Ship1.NeededWeight}";
                break;
            case 1:
                statSliders[0].maxValue = GameData.Ship2.NeededDurability;
                statSliders[0].value = PrepareButton.Instance.totalDurabilityToChange;
                statSliders[0].GetComponentInChildren<TextMeshProUGUI>().text =
                    $"{PrepareButton.Instance.totalDurabilityToChange} / {GameData.Ship2.NeededDurability}";
                
                statSliders[1].maxValue = GameData.Ship2.NeededSpeed;
                statSliders[1].value = PrepareButton.Instance.totalSpeedToChange;
                statSliders[1].GetComponentInChildren<TextMeshProUGUI>().text =
                    $"{PrepareButton.Instance.totalSpeedToChange} / {GameData.Ship2.NeededSpeed}";
                
                statSliders[2].maxValue = GameData.Ship2.NeededWeight;
                statSliders[2].value = PrepareButton.Instance.totalWeightToChange;
                statSliders[2].GetComponentInChildren<TextMeshProUGUI>().text =
                    $"{PrepareButton.Instance.totalWeightToChange} / {GameData.Ship2.NeededWeight}";
                break;
            case 2:
                statSliders[0].maxValue = GameData.Ship3.NeededDurability;
                statSliders[0].value = PrepareButton.Instance.totalDurabilityToChange;
                statSliders[0].GetComponentInChildren<TextMeshProUGUI>().text =
                    $"{PrepareButton.Instance.totalDurabilityToChange} / {GameData.Ship3.NeededDurability}";
                
                statSliders[1].maxValue = GameData.Ship3.NeededSpeed;
                statSliders[1].value = PrepareButton.Instance.totalSpeedToChange;
                statSliders[1].GetComponentInChildren<TextMeshProUGUI>().text =
                    $"{PrepareButton.Instance.totalSpeedToChange} / {GameData.Ship3.NeededSpeed}";
                
                statSliders[2].maxValue = GameData.Ship3.NeededWeight;
                statSliders[2].value = PrepareButton.Instance.totalWeightToChange;
                statSliders[2].GetComponentInChildren<TextMeshProUGUI>().text =
                    $"{PrepareButton.Instance.totalWeightToChange} / {GameData.Ship3.NeededWeight}";
                break;
        }
    }
}
