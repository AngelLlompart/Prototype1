using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveGoal : MonoBehaviour
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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
           _gameManager.ArriveGoal();
        }
    }
}
