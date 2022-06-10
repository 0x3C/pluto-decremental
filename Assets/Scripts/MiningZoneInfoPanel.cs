using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MiningZoneInfoPanel : MonoBehaviour
{
    public MiningZoneSO selectedMine;

    private Label _displayName;
    private VisualElement _oreIcon;
    private Label _oreLabel;
    private Label _remainingOre;
    private Button _purchaseMinerButton;
    private Label _amountOfMiners;

    private void Start()
    {
        InitializeVisualElements();
        BindToScriptableObject(selectedMine);
    }

    private void InitializeVisualElements()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _displayName = root.Q<Label>("DisplayName");
        _oreLabel = root.Q<Label>("OreName");
        _oreIcon = root.Q<VisualElement>("OreIcon");
        _remainingOre = root.Q<Label>("RemainingOre");
        _purchaseMinerButton = root.Q<Button>("PurchaseMiner");
        _amountOfMiners = root.Q<Label>("MinersPurchased");
    }

    public void BindToScriptableObject(MiningZoneSO mine)
    {
        UnbindScriptableObject(selectedMine);
        selectedMine = mine;
        _purchaseMinerButton.clicked += PurchaseMiner;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _displayName.text = selectedMine.displayName;
        _oreLabel.text = selectedMine.oreTypeSO.oreName;
        _oreIcon.style.backgroundColor = selectedMine.oreTypeSO.oreIconColor;
        _remainingOre.text = $"Remaining Ore: {selectedMine.maximumCapacityOfMine - selectedMine.numberOfOreMined}";
        _amountOfMiners.text = $"Miners Purchased: {selectedMine.minersPurchased}";
    }

    private void UnbindScriptableObject(MiningZoneSO mine)
    {
        _purchaseMinerButton.clicked -= PurchaseMiner;
    }

    private void PurchaseMiner()
    {
        selectedMine.PurchaseMiner();
        UpdateUI();
    }
}
