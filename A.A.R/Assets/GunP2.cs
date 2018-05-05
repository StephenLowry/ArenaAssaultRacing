using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunP2 : MonoBehaviour
{

    public float damage = 25f;
    public float range = 1000f;

    public GameObject GunSource2;
    public AudioClip ShotSound2;
    public AudioClip HitSound2;

    //private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }



    // Use this for initialization
    public void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = ShotSound2;
        source.clip = HitSound2;
        source.playOnAwake = false;

        //button.onClick.AddListener(() => PlaySound());

    }
    //public void PlaySound()
    //{
    //source.PlayOneShot(sound);
    //}


    void Update()
    {
        if (Input.GetButtonDown("FireP2"))
        {
            Shoot();
            source.PlayOneShot(ShotSound2);
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(GunSource2.transform.position, GunSource2.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);


            Health health = hit.transform.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
                source.PlayOneShot(HitSound2);
            }
        }
    }
    //----------------LAVA-----------------\\


}

