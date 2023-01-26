using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using SGoap;
using UnityEngine;

public class FindPriorityPickUpItemAction : BasicAction
{
    [Header("Config:")]
    [SerializeField] private FamilyAgentRuntimeData m_runtimeData;
    private ItemObject[] _worldItemObject;
    
    public override EActionStatus Perform()
    {
        
        if (AgentData.Target)
            return EActionStatus.Failed;

        var worldPickableItems = BfaWorldStateManager.Instance.TargetableWorldPickableItems;

        if (worldPickableItems is not { Count: > 0 })
            return EActionStatus.Failed;

        //Priority Check
        ItemObject cachePriorityItem = null;
        
        foreach (var itemObject in worldPickableItems)
        {
            if (!itemObject)
                continue;
            
            if (cachePriorityItem)
            {

                var currentItemAsset = itemObject.InventoryItem.ItemInfo;
                var prevItemAsset = cachePriorityItem.InventoryItem.ItemInfo;
                
                if (currentItemAsset.ComparePriority(prevItemAsset))
                    cachePriorityItem = itemObject;
            }
            else
                cachePriorityItem = itemObject;
            
        }

        if (!cachePriorityItem)
            return EActionStatus.Failed;
        
        AgentData.Target = cachePriorityItem.transform;
        BfaWorldStateManager.Instance.TargetableWorldPickableItems.Remove(cachePriorityItem);
        
        return EActionStatus.Success;
    }
}
