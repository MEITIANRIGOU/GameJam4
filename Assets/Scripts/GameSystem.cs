using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public static int healthyPeople = 0;
    public static int infectedPeople = 0;
    public Text uiText;
    private void Start()
    {
        NPC[] npcs = GetComponentsInChildren<NPC>();

        int randIndex = Random.Range(0, npcs.Length);

        for (int i=0; i < npcs.Length; i++)
        {
            if (i == randIndex)
            {
                npcs[i].infected = true;
            }

            if (npcs[i].infected == true)
            {
                infectedPeople += 1;
            }
            else
            {
                healthyPeople += 1;
            }
        }
    }
    private void Update()
    {
        uiText.text = "Infected: " + infectedPeople + "\nHealthy: " + healthyPeople;
    }
}