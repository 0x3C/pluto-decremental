using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class MiningZoneButtonPanel : MonoBehaviour
{
    public int gridWidth;
    public int gridHeight;

    [SerializeField] private string buttonPanelName;
    [SerializeField] private MiningZoneSO[] miningZoneList;
    private MiningZoneInfoPanel _infoPanel;
    
    private void Start()
    {
        GenerateMiningZoneGrid();
        _infoPanel = GetComponent<MiningZoneInfoPanel>();
    }
    
    private void GenerateMiningZoneGrid()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var miningZoneGrid = root.Q<VisualElement>(buttonPanelName);
        
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                
                var miningZoneButton = new Button
                {   
                    text = $"Button {i * gridHeight + j}"
                };
                
                var index = i * gridHeight + j;
                miningZoneButton.clicked +=
                    () => _infoPanel.BindToScriptableObject(miningZoneList[index]);
                miningZoneGrid.Add(miningZoneButton);
            }
        }
    }
}
