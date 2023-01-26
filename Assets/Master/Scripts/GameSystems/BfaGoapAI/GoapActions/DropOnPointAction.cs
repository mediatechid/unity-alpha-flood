using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using SGoap;
using UnityEngine;

public class DropOnPointAction : MoveToAction2D
{
    [Header("Required Data:")] 
    [SerializeField] private FamilyAgentRuntimeData m_runtimeData;

    public override bool PrePerform()
    {
        if (!AgentData.Target)
            return false;
        
        return base.PrePerform();
    }

    protected override IEnumerator ExecuteRoutine()
    {
        if (m_runtimeData.PickedUpItem == null)
            return base.ExecuteRoutine();
        
        m_runtimeData.InventoryComponent.AddItem(m_runtimeData.PickedUpItem);
        m_runtimeData.PickedUpItem = null;
        AgentData.Target = null;
        BfaWorldStateManager.Instance.ItemLeft--;
        return base.ExecuteRoutine();
    }
}
