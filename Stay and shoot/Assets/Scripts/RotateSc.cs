using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSc : MonoBehaviour
{

    public float multip = 5f;
    public float delter = 1f;
    [SerializeField] short typeOfRotate = 0;

    Vector3 direction;
    private void Start()
    {
        if (typeOfRotate == 0)
        {
            direction = transform.up;
        }
        else
            if (typeOfRotate == 1)
        {
            direction = transform.forward;
        }

    }
    void Update()
    {

        if (!StagesController.isLose)
        {
        
                transform.RotateAround(transform.position, multip * direction, Time.deltaTime * delter);
        }
    }
}
