using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI txtWin;
    
    [SerializeField] private TextMeshProUGUI hpValue;
    [SerializeField] private TextMeshProUGUI txtPoints;
    [SerializeField] private Button btnOk;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button btnResume;
    [SerializeField] private Button btnSave;
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnMenu;
    [SerializeField] private Button btnQuit;
    [SerializeField] private Button btnYes;
    [SerializeField] private Button btnNo;
    private GameObject _player;
    private Timer _timer;
    private int hp = 100;
    private int points = 0;

    private bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        btnOk.onClick.AddListener(GameOver);
        btnResume.onClick.AddListener(ResumeGame);
        btnRestart.onClick.AddListener(RestartLevel);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        txtWin.gameObject.SetActive(false);
        btnOk.gameObject.SetActive(false);
        _player = GameObject.FindWithTag("Player");
        _timer = FindObjectOfType<Timer>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void Damage(int dmgAmount)
    {
        hp -= dmgAmount;
        ShowLife();
        if (hp <= 0)
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
        if (hp <= 0)
        {
            hpValue.text = 0 + "%";  
        }
        else
        {
            hpValue.text = hp + "%";  
        }
        if (hp < 50)
        {
            healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;
        }
        else
        {
            healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green;
        }
    }

    private void PauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
        pauseMenu.gameObject.SetActive(true);
    }
    
    private void ResumeGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene("Level1");
    }
    public void EndTime()
    {
        win = false;
        EndLevel("Time has ended!");
    }

    
    public void ArriveGoal()
    {
        win = true;
        //Debug.Log(hp/100f);
        
        //total of 800 points, 400 depending on hp%, and 400 depending on time
        //if time is less than 100, for every 10 seconds 40 points are rested, when time is less than 10, 0 points are gotten
        points = (int) (400 * (hp / 100f)) + 400;
        if (_timer.timer < 100)
        {
            //Debug.Log(40 * Math.Ceiling((100 - _timer)/10f));
            points -= (int) (40 * Math.Ceiling((100 - _timer.timer)/10f));
        }
        //Debug.Log(points);
        txtPoints.text = "Points: " + points;
        EndLevel("Congratulations, go to next level.");
    }
    private void EndLevel(String message)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        txtWin.text = message;
        txtWin.gameObject.SetActive(true);
        btnOk.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
