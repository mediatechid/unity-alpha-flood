using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAction : MoveToAction2D
    {

        [SerializeField] private FamilyAgentRuntimeData m_runtimeData;
        
        protected override IEnumerator ExecuteRoutine()
        {
            if (!AgentData.Target) return base.ExecuteRoutine();
            if (!AgentData.Target.TryGetComponent(out ItemObject itemObject)) return base.ExecuteRoutine();
            if (itemObject is not IPickable pickableItem) return base.ExecuteRoutine();
                
            m_runtimeData.PickedUpItem = itemObject.InventoryItem;
            Debug.Log("Ai Picking :3");
            pickableItem.OnPick(AgentData.Agent);

            AgentData.Target = m_runtimeData.DropPoint;
            
            return base.ExecuteRoutine();
        }
    }
