using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStage : MonoBehaviour
{
    [SerializeField] ObstaclesContainer obstaclesContainer;
    public bool isFinished = false;
    public Transform playerSpawnPoint;
    [SerializeField] WallController wallController;

    public MainObjectRotation rotationObject;
    public float firstYPosition;
    public MaterialContainer materialContainer;
    public void UpdateInformation(float currentPositionY = 6)
    {
        if (FindObjectOfType<StagesController>())
            StagesController.Instance.CurrentYposition = currentPositionY;
        materialContainer.MakeActive();
        isFinished = obstaclesContainer.ObstaclesCount <= 0;
        if (isFinished && FindObjectOfType<StagesController>())
        {
            StagesController.Instance.CheckCurrentLevelState();
            materialContainer.SetAsFinished();
        }
    }

    public void FinishStage()
    {
        if (wallController)
        wallController.OnStageFinished();
    }
    
}
