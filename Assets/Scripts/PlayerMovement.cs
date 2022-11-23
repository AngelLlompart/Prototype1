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
        
    }

    // Update is called once per frame
    void Update()
    {
        CarMovement();
        CarRotation();
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
        if (Input.GetKey(KeyCode.LeftShift) && turbo > 0)
        {
            turbo -= (10 * Time.deltaTime);
            turboBar.value = turbo;
            turboValue.text = (int) turbo + "%";
            moveSpeed = 20;
            Debug.Log(turbo);
        }
        else {
            moveSpeed = 10;
        }
    }
}
