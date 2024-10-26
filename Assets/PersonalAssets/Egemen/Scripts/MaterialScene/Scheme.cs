using System;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class Scheme : MonoBehaviour
{
    [SerializeField] private Image mainSchemeImage;
    
    private Button[] _schemeSelectButtons;

    private void Start()
    {
        _schemeSelectButtons = GetComponentsInChildren<Button>();
    }

    public void OnSchemeSelectButtonPressed(int index)
    {
        mainSchemeImage.sprite = _schemeSelectButtons[index].image.sprite;
        
        if (Mathf.Approximately(mainSchemeImage.color.a, 0))
        {
            var color = mainSchemeImage.color;
            color.a = 1;
            mainSchemeImage.color = color;
        }
    }
}
