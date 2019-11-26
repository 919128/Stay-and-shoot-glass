using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Aiming : MonoBehaviour
{
    
    public static bool isAiming = false;
    
    Vector3 mouse;
    Ray castPoint;
    RaycastHit hit;
    Touch myTouch;
    public bool isFirstTickTouch = true;
    float touchControllBuffer = 0;
    float touchControllBuffer2 = 0;
    [SerializeField] float diapasonX = 4f;
    [SerializeField] float diapasonY = 4f;
    [SerializeField] Transform target;
    //LineRenderer lineRenderer;
    public Vector3 targetVectorDirection;
    bool isOnCollide = false;
    MeshRenderer targetMeshRenderer;
    float differenceBetweenTargetAndFirepoint;
    private void Awake()
    {
        isAiming = false;
        targetMeshRenderer = target.gameObject.GetComponent<MeshRenderer>();
        //lineRenderer = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        differenceBetweenTargetAndFirepoint = target.transform.position.z - transform.position.z;
    }
    private void OnEnable()
    {
        CameraController.OnCameraPositionAchieaved += ResetTargetPosition;
    }
    private void OnDisable()
    {
        CameraController.OnCameraPositionAchieaved -= ResetTargetPosition;
    }

    private void Update()
    {
        if (ButtonsController.isStarted)
        MoveRay();

    }
    void FixedUpdate()
    {
       
    }
    [SerializeField] float speedOfYMove= 00.1f;
    void MoveRay()
    {
        target.transform.position =Vector3.Lerp(target.transform.position,new Vector3(target.transform.position.x, StagesController.Instance.CurrentYposition, target.transform.position.z),Time.deltaTime *5f);
       
        if ((Input.touchCount == 1 || Input.GetMouseButton(0)) && !StagesController.isLose && !ButtonsController.onUI && CameraController.isInPosition)// || Input.GetMouseButton(0))
        {
           
            if (!targetMeshRenderer.enabled)
            targetMeshRenderer.enabled = true;
        
            CreateRay();
            if (!ButtonsController.onUI)
            isAiming = true;
    
           
        }
        else
        {
        
            
            isAiming = false;
           
        }

        transform.LookAt(target);
    }
    void CreateRay()
    {
        Ray r;
        RaycastHit hit;
       
        Vector3 fwd = transform.TransformDirection(target.position);
        targetVectorDirection = target.position - transform.position;
        r = new Ray(transform.position, target.position - transform.position);
        hit = new RaycastHit();

       
      
        Debug.DrawRay(r.origin, r.direction * 15);
    }
    void ResetTargetPosition()
    {
     //   target.position = new Vector3(0,3.2f,target.transform.position.z);
    }
    public void ChangeTargetPosition()
    {
      //  target.position = new Vector3(0, target.transform.position.y-1f, target.transform.position.z);
    }
}
