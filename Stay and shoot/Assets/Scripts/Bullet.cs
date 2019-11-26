using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject dieEffectPrefab;
    [SerializeField] float speed = 5f;
    public Vector3 targetVector;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //Move();
#if !UNITY_EDITOR
        if (PlayerPrefs.GetInt("Vibro")==0)
            Vibration.Vibrate(11);
#endif
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 delta = targetVector;
          transform.position += delta * Time.deltaTime * speed;
       // rb.AddForce(delta * speed, ForceMode.Impulse);
    }

    public void InstantiateDeathEff()
    {
       
        Instantiate(dieEffectPrefab,transform.position, dieEffectPrefab.transform.rotation);
    }
}
