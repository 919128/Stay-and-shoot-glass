using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Object movement to the left - to the right.
 */

public class XMoving : MonoBehaviour
{

    public float diapason = 4f; // Left and right diapason (left -diapason, right diapason)
    public float speed = 0.2f;

    public bool right = true; // start of mooving

    private bool isGoingRight = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (right == true)
        {
            if (isGoingRight == true)
            {
                if (transform.position.x < diapason)
                {
                    transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);

                }
                else
                {
                    isGoingRight = false;
                }
            }
            else
            {
                if (transform.position.x > -diapason)
                {
                    transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);

                }
                else
                {
                    isGoingRight = true;
                }
            }
        }
        else
        {
            if (isGoingRight == true)
            {
                if (transform.position.x > -diapason)
                {
                    transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
                }
                else
                {
                    isGoingRight = false;
                }
            }
            else
            {
                if (transform.position.x < diapason)
                {
                    transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                }
                else
                {
                    isGoingRight = true;
                }
            }
        }
    }
}

