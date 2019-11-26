using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] GameObject[] walls;
    [SerializeField] float speed;

    bool isFinished = false;

 
    private void Update()
    {
        if (isFinished)
        {
            walls[0].transform.Translate(Vector3.right * Time.deltaTime * speed);
            walls[1].transform.Translate(Vector3.left * Time.deltaTime * speed);
        } 
    }

    public void OnStageFinished()
    {
        isFinished = true;
        Destroy(gameObject, 3f);
    }
}
