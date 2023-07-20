using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponents : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody rigidBody;
    public Collider col;
    public Renderer rend;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
    }


}
