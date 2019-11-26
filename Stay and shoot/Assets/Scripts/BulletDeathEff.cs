using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeathEff : MonoBehaviour
{

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Sound")==0)
            audioSource.Play();
    }
}
