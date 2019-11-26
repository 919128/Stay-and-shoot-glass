using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    void Move()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }
}
