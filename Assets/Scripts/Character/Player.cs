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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<NPC>() != null)
        {
            NPC npc = collision.GetComponent<NPC>();
            if (npc.transform.GetChild(0).GetComponent<SpriteRenderer>().color == Color.red && !npc.captured)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    int randX = Random.Range(-18, 19);
                    int randY = Random.Range(15, 23);
                    npc.transform.position = new Vector2(randX, randY);
                    GameSystem.infectedPeople -= 1;
                    npc.captured = true;
                }
            }
        }
    }
}