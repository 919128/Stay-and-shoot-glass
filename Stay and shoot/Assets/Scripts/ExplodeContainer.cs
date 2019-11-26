using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeContainer : MonoBehaviour
{

    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] AudioClip[] sounds;
    [SerializeField] float explodeRadius = 3f;
    [SerializeField] float explodeForce = 150f;
    [SerializeField] Vector3 addVector = Vector3.zero;
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        //  addVector = new Vector3(Random.Range(-1f,1f), Random.Range(-2f, 0f), Random.Range(-2f, 0f));
     
      DoExplode();
    }

  public void DoExplode()
    {
        if (PlayerPrefs.GetInt("Sound")!=1)
            audioSource.PlayOneShot(sounds[Random.Range(0,sounds.Length)]);

        Collider[] colliders = Physics.OverlapSphere(transform.position + addVector, 2f);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)

                rb.AddExplosionForce(Random.Range(explodeForce - 50f, explodeForce + 50f), transform.position, explodeRadius, explodeRadius);
        }





        //foreach (var item in transform.GetComponentsInChildren<Rigidbody>())
        //{

        //    item.AddExplosionForce(Random.Range(explodeForce - 50, explodeForce + 50), transform.position + addVector, explodeRadius);


        //}

    }

}
