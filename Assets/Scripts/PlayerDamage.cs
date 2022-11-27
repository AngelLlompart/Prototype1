using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _gameManager.Damage(10);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            _gameManager.Damage(20);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            _gameManager.Damage(30);
        }
    }
}
