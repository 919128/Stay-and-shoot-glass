using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CameraController : Singleton<CameraController>
{
    public static event Action OnCameraPositionAchieaved;
    public static bool isInPosition = true;
    public bool isMove = false;
    [SerializeField] float cameraSpeedMoving = 15f;
    [SerializeField] private float startDifDistance = 0;
    Transform playerTransform;

    [SerializeField] CameraShaking cameraShaking;

    private void Start()
    {
        playerTransform = PlayerController.Instance.gameObject.transform;
        startDifDistance = playerTransform.position.z - transform.position.z;
    }
    private void Update()
    {
        if (isMove)
        {
            isInPosition = false;
            transform.Translate(Vector3.forward * Time.deltaTime * cameraSpeedMoving, Space.World);
            if (transform.position.z >= playerTransform.position.z - startDifDistance)
            {
                OnCameraPositionAchieaved.Invoke();
                isMove = false;

                isInPosition = true;
            }
        }
    }

    public void ShakingCamera(bool state)
    {
        cameraShaking.Shake(state);
    }
}
