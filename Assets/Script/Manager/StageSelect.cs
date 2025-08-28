using System;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    [SerializeField] GameObject[] StageObj;

    public Action<int> OnStageButtonSelected;
    [SerializeField]
    private int currentStage;

    private void Start()
    {
        SelectStage(currentStage);
        OnStageButtonSelected += SelectStage;
    }

    private void SelectStage(int stage)
    {
        for (int i = 0; i < StageObj.Length; i++)
        {
            StageObj[i].SetActive(i==stage);
        }
        currentStage = stage + 2; // Adjust with Scene Number
    }

    public void StageStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentStage);
        Time.timeScale = 1.0f;
    }
}
