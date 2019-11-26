using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDeath : MonoBehaviour
{
    [SerializeField] private float delayTime = 1f;

    private void Start()
    {
        Destroy(gameObject, delayTime);
    }
}
