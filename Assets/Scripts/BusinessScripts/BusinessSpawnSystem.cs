using System;
using DefaultNamespace.IncomeScripts;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace DefaultNamespace.BusinessScripts
{
    public class BusinessSpawnSystem: IEcsInitSystem
    {
        private readonly EcsWorld world = null;
        private readonly RunTimeData runTimeData = null;
        private readonly IncomeConfig incomeConfig = null;
     
        public void Init()
        {
            ref var prefab = ref runTimeData.prefab;
            ref var parent = ref runTimeData.ParentTransform;
            prefab = new GameObject();
            
            for (int i = 0; i < 5; i++)
            {
                var prefObject = incomeConfig.Prefab;

                var gameObject = Object.Instantiate(prefObject, parent);
                prefab = gameObject;
                
                EcsEntity entity = world.NewEntity();
                //var bsComp=  entity.Get<BusinessComponent>();
                entity.Get<GameObjectComponent>() = new GameObjectComponent()
                {
                    GameObject = gameObject
                };

                //bsComp.Name
                    var bsComp = gameObject.GetComponent<BusinessComponent>();
                    bsComp.Name.text = incomeConfig.BuisnessModels[i].Name;
                    bsComp.LVLText.text = $"LvL \n {incomeConfig.BuisnessModels[i].LvL}";
                    bsComp.IncomText.text =$"Доход \n {incomeConfig.BuisnessModels[i].BaseIncome}"; 
                    //bsComp.Name.text = incomeConfig.BuisnessModels[i].Name;
            }
        }
    }
    public struct GameObjectComponent
    {
        public GameObject GameObject;
        public Text Name;
    }
}