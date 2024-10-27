using System;
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
        // timeText.text = $"{(int)timeInSeconds}";
        timeText.text = $"{(int)timeInSeconds}" + ":" + Convert.ToString(100f*((Mathf.Round(timeInSeconds * 100f) / 100f) - (int)(timeInSeconds)));
        if (timeInSeconds <= 0)
        {
            if (_cauldrons[0].gameObject.activeSelf )
            {
                if(!_cauldrons[0].isSuccess){
                    GameData.Durability -= GameData.WoodDurability * .1f;
                    _cauldrons[0].backGround.color= Color.red;
                }
                else{
                    _cauldrons[0].backGround.color= Color.green;
                }
            }
            
            if (_cauldrons[1].gameObject.activeSelf )
            {
                 if(!_cauldrons[1].isSuccess){
                    GameData.Durability -= GameData.IronDurability * .1f;
                    _cauldrons[1].backGround.color= Color.red;
                 }
                 else{
                     _cauldrons[1].backGround.color= Color.green;
                 }
            }
            
            if (_cauldrons[2].gameObject.activeSelf)
            {
                if(!_cauldrons[2].isSuccess){
                    GameData.Durability -= GameData.CrystalDurability * .1f;
                    _cauldrons[2].backGround.color= Color.red;
                }
                else{
                    _cauldrons[2].backGround.color= Color.green;
                }
            }
            enabled=false;
            Invoke(nameof(NextScene),3);
        }
    }

    private void NextScene()
    {
        if (_cauldrons[0].gameObject.activeSelf && !_cauldrons[0].isSuccess)
        {
            GameData.Durability -= GameData.WoodDurability * .1f;
        }
        
        if (_cauldrons[1].gameObject.activeSelf && !_cauldrons[1].isSuccess)
        {
            GameData.Durability -= GameData.IronDurability * .1f;
        }
        
        if (_cauldrons[2].gameObject.activeSelf && !_cauldrons[2].isSuccess)
        {
            GameData.Durability -= GameData.CrystalDurability * .1f;
        }

        SceneManager.LoadScene("ShipBuildingScene");
    }
}
