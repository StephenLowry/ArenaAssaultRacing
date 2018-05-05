using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {
    public AudioClip Sizzle;
    public GameObject Car1;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnTriggerEnter(Collider Car1)
    {
            Debug.Log("Car enter lava");
            source.PlayOneShot(Sizzle);
            Destroy(Car1);

            //Health health = transform.GetComponent<Health>();
            //health.TakeDamage(10000);
        }
        
    }
    


