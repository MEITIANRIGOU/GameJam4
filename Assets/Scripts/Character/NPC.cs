using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    public bool infected;
    int rotateAngle;
    float rotateTimer = 0;
    
    void Update()
    {
        rotateTimer += Time.deltaTime;
        if (rotateTimer >= 1.5f)
        {
            rotateAngle = Random.Range(-20, 21);
            transform.GetChild(0).transform.Rotate(new Vector3(0, 0, rotateAngle));
            rotateTimer = 0;
        }
        rb.velocity = transform.GetChild(0).transform.up;
    }
}