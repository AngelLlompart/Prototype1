using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private TextMeshProUGUI txtTime;
    private int _time = 120;
    public float timer;
    private int _ogTimer;
    private int timeFrequenccy = 1;
    void Start()
    {
        timer = _time;
        _ogTimer = _time;
        _gameManager = FindObjectOfType<GameManager>();
        txtTime.text = "Time: " + _ogTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= _ogTimer - timeFrequenccy)
        {
            _ogTimer -= timeFrequenccy;
            txtTime.text = "Time: " + _ogTimer;
        }

        if (timer <= 0)
        {
            _gameManager.EndTime();
        }
    }
}
