using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnQuit;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private Slider volumeBar;
    [SerializeField] private TextMeshProUGUI volumeValue;
    [SerializeField] private Toggle axisToggle;
    [SerializeField] private Button btnCloseSettings;

    public bool invAxis = false;
    // Start is called before the first frame update
    void Start()
    {
        settingsMenu.SetActive(false);
        btnPlay.onClick.AddListener(Play);
        btnSettings.onClick.AddListener(Settings);
        btnQuit.onClick.AddListener(Quit);
        btnCloseSettings.onClick.AddListener(CloseSettings);
    }

    // Update is called once per frame
    void Update()
    {
        volumeValue.text = (int) (volumeBar.value * 100) + "%";
        if (axisToggle.isOn)
        {
            invAxis = true;
        }
        else
        {
            invAxis = false;
        }
    }

    private void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    private void Settings()
    {
        settingsMenu.SetActive(true);
    }

    private void Quit()
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

    private void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }
}
