using System;
using UnityEngine;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    public bool isSuccess;
    
    [SerializeField] private float flamePower;
    [SerializeField] private float minFlame;
    [SerializeField] private float maxFlame;
    
    private Slider _fireSlider;
    public Image backGround;

    private void Start()
    {
        _fireSlider = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        _fireSlider.value -= flamePower * .8f * Time.deltaTime;

        isSuccess = _fireSlider.value < maxFlame && _fireSlider.value > minFlame;
    }

    public void OnFireButtonPressed()
    {
        _fireSlider.value += flamePower;
    }
    
    
}
