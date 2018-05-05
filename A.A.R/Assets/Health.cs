using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public float health = 100;
    private float startTime;
    public float score;
    public float TopScore;
    float t;
    float h;


    public Text HealthText;
    public Text TimerText;
    
    public GameObject car;
    public GameObject EndMenuUI;
    public GameObject GameUI;
    public GameObject Camera1P1;
    public GameObject Camera1P2;
    public GameObject Camera2;

    void Start()
    {
        startTime = 0;
        score = 0;
        TopScore = 0;
        t = 0;
        h = 0;
    }
    public void TakeDamage(float amount)
    {
        health -= amount; 
        if (health <= 0f)
        {
            Die();
            Debug.Log("You killed"+name);
        }
    }
    public void Die ()
    {
        car.SetActive(false);
        
    }
    public void Update()
    {
        h = (health / 200) * 100;
        string HealthLeft = ((int)h).ToString();
        HealthText.text = HealthLeft + "%";

        t = Time.time - startTime;
        score = ((1 / t + 1) * h * 100);
        string TimeAlive = ((int)t).ToString();
        TimerText.text = TimeAlive;
    }




}