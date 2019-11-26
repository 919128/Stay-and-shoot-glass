using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObjectRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 15;
    [SerializeField] private float angle = 90;

    private float totalAngle;
    private Quaternion startRotation;
    List<GameObject> collections;
   
    private void Awake()
    {
        startRotation = transform.rotation;
    }


  
    IEnumerator RotateCoroutine()
    {
        totalAngle += angle;
        Quaternion desiredRotation = startRotation * Quaternion.Euler(0, totalAngle, 0);

        while (Quaternion.Angle(transform.rotation, desiredRotation) > 0.01f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
            yield return null;
        }
    }

    public void Rotate()
    {
        StopAllCoroutines();
        StartCoroutine(RotateCoroutine());
    }
}