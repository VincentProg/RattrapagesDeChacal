using UnityEngine;
using System.Collections;

public class PlayerMouvement : MonoBehaviour
{
    
    private PlayerComponents myComponents;

    [SerializeField]
    private KeyCode keyDash;

    private bool isMousePressed;

    [SerializeField] float accelerationSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float decelerationSpeed;

    private bool canMove = true;
    private bool canDash = true;
    [SerializeField] float timeDash, speedDash, timeRecoverDash;

    [SerializeField] Material blue, blueIntense, blueWeak;

    // Start is called before the first frame update
    void Start()
    {
        myComponents = GetComponent<PlayerComponents>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMousePressed = true;
        } else if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
        }

        if (Input.GetKeyDown(keyDash) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if(canMove)
        Move();
        GetMouseDirection();
    }

    void Move()
    {


        switch (isMousePressed)
        {
            case true: // MOUSE IS PRESSED

                Vector3 dir = GetMouseDirection(); 
                myComponents.rigidBody.velocity += dir.normalized * accelerationSpeed * Time.fixedDeltaTime;
                if (myComponents.rigidBody.velocity.magnitude > maxSpeed)
                {
                    myComponents.rigidBody.velocity = Vector2.ClampMagnitude(myComponents.rigidBody.velocity, maxSpeed);
                }
                break;

            case false: // MOUSE IS NOT PRESSED

                if (myComponents.rigidBody.velocity.magnitude > 0.1f)
                    myComponents.rigidBody.velocity -= myComponents.rigidBody.velocity.normalized * decelerationSpeed * Time.fixedDeltaTime;
                else myComponents.rigidBody.velocity = Vector2.zero;
                break;
        }


    }

    Vector3 GetMouseDirection()
    {

        Vector3 mousePosition = Input.mousePosition + new Vector3(0,0, -Camera.main.transform.position.z);
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = (mouseWorldPos - transform.position).normalized;

        return direction;
    }


    IEnumerator Dash()
    {
        print("dash");
        PlayerCollision playerCollision = GetComponent<PlayerCollision>();
        playerCollision.canDie = false;
        canMove = false;
        canDash = false;
        myComponents.rend.material = blueIntense;
        myComponents.rigidBody.velocity = GetMouseDirection() * speedDash;
        myComponents.col.isTrigger = true;
        yield return new WaitForSeconds(timeDash);
        myComponents.col.isTrigger = false;
        playerCollision.canDie = true;
        canMove = true;
        myComponents.rigidBody.velocity = Vector3.zero;
        myComponents.rend.material = blueWeak;
        yield return new WaitForSeconds(timeRecoverDash);
        myComponents.rend.material = blue;
        canDash = true;

    }
}
