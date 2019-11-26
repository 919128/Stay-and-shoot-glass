using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaking : MonoBehaviour
{

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Shake(bool state)
    {
        animator.SetBool("shake", state);
    }
}
