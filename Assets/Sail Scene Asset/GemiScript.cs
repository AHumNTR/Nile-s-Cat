using UnityEngine;

public class GemiScript : MonoBehaviour
{

    public float forwardSpeed ;
    private float steerCoefficent;
    private float baseTurnSpeed = 10f;
    private float turnSpeed;

    private Rigidbody2D rb;
    private bool shipStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // calculating steer coefficent
    }

    public void StartShip()
    {
        Debug.Log("gemi başladı");
        shipStarted = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shipStarted)
        {
            rb.linearVelocity = transform.up * forwardSpeed;

            float horizontalInput = Input.GetAxis("Horizontal");

            float rotationAmount = -horizontalInput * turnSpeed * Time.deltaTime;

            rb.MoveRotation(rb.rotation + rotationAmount);
        }
    }
}
