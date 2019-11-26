using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Congratulations : MonoBehaviour
{
    [SerializeField] Text congratsTextUI;

    [SerializeField] string[] congratsText;

    private void Start()
    {
        congratsTextUI.text = congratsText[Random.Range(0, congratsText.Length)].ToUpper();
    }

    void SetDisablePanel()
    {
        gameObject.SetActive(false);
    }
}
