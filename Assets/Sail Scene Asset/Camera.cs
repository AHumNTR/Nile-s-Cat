using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform ship;
    private Vector3 newVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per 
    void Update()
    {
        newVector = new Vector3(0, 3.69f + ship.transform.position.y, -10f);
        transform.position = newVector;

        transform.rotation = Quaternion.Euler(0,0,0);   
    }
}