using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float inputX;
    float inputY;
    public float movementSpeed;

    Vector2 pointingVector;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        rb.velocity = (new Vector2(inputX, inputY)).normalized * movementSpeed;

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
    public float Angle_360(Vector2 Vector)
    {
        float x = Vector.x;
        float y = Vector.y;

        float hypotenuse = Mathf.Sqrt(Mathf.Pow(x, 2f) + Mathf.Pow(y, 2f));

        float cos = y / hypotenuse;
        float radian = Mathf.Acos(cos);

        float angle = 180 / (Mathf.PI / radian);

        if (x > 0)
        {
            angle = -angle;
        }
        return angle;
    }
}