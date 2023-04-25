using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResearchLab : UIHandler
{
    public Button chickencountIncBtn;
    int goldeggRate = 10;
    public TMP_Text goldEggamountTxt;
    public RectTransform researchLabPanel;

    void Start()
    {
        chickencountIncBtn.onClick.AddListener(eggIncrease);
        goldEggamountTxt.text=goldeggRate.ToString();
    }

    void Update()
    {
        if (GameManager.instance.goldeggCount > goldeggRate)
        {
            chickencountIncBtn.interactable = true;
        }
        else
        {
            chickencountIncBtn.interactable = false;
        }
    }
    public override void OpenMe()
    {
        gameObject.SetActive(true);
        researchLabPanel.DOAnchorPosX(0, 0.5f);
    }

    public override void CloseMe()
    {
      researchLabPanel.DOAnchorPosX(1100,0.5f).OnComplete(()=>gameObject.SetActive(false));
    }

    public override void BackMe()
    {

    }
    // for egg spawn count increase...
    public void eggIncrease()
    {
        ChickenSpawn.instance.increaseChickenSpawnCount = 2;
        GameManager.instance.goldeggCount -= goldeggRate;
        chickencountIncBtn.interactable = false;
    }
}