using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagement : MonoBehaviour
{
    public string firstLevel;
    public GameObject controlPanel;
    private void Awake()
    {
        controlPanel.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Control()
    {
        controlPanel.SetActive(true);
    }
    public void Close()
    {
        controlPanel.SetActive(false);
    }
}
