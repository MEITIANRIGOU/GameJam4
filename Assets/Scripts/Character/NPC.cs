using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    public bool infected;
    public float testedTimer = 0;
    bool canInfect = false;
    float infectTimer = 0;
    int rotateAngle;
    float rotateTimer = 0;
    protected override void Start()
    {
        base.Start();
        int rand = Random.Range(-179, 180);
        transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, rand));
    }
    void Update()
    {
        rotateTimer += Time.deltaTime;
        if (infected && infectTimer <= 20)
        {
            infectTimer += Time.deltaTime;
        }
        if(testedTimer < 3)
        {
            testedTimer += Time.deltaTime;
        }

        if (rotateTimer >= 1)
        {
            rotateAngle = Random.Range(-45, 46);
            transform.GetChild(0).transform.Rotate(new Vector3(0, 0, rotateAngle));
            rotateTimer = 0;
        }
        rb.velocity = transform.GetChild(0).transform.up;

        if (infectTimer >= 20)
        {
            canInfect = true;
            infectTimer = 0;
        }

        if (transform.GetChild(0).GetComponent<SpriteRenderer>().color != Color.white && testedTimer >= 3)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<NPC>() != null && canInfect)
        {
            collision.GetComponent<NPC>().infected = true;
            canInfect = false;
            infectTimer = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.GetChild(0).transform.Rotate(new Vector3(0, 0, 180));
    }
}