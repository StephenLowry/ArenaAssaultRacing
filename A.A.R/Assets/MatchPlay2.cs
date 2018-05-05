using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchPlay2 : MonoBehaviour
{

    private Health PlayerScore2;
    private float GetScore2;

    public Text MessageText;

    public GameObject CarP1;
    public GameObject CarP2;
    public GameObject Car1;
    public GameObject Car2;
    public GameObject CameraP2;
    public GameObject CameraP1;
    public GameObject CameraP2Backup;
    public GameObject CameraP1Backup;
    public GameObject Camera2;
    public GameObject EndMenuUI;
    public GameObject GameUI;
    public GameObject P1Died;
    public GameObject P2Died;

    void Start()
    {
        ////activate what needs to be activated & deactived anything that is meant to be deactivated...
        //CarP1.SetActive(true);
        //CarP2.SetActive(true);
        //Car1.SetActive(true);
        //Car2.SetActive(true);
        GetScore2 = 0;
    }

    void Update()
    {
        //if both players are alive
        if (Car1.activeInHierarchy == false && Car2.activeInHierarchy == false)
        {
            if (CarP1.activeInHierarchy == true && CarP2.activeInHierarchy == false)
            {
                Debug.Log("P1 wins");
                //stop the game
                Time.timeScale = 0f;

                //close game cam & ui.
                P2Died.SetActive(false);
                CameraP1Backup.SetActive(false);
                CameraP2.SetActive(false);
                GameUI.SetActive(false);
                CameraP1Backup.SetActive(false);
                P1Died.SetActive(false);
                CameraP2Backup.SetActive(false);
                CameraP1.SetActive(false);

                //open end game ui & cam2
                EndMenuUI.SetActive(true);
                Camera2.SetActive(true);

                CheckTopScore2();
            }
            else if (CarP1.activeInHierarchy == false & CarP2.activeInHierarchy == true)
            {
                Debug.Log("P2 wins");
                //stop the game
                Time.timeScale = 0f;
                //open end game ui & cam2

                EndMenuUI.SetActive(true);
                Camera2.SetActive(true);
                //close game cam & ui.

                P2Died.SetActive(false);
                CameraP1Backup.SetActive(false);
                CameraP2.SetActive(false);
                GameUI.SetActive(false);
                CameraP1Backup.SetActive(false);
                P1Died.SetActive(false);
                CameraP2Backup.SetActive(false);
                CameraP1.SetActive(false);

                CheckTopScore2();
            }
            else if (CarP1.activeInHierarchy == false && CarP2.activeInHierarchy == false)
            {
                Debug.Log("P1 & P2 both died");
                //stop the game
                Time.timeScale = 0f;

                //open end game ui & cam2
                EndMenuUI.SetActive(true);
                Camera2.SetActive(true);

                //close game cam & ui. 
                CameraP1Backup.SetActive(false);
                CameraP2Backup.SetActive(false);
                CameraP2.SetActive(false);
                CameraP1.SetActive(false);
                GameUI.SetActive(false);
                CameraP2Backup.SetActive(false);
                P2Died.SetActive(false);
                CameraP1Backup.SetActive(false);
                P1Died.SetActive(false);

                //print match result
                MessageText.text = "You both died!";
            }
            else
            {
                Debug.Log("Doing nothing...133");
            }
        }
        //if both players are dead
        else if (CarP1.activeInHierarchy == false && CarP2.activeInHierarchy == false)
        {
            Debug.Log("Both players are dead");
            //stop the game
            Time.timeScale = 0f;

            //open end game ui & cam2
            EndMenuUI.SetActive(true);
            Camera2.SetActive(true);

            //close game cam & ui. 
            CameraP1Backup.SetActive(false);
            CameraP2Backup.SetActive(false);
            CameraP2.SetActive(false);
            CameraP1.SetActive(false);
            GameUI.SetActive(false);
            CameraP2Backup.SetActive(false);
            P2Died.SetActive(false);
            CameraP1Backup.SetActive(false);
            P1Died.SetActive(false);

            //print match result
            MessageText.text = "You both died!";
        }
        //if player 1 alive but player 2 dies
        else if (CarP1.activeInHierarchy == true && CarP2.activeInHierarchy == false)
        {
            Debug.Log("P2 died but P1 lives");
            //open died ui & backup cam
            CameraP2Backup.SetActive(true);
            P2Died.SetActive(true);

            //close game cam & ui
            CameraP1Backup.SetActive(false);
            CameraP2.SetActive(false);
        }
        //if player 2 alive but player 1 dies
        else if (CarP2.activeInHierarchy == true && CarP1.activeInHierarchy == false)
        {
            Debug.Log("P1 & P2 both died");
            //open died ui & backup cam
            CameraP1Backup.SetActive(true);
            P1Died.SetActive(true);

            //close game cam & ui. 
            CameraP2Backup.SetActive(false);
            CameraP1.SetActive(false);
        }
        else
        {
            Debug.Log("doing nothing...178");
            //do nothing...
        }
    }
    void CheckTopScore2()
    {
        PlayerScore2 = CarP1.GetComponent<Health>();
        GetScore2 = PlayerScore2.score;
        //game ending in a win & top score 
        if (GetScore2 > PlayerPrefs.GetFloat("TopScore", 0))
        {
            Debug.Log("Win... new top score...");
            PlayerPrefs.SetFloat("TopScore", GetScore2);
            MessageText.text = "You win! " +"\n"+
                "New top score: " + GetScore2.ToString("f0");
        }
        else if (GetScore2 < PlayerPrefs.GetFloat("TopScore", 0))//game ending in a win
        {
            Debug.Log("Win...");
            MessageText.text = "You win! \n Score: " + GetScore2.ToString("f0");
        }
    }
}
