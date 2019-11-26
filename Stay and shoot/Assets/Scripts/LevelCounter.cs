using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelCounter : MonoBehaviour
{
    [SerializeField] Text levelText;

    private void Start()
    {
        levelText.text = (SceneManager.GetActiveScene().buildIndex + 1).ToString();
    }
}
