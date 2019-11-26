using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] GameObject winPanel, losepanel, startPanel, soundPanel,scorePanel, vibroPanel,congratsPanel;

    private void OnEnable()
    {
        StagesController.OnLevelFinish += OnLevelFinished;
        ButtonsController.OnGameStart += OnLevelStarted;
        StagesController.OnStageFinish += OnStageFinished;
        BadObstacle.OnLevelLosed += OnLevelLosed;
    }
    private void OnDisable()
    {
        StagesController.OnLevelFinish -= OnLevelFinished;
        ButtonsController.OnGameStart -= OnLevelStarted;
        StagesController.OnStageFinish -= OnStageFinished;
        BadObstacle.OnLevelLosed -= OnLevelLosed;
    }

    void OnLevelFinished()
    {
        StartCoroutine(DelayedWin());
    }
    void OnStageFinished()
    {
        SetPanel(congratsPanel);
    }
    IEnumerator DelayedWin()
    {
        yield return new WaitForSeconds(1.5f);
        SetPanel(vibroPanel);
        SetPanel(winPanel); SetPanel(soundPanel); SetPanel(scorePanel, false);
    }
        IEnumerator DelayedDeath()
    {
        yield return new WaitForSeconds(1f);
        SetPanel(vibroPanel);
        SetPanel(losepanel); SetPanel(soundPanel);
    }
    void OnLevelLosed()
    {
        StartCoroutine(DelayedDeath());
    }
    void OnLevelStarted()
    {
        SetPanel(scorePanel, false);
        SetPanel(vibroPanel,false);
        SetPanel(startPanel,false);
        SetPanel(soundPanel, false);
    }

    void SetPanel(GameObject panel, bool state = true)
    {
        panel.SetActive(state);
    }
}
