using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboPickUp : MonoBehaviour
{
    private PlayerMovement _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _player.AddTurbo();
            Destroy(gameObject);
        }
    }
}
