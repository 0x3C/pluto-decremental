using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MiningZoneInfoPanel : MonoBehaviour
{
    public MiningZoneSO selectedMine;

    private Label _displayName;
    private Label _remainingOre;
    private Label _minerCount;
    private Label _minerLevel;
    private Button _purchaseMinerButton;
    private Button _upgradeMinerButton;

    private void Start()
    {
        InitializeVisualElements();
        BindToScriptableObject(selectedMine);
    }

    private void InitializeVisualElements()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _displayName = root.Q<Label>("DisplayName");
        _remainingOre = root.Q<Label>("RemainingOre");
        _minerCount = root.Q<Label>("MinerCount");
        _minerLevel = root.Q<Label>("MinerLevel");
        _purchaseMinerButton = root.Q<Button>("PurchaseMiner");
        _upgradeMinerButton = root.Q<Button>("UpgradeMiner");
    }

    public void BindToScriptableObject(MiningZoneSO mine)
    {
        UnbindScriptableObject();
        selectedMine = mine;
        _purchaseMinerButton.clicked += PurchaseMiner;
        _upgradeMinerButton.clicked += UpgradeMiner;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _displayName.text = selectedMine.displayName;
        _remainingOre.text = $"Remaining ore in Zone: {selectedMine.totalOreInZone:D}";
        _minerCount.text = $"Miners: {selectedMine.minersPurchased} / {selectedMine.totalNodes}";
        _minerLevel.text = $"Miner level: {selectedMine.minerLevel} / {selectedMine.minerMaxLevel}"; 
        _purchaseMinerButton.text = $"Purchase Miner\n Cost: 100";
        _upgradeMinerButton.text = $"Upgrade Miner\n Cost: 1000";
    }

    private void UnbindScriptableObject()
    {
        _purchaseMinerButton.clicked -= PurchaseMiner;
        _upgradeMinerButton.clicked -= UpgradeMiner;
    }

    private void PurchaseMiner()
    {
        selectedMine.PurchaseMiner();
        UpdateUI();
    }

    private void UpgradeMiner()
    {
        selectedMine.UpgradeMiner();
        UpdateUI();
    }
}
