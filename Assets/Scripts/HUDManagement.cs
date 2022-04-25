using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManagement : MonoBehaviour
{
    private float timer;
    private float currentTime;
    public float interval=1f;
    public float totalTime=20f;
    public Text timeText;
    public Text redPeopleText;
    private void Awake()
    {
        timer = 0;
        currentTime = totalTime;
        timeText.text = totalTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>interval)
        {
            timer = 0;
            currentTime--;
            if(currentTime<0)
            {
                currentTime = totalTime;
            }
            timeText.text = currentTime.ToString();
        }
    }
}
