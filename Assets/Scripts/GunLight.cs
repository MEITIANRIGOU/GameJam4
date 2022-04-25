using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<NPC>() != null)
        {
            NPC npc = collision.GetComponent<NPC>();
            if (npc.infected == true)
            {
                npc.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
                npc.testedTimer = 0;
            }
            else
            {
                npc.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
                npc.testedTimer = 0;
            }
        }
    }
}