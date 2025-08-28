using System;
using Unity.VisualScripting;
using UnityEngine;

public class IconSet : MonoBehaviour
{
    [SerializeField]
    private StageSelect _stageSelect;

    [SerializeField]
    private int stageNum;

    private void OnMouseDown()
    {
        _stageSelect.OnStageButtonSelected.Invoke(stageNum);  
    }
}
