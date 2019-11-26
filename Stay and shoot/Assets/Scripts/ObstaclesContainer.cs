using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesContainer : MonoBehaviour
{
    public int ObstaclesCount { get; private set; }

    [SerializeField] LevelStage levelStage;
    [SerializeField] List<GameObject> cubesObstacles;
   [SerializeField] List<float> positionsY;

    
    private void Start()
    {
        positionsY = new List<float>();
        foreach (var obstacle in cubesObstacles)
        {
            positionsY.Add(obstacle.transform.position.y);
        }

        positionsY.Reverse();

        levelStage.firstYPosition = positionsY[positionsY.Count - 1];
        CountObstacles();
    }
    public void IncreaseObstacles()
    {
       
        ObstaclesCount++;
        print("ObstaclesCount: " + ObstaclesCount);
    }
    public void DecreaseObstacles()
    {
        ObstaclesCount--;
      //  levelStage.UpdateInformation();
        print("ObstaclesCount: " + ObstaclesCount);
    }
    
    public void CountObstacles()
    {
        
        
            ObstaclesCount = GetComponentsInChildren<CubeObstacle>().Length;

        if (ObstaclesCount >= 1)
            levelStage.UpdateInformation(positionsY[ObstaclesCount - 1]);
        else
        {
            levelStage.UpdateInformation(0);
        }

    }


}
