using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    float inputX;
    float inputY;
    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        
        pointingVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, -Camera.main.transform.position.z)) - gameObject.transform.position);
        transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, Angle_360(pointingVector)));

        if (Input.GetMouseButtonDown(0))
        {
            transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = (new Vector2(inputX, inputY)).normalized * movementSpeed;
    }
}