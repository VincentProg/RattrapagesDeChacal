using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    // Update is called once per frame
    private void OnEnable()
    {
        rb.velocity = new Vector3(0, -MapManager.instance.speedMaps, 0);
    }
    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
    }
}
