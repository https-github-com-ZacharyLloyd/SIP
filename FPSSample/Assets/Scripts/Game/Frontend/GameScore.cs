﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Bindings to the game score panel on top of the screen and also the messages about game events

public class GameScore : MonoBehaviour
{
    public TMPro.TextMeshProUGUI team1Score;
    public TMPro.TextMeshProUGUI team2Score;
    public TMPro.TextMeshProUGUI objective;
    public TMPro.TextMeshProUGUI timer;
    public TMPro.TextMeshProUGUI timerMessage;
    public TMPro.TextMeshProUGUI message;
    public TMPro.TextMeshProUGUI action;

    // TODO (petera) Move out of GameScore and into replicated capture points
    public GameObject objectiveProgressRoot;
    public Image objectiveBackground;
    public RectTransform objectiveProgressFill;
    public TMPro.TextMeshProUGUI attackersCount;
    public TMPro.TextMeshProUGUI defendersCount;
    public void SetObjectiveProgress(float progress, int attackers, int defenders, Color defendColor, Color attackColor)
    {
        if (progress < 0.0f)
        {
            objectiveProgressRoot.SetActive(false);
        }
        else
        {
            objectiveProgressRoot.SetActive(true);

            if (attackers > 0)
            {
                attackersCount.Format("{0}", attackers);
                attackersCount.color = attackColor;
            }
            else
                attackersCount.text = "";
            if (defenders > 0)
            {
                defendersCount.Format("{0}", defenders);
                defendersCount.color = defendColor;
            }
            else
                defendersCount.text = "";

            objectiveProgressFill.sizeDelta = new Vector2(progress * 700.0f, objectiveProgressFill.sizeDelta.y);
            objectiveProgressFill.GetComponent<Image>().color = attackColor;
            objectiveBackground.color = new Color(defendColor.r, defendColor.g, defendColor.b, 0.5f);
        }
    }

    public void SetPanelActive(bool active)
    {
        gameObject.SetActive(active);
    }

    internal void Clear()
    {
        team1Score.text = "";
        team2Score.text = "";
        objective.text = "";
        SetObjectiveProgress(-1.0f, 0, 0, Color.white, Color.white);
    }
}
