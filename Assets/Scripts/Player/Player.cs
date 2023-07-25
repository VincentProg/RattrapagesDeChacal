using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<Player> Death;
    public event Action Wind;
    public event Action Score;
    public Rigidbody2D rigidBody { get; private set; }
    public Collider col { get; private set; }
    public Renderer rend { get; private set; }

    private PlayerCollision m_playerCollision;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
        m_playerCollision = GetComponent<PlayerCollision>();
        m_playerCollision.Death += OnDeath;
        m_playerCollision.WindItem += OnWind;
        m_playerCollision.Score += OnScore;
    }

    private void OnDestroy()
    {
        m_playerCollision.Death -= OnDeath;
        m_playerCollision.WindItem -= OnWind;
        m_playerCollision.Score -= OnScore;
    }

    private void OnDeath()
    {
        Death?.Invoke(this);
        this.enabled = false;
    }

    private void OnWind()
    {
        Wind?.Invoke();
    }

    private void OnScore()
    {
        Score?.Invoke();
    }

}
