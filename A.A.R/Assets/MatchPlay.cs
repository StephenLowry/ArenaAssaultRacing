using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchPlay : MonoBehaviour {

    private Health PlayerScore;
    private float GetScore;

    public Text MessageText;
    public Text TopScore;

    public GameObject CarP1;

    public GameObject Car1;
    public GameObject Car2;
    public GameObject Car3;
    public GameObject Camera2;
    public GameObject Camera1;
    public GameObject EndMenuUI;
    public GameObject GameUI;

    void Start()
    {
        TopScore.text = PlayerPrefs.GetFloat("TopScore", 0).ToString("f0");
        GetScore = 0;
    }
    void Update() {
        //game ending in a lose

        if (CarP1.activeInHierarchy == false)
        {   //stop the game
            Time.timeScale = 0f;
            //close game cam & ui. 
            Camera1.SetActive(false);
            GameUI.SetActive(false);
            //open end game ui & cam2
            EndMenuUI.SetActive(true);
            Camera2.SetActive(true);
            //print match result
            MessageText.text = "You died!";
        }
        else if (Car1.activeInHierarchy == false && Car2.activeInHierarchy == false && Car3.activeInHierarchy == false && CarP1.activeInHierarchy == true)
        {
            //stop the game
            Time.timeScale = 0f;
            //close game cam & ui. 
            Camera1.SetActive(false);
            GameUI.SetActive(false);
            //open end game ui & cam2
            EndMenuUI.SetActive(true);
            Camera2.SetActive(true);
            //get score form other script...
            PlayerScore = CarP1.GetComponent<Health>();
            GetScore = PlayerScore.score;
            //Run top score method...
            CheckTopScore();
        }
        else
        {
            //do nothing...
        }
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        TopScore.text = "0";
    }
    void CheckTopScore(){
        PlayerScore = CarP1.GetComponent<Health>();
        GetScore = PlayerScore.score;
        //game ending in a win & top score 
        if (GetScore <= PlayerPrefs.GetFloat("TopScore", 0))
        {
            Debug.Log("Win...");
            MessageText.text = "You win! \n Score: " + GetScore.ToString("f0");
        }
        else if (GetScore > PlayerPrefs.GetFloat("TopScore", 0))//game ending in a win
        {
            Debug.Log("Win... new top score...");
            PlayerPrefs.SetFloat("TopScore", GetScore);
            MessageText.text = "You win!"+"\n"+"New top score: " + GetScore.ToString("f0");
        }
    }
}
                            