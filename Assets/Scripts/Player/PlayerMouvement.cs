using UnityEngine;
using System.Collections;

public class PlayerMouvement : MonoBehaviour
{
    private PlayerComponents myComponents;

    [SerializeField] private KeyCode keyLeft;
    [SerializeField] private KeyCode keyRight;
    // [SerializeField] private KeyCode keyDash;

    private bool isLeftPressed;
    private bool isRightPressed;

    [SerializeField] float accelerationSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float decelerationSpeed;

    private bool canMove = true;
    private bool canDash = true;
    // [SerializeField] float timeDash, speedDash, timeRecoverDash;
    //
    // [SerializeField] Material blue, blueIntense, blueWeak;

    // Start is called before the first frame update
    void Start()
    {
        myComponents = GetComponent<PlayerComponents>();
    }

    // Update is called once per frame
    void Update()
    {
        isLeftPressed = Input.GetKey(keyLeft);
        isRightPressed = Input.GetKey(keyRight);

        // if (Input.GetKeyDown(keyDash) && canDash)
        // {
        //     StartCoroutine(Dash());
        // }
    }

    private void FixedUpdate()
    {
        if (canMove)
            Move();
    }

    void Move()
    {
        Vector3 dir = Vector3.zero;
        if (isLeftPressed && !isRightPressed)
        {
            dir = Vector3.left;
        }
        else if (isRightPressed && !isLeftPressed)
        {
            dir = -Vector3.left;
        }

        if (dir != Vector3.zero)
        {
            myComponents.rigidBody.velocity += dir * (accelerationSpeed * Time.fixedDeltaTime);
            if (myComponents.rigidBody.velocity.magnitude > maxSpeed)
            {
                myComponents.rigidBody.velocity = Vector2.ClampMagnitude(myComponents.rigidBody.velocity, maxSpeed);
            }
        }
        else
        {
            if (myComponents.rigidBody.velocity.sqrMagnitude > 0.05f)
                myComponents.rigidBody.velocity *= decelerationSpeed;
            else myComponents.rigidBody.velocity = Vector3.zero;
        }
    }
    
    // IEnumerator Dash()
    // {
    //     print("dash");
    //     PlayerCollision playerCollision = GetComponent<PlayerCollision>();
    //     playerCollision.canDie = false;
    //     canMove = false;
    //     canDash = false;
    //     myComponents.rend.material = blueIntense;
    //     myComponents.rigidBody.velocity = GetMouseDirection() * speedDash;
    //     myComponents.col.isTrigger = true;
    //     yield return new WaitForSeconds(timeDash);
    //     myComponents.col.isTrigger = false;
    //     playerCollision.canDie = true;
    //     canMove = true;
    //     myComponents.rigidBody.velocity = Vector3.zero;
    //     myComponents.rend.material = blueWeak;
    //     yield return new WaitForSeconds(timeRecoverDash);
    //     myComponents.rend.material = blue;
    //     canDash = true;
    // }
}