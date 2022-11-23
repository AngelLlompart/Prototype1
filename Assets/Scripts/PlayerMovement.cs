using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int moveSpeed = 10;
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 20;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 10;
        }
    }
}
