using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLocal : MonoBehaviour
{

    public float multip = 5f;
    public float delter = 1f;
   
    
    private void Start()
    {
   

    }
    void Update()
    {

        if (!StagesController.isLose)
        {

            transform.Rotate(Vector3.forward * multip, delter);
        }
    }
}
