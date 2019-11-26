using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StagesController : Singleton<StagesController>
{
    public static event Action OnLevelFinish;
    public static event Action OnStageFinish;
    [SerializeField] List<LevelStage> levelStages = new List<LevelStage>();
    public LevelStage currentLevelStage { get; private set; }
    [SerializeField] int idOfStage = 0;
    PlayerController playerController;
    CameraController cameraController;

    public float CurrentYposition;
    public MainObjectRotation currentObjectRotation;

    public static bool isLose = false;

    [SerializeField]
    GameObject[] congratsObjects;
    private void Start()
    {
        isLose = false;

        playerController = PlayerController.Instance;
        cameraController = CameraController.Instance;
        SetCurrentStageLevel();
    }

    public void CheckCurrentLevelState()
    {
        if (currentLevelStage.isFinished && idOfStage < levelStages.Count - 1) // stage finished.
        {

            StartCoroutine(DelayToChangeStage());

        }
        else if (currentLevelStage.isFinished && idOfStage >= levelStages.Count - 1) // level completed
        {
            FinishLevel();
        }
    }
    void FinishLevel()
    {
        CongratulateFinishStage();
        OnLevelFinish.Invoke();
        print("Level finished");
    }
    void SetCurrentStageLevel()
    {
        currentLevelStage = levelStages[idOfStage];
        currentObjectRotation = currentLevelStage.rotationObject;
        ResetTargetPosition(currentLevelStage.firstYPosition);
        SetPlayerPosition(currentLevelStage.playerSpawnPoint.position);
    }
    
    void SetPlayerPosition(Vector3 position)
    {
        playerController.gameObject.transform.position = position;
        cameraController.isMove = true;
    }

    IEnumerator DelayToChangeStage()
    {
        OnStageFinish.Invoke();
        CongratulateFinishStage();
        currentLevelStage.FinishStage();
          idOfStage++;
       
        yield return new WaitForSeconds(1.5f);
        SetCurrentStageLevel();
    }
    void OnGameLose()
    {
        isLose = true;
    }
    public void ResetTargetPosition(float posY)
    {
        CurrentYposition = posY;
    }

    void CongratulateFinishStage()
    {
        for (int i = 0; i < congratsObjects.Length; i++)
        {
            Instantiate(congratsObjects[i],currentLevelStage.transform.position + new Vector3(0f,1f,2f), congratsObjects[i].transform.rotation);
        }
    }

    private void OnEnable()
    {
        if (FindObjectOfType<BadObstacle>())
        {
            BadObstacle.OnLevelLosed += OnGameLose;
        }
    }

    private void OnDisable()
    {
        if (FindObjectOfType<BadObstacle>())
        {
            BadObstacle.OnLevelLosed -= OnGameLose;
        }
    }

    
}
