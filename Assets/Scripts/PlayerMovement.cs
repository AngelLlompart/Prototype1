using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed = 10;
    [SerializeField] private TextMeshProUGUI turboValue;
    [SerializeField] private Slider turboBar;
    private float turbo = 50;
    // Start is called before the first frame update
    void Start()
    {
        UpdateTurbo();
    }

    // Update is called once per frame
    void Update()
    {
        CarMovement();
        CarRotation();
        CarRestoreRotation();
        Turbo();
    }

    private void CarMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
    }

    private void CarRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,90 * Time.deltaTime,0);
        } else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,-90 * Time.deltaTime,0);
        }
    }

    private void Turbo()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && turbo > 0)
        {
            turbo -= (10 * Time.deltaTime);
            UpdateTurbo();
            moveSpeed = 20;
        }
        else {
            moveSpeed = 10;
        }
    }

    public void AddTurbo()
    {
        if (turbo + 10 < 100)
        {
            turbo += 10;
        }
        else
        {
            turbo = 100;
        }
        
        UpdateTurbo();
    }

    private void UpdateTurbo()
    {
        turboBar.value = turbo;
        turboValue.text = (int) turbo + "%";
    }

    private void CarRestoreRotation()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 eulers = transform.eulerAngles;
            transform.rotation = Quaternion.Euler(0, eulers.y, 0);
            
        }
    }
}
