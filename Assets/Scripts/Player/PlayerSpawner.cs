using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private PlayerManager m_manager;

    [SerializeField] private SpriteRenderer m_spriteSpawn;
    private Vector2 m_horizontalRange;
    private Vector2 m_verticalRange;
    private void Start()
    {
        Bounds l_bounds = m_spriteSpawn.bounds;
        m_horizontalRange = new Vector2(l_bounds.min.x, l_bounds.max.x);
        m_verticalRange = new Vector2(l_bounds.min.y, l_bounds.max.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomSpawn();
        }
    }

    private void RandomSpawn()
    {
        float randX = Random.Range(m_horizontalRange.x, m_horizontalRange.y);
        float randY = Random.Range(m_verticalRange.x, m_verticalRange.y);

        Vector3 l_pos = new Vector3(randX, randY);
        m_manager.AddPlayer(l_pos);
    }
}
