using UnityEngine;
using UnityEngine.UI;

public class HealthShipFollow : MonoBehaviour
{
    public Transform targetObject;   
    public Vector3 offset;           
    public Slider healthSlider;      
    public Camera mainCamera;        
    private void Start()
    {
        if (!mainCamera) mainCamera = Camera.main;
    }

    private void Update()
    {
        if (targetObject != null)
        {
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(targetObject.position + offset);
            transform.position = screenPosition;
        }
    }

    public void SetHealth(float health, float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

}
