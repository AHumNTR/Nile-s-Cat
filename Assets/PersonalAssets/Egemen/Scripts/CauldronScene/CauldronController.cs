using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CauldronController : MonoBehaviour
{
    [SerializeField] private string sceneNameToGo;
    [SerializeField] private float timeInSeconds;
    [SerializeField] private TextMeshProUGUI timeText;
   
    
    private Cauldron[] _cauldrons;
    
    private void Start()
    {
        _cauldrons = GetComponentsInChildren<Cauldron>(true);

        if (GameData.IsWoodInCauldron)
        {
            _cauldrons[0].gameObject.SetActive(true);
        }
        if (GameData.IsIronInCauldron)
        {
            _cauldrons[1].gameObject.SetActive(true);
        }
        if (GameData.IsCrystalInCauldron)
        {
            _cauldrons[2].gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        timeInSeconds -= Time.deltaTime;
        timeText.text = $"{(int)timeInSeconds}";

        if (timeInSeconds <= 0)
        {
            NextScene(sceneNameToGo);
        }
    }

    private void NextScene(string sceneName)
    {
        if (_cauldrons[0].gameObject.activeSelf && !_cauldrons[0].isSuccess)
        {
            GameData.shipCondition -= GameData.WoodDurability * .1f;
        }
        
        if (_cauldrons[1].gameObject.activeSelf && !_cauldrons[1].isSuccess)
        {
            GameData.shipCondition -= GameData.IronDurability * .1f;
        }
        
        if (_cauldrons[2].gameObject.activeSelf && !_cauldrons[2].isSuccess)
        {
            GameData.shipCondition -= GameData.CrystalDurability * .1f;
        }

        SceneManager.LoadScene($"{sceneName}");
    }
}
