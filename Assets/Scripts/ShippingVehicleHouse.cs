using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShippingVehicleHouse : UIHandler
{
    public static ShippingVehicleHouse instance;
    public int eggsCapacity,shippingEggs;
    public TMP_Text[] vehicleNameTxt, vehicleUpCostTxt, eggsCapacityTxt;
    public TMP_Text shippingEggsTxt;
    public Slider ShippingeggsCapacitySlider;
    public UpgradeScriptable vehicleUpgrade;
    public Button trikeVehicleUpdateBtn,vanVehicleUpdateBtn;
    public RectTransform shippingHousePanel;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        shippingEggs = 5000;
        OnVehicleUp();
    }
    void Update()
    {
      
    }
    public override void OpenMe()
    {
        gameObject.SetActive(true);
        shippingHousePanel.DOAnchorPosX(0, 0.5f);
    }

    public override void CloseMe()
    {
        shippingHousePanel.DOAnchorPosX(1100,0.5f).OnComplete(()=>gameObject.SetActive(false));
    }

    public override void BackMe()
    {

    }
    // upgrade buttons interactable with amount .
    public void trikeVehicleUpgrade()
    {
        if (GameManager.instance.amount > vehicleUpgrade.upgradeItem[0].vehicleInfo[0].vehicleCost || GameManager.instance.amount > vehicleUpgrade.upgradeItem[0].vehicleInfo[1].vehicleCost)
        {
            trikeVehicleUpdateBtn.interactable = true;
            vanVehicleUpdateBtn.interactable = true;
        }
        else
        {
            trikeVehicleUpdateBtn.interactable = false;
            vanVehicleUpdateBtn.interactable = false;
        }
    }
    // Egg Count Slider for Shipping eggs popup
    public void totalEggCount()
    {
        eggsCapacity = GameManager.instance.chickenCount*2; // 1 chicken 2 eggs
        ShippingeggsCapacitySlider.value = eggsCapacity;
        GameManager.instance.shippingProfit =eggsCapacity;
        GameManager.instance.shippingProfit *= GameManager.instance.EggProfitIncrease; // Eggs Profit..
    }
    // vehicle upgrades derived data from Scriptable Object
    public void OnVehicleUp()
    {
        for (int i = 0; i < vehicleUpgrade.upgradeItem.Count; i++)
        {
            for (int j = 0; j < vehicleUpgrade.upgradeItem[i].vehicleInfo.Count; j++)
            {
                vehicleNameTxt[j].text = vehicleUpgrade.upgradeItem[i].vehicleInfo[j].vehicleName;
                vehicleUpCostTxt[j].text = vehicleUpgrade.upgradeItem[i].vehicleInfo[j].vehicleCost.ToString();
                eggsCapacityTxt[j].text = vehicleUpgrade.upgradeItem[i].vehicleInfo[j].eggsCapacity.ToString() +" " +"EGGS/MIN";
            }
        }
    }
    // Button Onclick Call.
    public void shippingHouseUpgrade()
    {
        GameManager.instance.amount -= vehicleUpgrade.upgradeItem[0].vehicleInfo[0].vehicleCost;
        ShippingeggsCapacitySlider.maxValue= vehicleUpgrade.upgradeItem[0].vehicleInfo[0].eggsCapacity;
        shippingEggs = 10000;
        shippingEggsTxt.text=shippingEggs.ToString()+ " " + "EGGS/MIN";
    }
    // Button Onclick Call.
    public void vanCapacityUpgrade()
    {
        GameManager.instance.amount -= vehicleUpgrade.upgradeItem[0].vehicleInfo[1].vehicleCost;
        ShippingeggsCapacitySlider.maxValue = vehicleUpgrade.upgradeItem[0].vehicleInfo[1].eggsCapacity;
        shippingEggs = 15000;
        shippingEggsTxt.text = shippingEggs.ToString() + " " + "EGGS/MIN";
    }
}