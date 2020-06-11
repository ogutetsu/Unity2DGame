using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get => _instance;
        set => _instance = value;
    }

    public Text playerGemCountText;
    public Image selectionImg;
    public Text gemCount;
    public Image[] healthBar;

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = gemCount.ToString() + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);  
    }

    public void UpdateGemCount(int count)
    {
        gemCount.text = count.ToString();
    }

    public void UpdateLives(int liveRemaining)
    {
        for (int i = 0; i <= liveRemaining; i++)
        {
            if (i == liveRemaining)
            {
                healthBar[i].enabled = false;
            }
        }
    }
    
    
    private void Awake()
    {
        _instance = this;
    }
}
