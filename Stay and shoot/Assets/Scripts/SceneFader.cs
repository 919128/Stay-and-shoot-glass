using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneFader : MonoBehaviour
{
    public Image img;

    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(int scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t>0f)
        {
            t -= (Time.deltaTime * 2);
            float a = curve.Evaluate(t);
            img.color = new Color(1f, 1f, 1f, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(int scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += (Time.deltaTime * 2);
            float a = curve.Evaluate(t);
            img.color = new Color(1f, 1f, 1f, a);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }
}
