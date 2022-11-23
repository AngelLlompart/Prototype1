using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI txtWin;
    [SerializeField] private TextMeshProUGUI txtTime;
    [SerializeField] private TextMeshProUGUI hpValue;
    [SerializeField] private TextMeshProUGUI txtPoints;
    [SerializeField] private Button btnOk;
    private GameObject _player;
    private int hp = 100;
    private int points = 0;
    private int time = 120;

    private bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        txtWin.gameObject.SetActive(false);
        btnOk.gameObject.SetActive(false);
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int dmgAmount)
    {
        hp -= dmgAmount;
        ShowLife();
        if (hp == 0)
        {
            Destroy(_player);
            Destroy(FindObjectOfType<CameraFollow>());
            win = false;
            EndLevel("You died!");
        }
    }

    private void ShowLife()
    {
        healthBar.value = hp;
        hpValue.text = hp + "%";
        if (hp < 50)
        {
            healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;
        }
        else
        {
            healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green;
        }
    }

    private void EndLevel(String message)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        txtWin.text = message;
        txtWin.gameObject.SetActive(true);
        btnOk.gameObject.SetActive(true);
    }
}
