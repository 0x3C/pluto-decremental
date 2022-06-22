using System;
using UnityEngine;

namespace _Game._Scripts.Runtime.Utility
{
    public class TestingUtility : MonoBehaviour
    {
        private void Start()
        {
            var list = new PlutoniumNodes();
            list.GenerateValues(256);
        }
    }
}