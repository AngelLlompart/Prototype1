using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider turboBar;
    [SerializeField] private TextMeshProUGUI txtWin;
    [SerializeField] private TextMeshProUGUI txtTime;
    [SerializeField] private TextMeshProUGUI hpValue;
    [SerializeField] private TextMeshProUGUI turboValue;
    [SerializeField] private TextMeshProUGUI txtPoints;
    private GameObject _player;
    private int hp = 100;
    public int turbo = 50;
    private int points = 0;
    private int time = 120;

    private bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
