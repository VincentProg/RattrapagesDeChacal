using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<Player> Death;
    public Rigidbody rigidBody { get; private set; }
    public Collider col { get; private set; }
    public Renderer rend { get; private set; }

    private PlayerCollision m_playerCollision;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
        m_playerCollision = GetComponent<PlayerCollision>();
        m_playerCollision.Death += OnDeath;
    }

    private void OnDeath()
    {
        Death?.Invoke(this);
        this.enabled = false;
    }

}
