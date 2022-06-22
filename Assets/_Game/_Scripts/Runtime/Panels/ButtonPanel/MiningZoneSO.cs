using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "newMiningZone", menuName = "Scriptable Objects/New Mining Zone")]
public class MiningZoneSO : ScriptableObject
{
    public string displayName;

    public int totalOreInZone;
    
    public int totalNodes;

    public int minersPurchased = 0;

    public int minerLevel = 0;
    public int minerMaxLevel = 10;

    public void PurchaseMiner()
    {
        if (minersPurchased >= totalNodes) return;
        minersPurchased++;
    }

    public void UpgradeMiner()
    {
        if (minerLevel >= minerMaxLevel) return;
        minerLevel++;
    }
}
