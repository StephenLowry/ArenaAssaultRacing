using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]

public class MainMenu : MonoBehaviour
{

    public void PlaySoloGame()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex * 0) + 1);
    }
    public void Play2PGame()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex * 0) + 2);
    }
    public void EGLeaderBoard()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex * 0) + 3);
    }
    //public void EGRestartP1()
    //{
    //SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex * 0) + 1);
    //}
    //public void EGRestartP2()
    //{
    //SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex * 0) + 2);
    //}
    public void Menu()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex * 0) + 0);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    //----------------SOUND-----------------\\

    public AudioClip sound;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }



    // Use this for initialization
    public void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        button.onClick.AddListener(() => PlaySound());
    }
    public void PlaySound()
    {
        source.PlayOneShot(sound);
    }


}