using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
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
    [SerializeField] private GameObject secureBox;
    private GameObject _player;
    private Timer _timer;
    private bool _pause = false;
    private int hp = 100;
    private int points = 0;
    private bool _save = false;
    private bool _quit = false;
    public bool invAxis = false;

    private bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        _pause = false;
        _save = false;
        _quit = false;
        btnOk.onClick.AddListener(GameOver);
        btnResume.onClick.AddListener(ResumeGame);
        btnSave.onClick.AddListener(SaveGame);
        btnRestart.onClick.AddListener(RestartLevel);
        btnMenu.onClick.AddListener(MainMenu);
        btnQuit.onClick.AddListener(Quit);
        btnYes.onClick.AddListener(ComfirmExit);
        btnNo.onClick.AddListener(CancelExit);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        txtWin.gameObject.SetActive(false);
        btnOk.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        secureBox.gameObject.SetActive(false);
        _player = GameObject.FindWithTag("Player");
        _timer = FindObjectOfType<Timer>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start")) && _pause == false)
        {
            PauseGame();
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start")) && _pause == true)
        {
            ResumeGame();
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
        _pause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
        pauseMenu.gameObject.SetActive(true);
    }
    
    private void ResumeGame()
    {
        _pause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void SaveGame()
    {
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.Save();
        _save = true;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    private void MainMenu()
    {
        if (_save == false)
        {
            secureBox.SetActive(true);
            _quit = false;
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    
    private void Quit()
    {
        if (_save == false)
        {
            secureBox.SetActive(true);
            _quit = true;
        }
        else
        {
            #if UNITY_EDITOR
                if(EditorApplication.isPlaying) 
                {
                    UnityEditor.EditorApplication.isPlaying = false;
                }
            #else
                Application.Quit();
            #endif
        }
    }

    private void ComfirmExit()
    {
        if (_quit)
        {
        #if UNITY_EDITOR
            if(EditorApplication.isPlaying) 
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        #else
            Application.Quit();
        #endif
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
        secureBox.SetActive(false);
    }

    private void CancelExit()
    {
        secureBox.SetActive(false);
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
