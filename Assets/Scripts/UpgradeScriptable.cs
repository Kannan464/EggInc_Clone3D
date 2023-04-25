using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeItem",menuName ="Scriptable/UpgradeItem")]
public class UpgradeScriptable : ScriptableObject
{
    public List<UpgradeItem> upgradeItem;
}
[System.Serializable]
public class UpgradeItem
{  
    public string Name;
    public List<HouseInfo> houseInfo;
    public List<vehicleInfo> vehicleInfo;

}
[System.Serializable]
public class HouseInfo
{
    public string Housename;
    public int unlockCost;
    public int occupancy;
}
[System.Serializable]
public class vehicleInfo
{
    public string vehicleName;
    public int vehicleCost;
    public int eggsCapacity;
}