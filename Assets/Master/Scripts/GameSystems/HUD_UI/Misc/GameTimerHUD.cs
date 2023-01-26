using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimerHUD : BaseHUD
{
    [Space]
    [SerializeField] private TextMeshProUGUI m_timerText;

    protected override void UpdateHUD()
    {
        base.UpdateHUD();

        m_timerText.text = "Game Time Left: " + TimeFormatter(BFAGameManager.Instance.GameTimeSeconds);
    }
    
    public string TimeFormatter(float timeInSeconds)
    {
        timeInSeconds = Math.Clamp(timeInSeconds, 0, float.MaxValue);
        var minutes = Mathf.FloorToInt(timeInSeconds / 60F);
        int seconds = Mathf.FloorToInt(timeInSeconds - minutes * 60);
        return $"{minutes:00}:{seconds:00}";
    }
}
