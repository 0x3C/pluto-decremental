using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;
public class PlutoniumNodes
{
    public List<float> Nodes = new List<float>();
    private List<float> _randomValues = new List<float>();
    
    public void GenerateValues(int splits)
    {
        var normalizedPerSplit = Int32.MaxValue / splits;
        Debug.LogFormat("Normalized per split: {0}", normalizedPerSplit);
        
        for (int i = 0; i < splits; i++)
        {
            var value = Random.Range(0.45f, 0.65f);
            _randomValues.Add(value);
        }

        var sum = _randomValues.Sum();
        Debug.LogFormat("Sum of 0-1 values: {0}", sum.ToString("N"));

        for (int i = 0; i < splits; i++)
        {
            var value = _randomValues[i] * (Int32.MaxValue / sum);
            Nodes.Add(value);
        }

        var difference = Int32.MaxValue - Nodes.Sum();

        Debug.LogFormat("Difference between Sum and Expected: {0}", difference.ToString("N"));

        Nodes[0] += difference;
        
        Debug.LogFormat("Sum of nodes: {0}", Nodes.Sum().ToString("N"));
        Debug.LogFormat("1st node: {0} // 100th Node: {1}", Nodes[0].ToString("N"), Nodes[99].ToString("N"));
        Debug.LogFormat("Average of all nodes: {0}", Nodes.Average().ToString("N"));
    }
}
