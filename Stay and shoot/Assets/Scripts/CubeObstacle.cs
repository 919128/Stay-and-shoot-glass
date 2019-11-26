using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObstacle : Obstacle
{
    [SerializeField] GameObject explodeContainer;
    [SerializeField] private ObstaclesContainer container;
   
    bool rotated = false;
    private void Start()
    {

    }
    public override void OnHitByBullet()
    {
        StagesController.Instance.currentObjectRotation.Rotate();
       
        if (explodeContainer)
           Instantiate(explodeContainer, transform.position + new Vector3(0f,0f,-1f),Quaternion.Euler(0,173f,0f));// Quaternion.Euler(new Vector3(0f,173f,0f)));
       
        Destroy(gameObject);
       
      //  container.CountObstacles();
    }
    void Inster()
    {

    }
    
    private void OnDestroy()
    {
        container.CountObstacles();
    }


}
       
