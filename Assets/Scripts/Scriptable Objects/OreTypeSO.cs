using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "newOreType", menuName = "Scriptable Objects/New Ore Type")]
public class OreTypeSO : ScriptableObject
{
    public string oreName;
    public Color oreIconColor;
}
