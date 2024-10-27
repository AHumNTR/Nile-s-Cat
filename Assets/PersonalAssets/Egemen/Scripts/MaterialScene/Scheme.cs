using System;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class Scheme : MonoBehaviour
{
    #region Singleton

    public static Scheme Instance;
        
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
    
    public Image mainSchemeImage;
    
    public int selectedSchemeIndex = 3;
    
    private Button[] _schemeSelectButtons;

    private void Start()
    {
        _schemeSelectButtons = GetComponentsInChildren<Button>();

        for (var i = 0; i < _schemeSelectButtons.Length; i++)
        {
            if (i <= GameData.Day)
            {
                _schemeSelectButtons[i].image.color = Color.white;
            }
        }
    }

    public void OnSchemeSelectButtonPressed(int index)
    {
        AudioManager.Instance.PlayButtonSound(6);
        if (_schemeSelectButtons[index].image.color == Color.white)
        {
            // AlloyStatHandler.Instance.SetSliderValues(index);
            selectedSchemeIndex = index;
            mainSchemeImage.sprite = _schemeSelectButtons[index].image.sprite;
        
            if (Mathf.Approximately(mainSchemeImage.color.a, 0))
            {
                var color = mainSchemeImage.color;
                color.a = 1;
                mainSchemeImage.color = color;
            }
        }
    }
}
