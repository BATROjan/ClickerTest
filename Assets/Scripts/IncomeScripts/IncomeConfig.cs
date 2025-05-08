using System;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace.IncomeScripts
{
    [CreateAssetMenu(fileName = "IncomeConfig", menuName = "Configs/IncomeConfig")]
    public class IncomeConfig : ScriptableObject
    {
        public GameObject Prefab => prefab;
        public BuisnessModel[] BuisnessModels => buisnessModels;
        
        [SerializeField] private BuisnessModel[] buisnessModels;
        [SerializeField] private GameObject prefab;

        public float CalculateIncome(BuisnessModel buisnessModel)
        {
            var inc = buisnessModel.LvL * buisnessModel.BaseIncome*
            (1 + buisnessModel.BaseIncome 
                * buisnessModel.FistUpgrade.Cost * 0.01 
                + buisnessModel.BaseIncome 
                * buisnessModel.SecondUpgrade.Cost * 0.01);
            return (float)inc;
        }

        public int UpgradeLvLCost(BuisnessModel buisnessModel)
        {
            var cost = (buisnessModel.LvL + 1) * buisnessModel.BaseCost;
            return cost;
        }
    }
[Serializable]
    public struct BuisnessModel
    {
        public string Name;
        public int LvL;
        public bool HasBuy;
        public float IncomeDelay;
        public int BaseCost;
        public int BaseIncome;
        public UpgradeModel FistUpgrade;
        public UpgradeModel SecondUpgrade;
    }
    [Serializable]
    public struct UpgradeModel
    {
        public int Cost;
        public int IncomeMultiplier;
    }
}
