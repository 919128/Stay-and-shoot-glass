using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;

    [SerializeField] List<Bullet> spawnedBullets = new List<Bullet>();
    [SerializeField] float delayBetweenShoots = 1f;
    Transform firePoint;
    Aiming aiming;
    CameraController cameraController;
    private void Awake()
    {
        cameraController = CameraController.Instance;
        aiming = GetComponent<Aiming>();
        firePoint = transform;
    }
    private void Start()
    {
        StartSpawning();
    }
    void StartSpawning()
    {
        StartCoroutine(SpawnBullets());
    }
    IEnumerator SpawnBullets()
    {
        while (true)
        {
            if (ButtonsController.isStarted)
            {
                cameraController.ShakingCamera(Aiming.isAiming && !ButtonsController.onUI);
                if (Aiming.isAiming && !ButtonsController.onUI)
                {
                   
                    bulletPrefab.targetVector = aiming.targetVectorDirection;
                    //  spawnedBullets.Add(Instantiate(bulletPrefab, firePoint.position, transform.rotation));
                    Instantiate(bulletPrefab, firePoint.position, transform.rotation);
                }
            }
            yield return new WaitForSeconds(delayBetweenShoots);
        }
        
    }
}
