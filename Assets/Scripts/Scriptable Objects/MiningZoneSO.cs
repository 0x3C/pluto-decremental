using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "newMiningZone", menuName = "Scriptable Objects/New Mining Zone")]
public class MiningZoneSO : ScriptableObject
{
    public string displayName;
    
    [Range(0.0f, 1.0f)]
    public float currentTaskProgress;

    public float taskDurationInSeconds;

    public int numberOfOreMined;

    public int maximumCapacityOfMine;

    public OreTypeSO oreTypeSO;

    public int minersPurchased;

    public void PurchaseMiner()
    {
        minersPurchased = minersPurchased + 1;
    }
}
