using UnityEngine;
using System.Collections.Generic;

public class PlayerMouvementManager : MonoBehaviour
{
    [SerializeField] private KeyCode keyLeft;
    [SerializeField] private KeyCode keyRight;

    [SerializeField] float accelerationSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float decelerationSpeed;
    private bool canDash = true;

    private bool canMove = true;

    private bool isLeftPressed;
    private bool isRightPressed;

    public List<Rigidbody> m_rbs { get; private set; }

    void Awake()
    {
        m_rbs = new List<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isLeftPressed = Input.GetKey(keyLeft);
        isRightPressed = Input.GetKey(keyRight);
    }

    private void FixedUpdate()
    {
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

        foreach (Rigidbody l_rb in m_rbs)
        {
            if (dir != Vector3.zero)
            {
                l_rb.velocity += dir * (accelerationSpeed * Time.fixedDeltaTime);
                if (l_rb.velocity.magnitude > maxSpeed)
                {
                    l_rb.velocity = Vector2.ClampMagnitude(l_rb.velocity, maxSpeed);
                }
            }

            else
            {
                if (l_rb.velocity.sqrMagnitude > 0.05f)
                {
                    l_rb.velocity *= decelerationSpeed;
                }
                else
                {
                    l_rb.velocity = Vector3.zero;
                }
            }
        }
    }
}