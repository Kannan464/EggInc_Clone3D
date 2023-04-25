using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;
using System;

public class GameManager : MonoBehaviour
{
    public int chickenCount, henHouseCapacity,goldeggCount;
    public float shippingProfit, EggProfitIncrease;
    public float amount;
    float secondValue;
    public float amountIncreasePerSecond;
    public static GameManager instance;
    public TMP_Text chicCounttxt, amountCount, secondsAmt;
    public Slider levelCapacitySlider, chickenCapacitySlider;
    public Button ChicBtn;
    public GameObject UpgradeBtn;
    public ShippingVehicleHouse shippingVehicleHouse;
    public HenHouse henHouse;
    public TMP_Text goldeggTxt;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(addsec());

        chickenCount = PlayerPrefs.GetInt("chickenCount", chickenCount);
        amount = PlayerPrefs.GetFloat("amount", amount);
        secondValue = PlayerPrefs.GetFloat("secondValue", secondValue);
        goldeggCount = PlayerPrefs.GetInt("goldeggCount", goldeggCount);
    }

    void Update()
    {
        shippingVehicleHouse.totalEggCount();
        shippingVehicleHouse.trikeVehicleUpgrade();
        henHouse.updateHouse();
        maxChickenCount();
        secondsAmt.text = ((int)secondValue).ToString() + "/SEC";
        if (chickenCount > 0)
        {
            PlayerPrefs.SetInt("chickenCount", chickenCount);
            PlayerPrefs.SetFloat("amount", amount);
        }
        if (chickenCount == henHouseCapacity)
        {
            UpgradeBtn.SetActive(true);
        }
    }

    //Level Chickens Count method
    public void maxChickenCount()
    {
        levelCapacitySlider.value = chickenCount;
        chicCounttxt.text = chickenCount.ToString();
        PlayerPrefs.SetInt("goldeggCount", goldeggCount);
        goldeggTxt.text = goldeggCount.ToString(); // Golden egg text
    }
    public void OnShippingProfit()
    {
        int adding = Convert.ToInt32(shippingProfit);
        amount += adding;
    }

    // seconds increase per second.
    public void secIncrease()
    {
        if (chickenCount >= 0)
        {
            secondsAmt.text = ((int)secondValue).ToString() + "/SEC";
            secondValue += amountIncreasePerSecond;
            PlayerPrefs.SetFloat("secondValue", secondValue);
        }
    }

    // amount and Seconds added in every seconds
    public IEnumerator addsec()
    {      
        yield return new WaitForSeconds(1f);
        amount += Convert.ToInt32(secondValue);
        amountCount.text = "Amount : " + amount.ToString();
        StartCoroutine(addsec());
    }
}