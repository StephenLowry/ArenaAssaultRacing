using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject GameUI;
    public GameObject pauseMenuUI;
    public GameObject EndMenuUI;
    public GameObject Guns1;
    public GameObject Guns2;

    // Update is called once per frame
    void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape) && EndMenuUI.activeInHierarchy==false)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameUI.SetActive(true);
        Guns1.SetActive(true);
        Guns2.SetActive(true);
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameUI.SetActive(false);
        Guns1.SetActive(false);
        Guns2.SetActive(true);
    }
}
