using TMPro;
using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.SceneManagement;


public class GemiScript : MonoBehaviour
{

    public float maxCollision = 3;

    public float forwardSpeed;
    public float safeCollisionTime;
    private int noCollisions;
    private float collisionElapsedTime = 0f;
    private float baseTurnSpeed = 10.5f;
    private float turnSpeed;
    private float deceleration = 1;


    public GameObject timer;
    public GameObject MainCamera;
    public TextMeshProUGUI text;
    private Rigidbody2D rb;
    public bool shipStarted = false;
    public bool shipStopped = false;
    public bool startTimer = false;
    public bool nextLevelCalled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        turnSpeed = baseTurnSpeed;
        calculateSteering();
    }

    public void StartShip()
    {
        Debug.Log("gemi başladı");
        StartCoroutine(StartShipSmoothly(forwardSpeed ,1f));
        startTimer = true;

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

            if (horizontalInput != 0)
            {
                rb.MoveRotation(rb.rotation + rotationAmount);
            }
            else
            {
                float newRotation = Mathf.Lerp(rb.rotation, 0, turnSpeed/4 * Time.deltaTime);
                rb.MoveRotation(newRotation);
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        noCollisions +=1;
        text.GetComponent<CounterScript>().updateCount(noCollisions);
        Debug.Log("number of collisions increased to: " + noCollisions);

        if (noCollisions >= maxCollision)
        {
            StopShip();
            timer.GetComponent<TimerScript>().gameOverCalled = true;
            Debug.Log("game over cause collision");
            return;
        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        //collisionElapsedTime += Time.deltaTime;

        if (collisionElapsedTime > safeCollisionTime)
        {
            StopShip();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("collision is over");
        collisionElapsedTime = 0f;
    }

    public void StopShip()
    {
        Debug.Log("gemi durdu");
        shipStarted = false;
        rb.linearVelocity = new Vector2(rb.linearVelocityX, Mathf.Lerp(rb.linearVelocityY, 0, deceleration * Time.deltaTime)); 
        rb.linearVelocity = Vector2.zero;
        MainCamera.GetComponent<CameraScript>().slideOff();
        shipStopped = true;
    }

    public void GameOver()
    {
        // Play Animation

        SceneManager.LoadScene("GameOver");
    }

    public void nextLevel()
    {
        nextLevelCalled = true;

        GameData.day++;
        SceneManager.LoadScene("CustomerScene");
    }

    private void calculateSteering()
    {
        float shipCondition = GameData.shipCondition;

        if (shipCondition < 0.5f)
        {
            turnSpeed = baseTurnSpeed;
            return;
        }

        if (shipCondition < 0.75f)
        {
            turnSpeed = baseTurnSpeed + 2f * shipCondition;
            return;
        }

        turnSpeed = baseTurnSpeed + 4.5f * shipCondition;
    }

    private IEnumerator StartShipSmoothly(float targetSpeed, float accelerationTime)
    {
        float currentSpeed = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < accelerationTime)
        {
            elapsedTime += Time.deltaTime;
            currentSpeed = Mathf.Lerp(0f, targetSpeed, elapsedTime / accelerationTime); 
            rb.linearVelocity = transform.up * currentSpeed;
            yield return null; 
        }

        rb.linearVelocity = transform.up * targetSpeed;
        shipStarted = true;
    }

    public void addWindForce(int direction, float amount)
    {
       Vector2 windForce = new Vector2(direction * amount, 0);
       rb.AddForce(windForce);
    }


}
