using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialContainer : MonoBehaviour
{
    public List<Material> listMaterial;

    public List<Color> listActiveColor;

    [SerializeField] Color unactiveColor;
    public float t;
    private Vector3 targetScale;
    private Vector3 startScale;
    [SerializeField] float multipScale = 1.2f;
    [SerializeField] float stepScale= 0.02f;
    private void Awake()
    {
        Initialize();


    }
    private void Initialize()
    {
        foreach (var item in listMaterial)
        {
            listActiveColor.Add(item.color);
            item.color = unactiveColor;
        }

        targetScale = transform.localScale * multipScale;
    }

    public void MakeActive()
    {
    //    t+=0.01
        for (int i = 0; i < listMaterial.Count; i++)
        {
            listMaterial[i].color = Color.Lerp(listMaterial[i].color, listActiveColor[i], t);
        }

    }
    private void OnDestroy()
    {
        for (int i = 0; i < listMaterial.Count; i++)
        {
            listMaterial[i].color = listActiveColor[i];
        }
    }

    public void SetAsFinished()
    {
       
        
       StartCoroutine(FinishStage());
    }
    //
    void SetColored()
    {
        for (int i = 0; i < listMaterial.Count; i++)
        {
            listMaterial[i].color = listActiveColor[i];
        }
    }

    IEnumerator FinishStage()
    {
        GetComponent<Animator>().SetTrigger("finish");
       
        yield return new WaitForSeconds(0.15f);
       
        //while (transform.localScale.x<=1.2f)
        //{

        //    transform.localScale = Vector3.Lerp(transform.localScale,targetScale,stepScale);
        //    yield return null;
        //}
        //yield return null;
        //while (transform.localScale.x >= 1f)
        //{

        //    transform.localScale = Vector3.Lerp(transform.localScale, startScale, stepScale);
        //    yield return null;
        //}
    }

}
