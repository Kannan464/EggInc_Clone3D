using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HenHouse : UIHandler
{
    public static HenHouse instance;
    public TMP_Text[] houseNameTxt, upgradeCostTxt, occupencyTxt;
    public Button ShackUpgradeBtn,superShackUpgradeBtn;
    public UpgradeScriptable houseUpgrade;
    public Slider OccupancySlider;
    public GameObject shackHouse;
    public RectTransform henHouseBGPanel;

    public void Start()
    {
        //houseUpgrade.upgradeItem[0].houseInfo[1].unlockCost
        instance = this;
        OnHouseUp();
    }
    public override void OpenMe()
    {
        gameObject.SetActive(true);
        OccupancySlider.value = GameManager.instance.chickenCount;
        OccupancySlider.maxValue = GameManager.instance.henHouseCapacity;

        henHouseBGPanel.DOAnchorPosX(0, 0.5f);
    }

    public override void CloseMe()
    {
   
        henHouseBGPanel.DOAnchorPosX(1100, 0.5f).OnComplete(()=>gameObject.SetActive(false));
      //  gameObject.SetActive(false);
    }

    public override void BackMe()
    {

    }

    // House upgrades derived data from Scriptable Object
    public void OnHouseUp()
    {
        for (int i = 0; i < houseUpgrade.upgradeItem.Count; i++)
        {
            for (int j = 0; j < houseUpgrade.upgradeItem[i].houseInfo.Count; j++)
            {
                houseNameTxt[j].text = houseUpgrade.upgradeItem[i].houseInfo[j].Housename;
                upgradeCostTxt[j].text = "Rs:" + houseUpgrade.upgradeItem[i].houseInfo[j].unlockCost.ToString();
                occupencyTxt[j].text = houseUpgrade.upgradeItem[i].houseInfo[j].occupancy.ToString();
            }
        }
      
        OccupancySlider.maxValue = GameManager.instance.henHouseCapacity;
        OccupancySlider.value = GameManager.instance.chickenCount;
    }
    // upgrade buttons interactable with amount .
    public void updateHouse()
    {
        if (GameManager.instance.amount > houseUpgrade.upgradeItem[0].houseInfo[0].unlockCost || GameManager.instance.amount > houseUpgrade.upgradeItem[0].houseInfo[1].unlockCost)
        {
            ShackUpgradeBtn.interactable = true;
            superShackUpgradeBtn.interactable = true;
        }
       
        else
        {           
            ShackUpgradeBtn.interactable = false;
            superShackUpgradeBtn.interactable = false;
        }
    }

    // Button Onclick Call.
    public void shackHouseLoad()
    {
       GameManager.instance.amount -= houseUpgrade.upgradeItem[0].houseInfo[0].unlockCost;
        GameManager.instance.henHouseCapacity = houseUpgrade.upgradeItem[0].houseInfo[0].occupancy;
        if (GameManager.instance.henHouseCapacity >= 30)
            ChickenSpawn.instance.isClickSpawn();
        OccupancySlider.maxValue = houseUpgrade.upgradeItem[0].houseInfo[0].occupancy;
    }

    // Button Onclick Call.
    public void SupershackHouseLoad()
    {
        GameManager.instance.amount -= houseUpgrade.upgradeItem[0].houseInfo[1].unlockCost;
        GameManager.instance.henHouseCapacity = houseUpgrade.upgradeItem[0].houseInfo[1].occupancy;
        if (GameManager.instance.henHouseCapacity >= 30)
            ChickenSpawn.instance.isClickSpawn();
        OccupancySlider.maxValue = houseUpgrade.upgradeItem[0].houseInfo[1].occupancy;
        shackHouse.SetActive(false);
    }
}