using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAI : MonoBehaviour
{

    public float damage = 25f;
    public float range = 1000f;
    public float DelayBetweenThrows = 1/50;
    float lastThrowDate;
    public GameObject GunSource;
    public AudioClip ShotSound;
    public AudioClip HitSound;
    

    //private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }



    // Use this for initialization
    public void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = ShotSound;
        source.clip = HitSound;
        source.playOnAwake = false;
        lastThrowDate = Time.time;
    }

    
    
    void Update()
    {
        RaycastHit hit;
                if (Physics.Raycast(GunSource.transform.position, GunSource.transform.forward, out hit, range))
                {
            if ((Time.time - lastThrowDate > DelayBetweenThrows))
            {
                Shoot();
                source.PlayOneShot(ShotSound);
                lastThrowDate = Time.time;
            }
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(GunSource.transform.position, GunSource.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);


            Health health = hit.transform.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
                source.PlayOneShot(HitSound);
            }

        }
    }
}

