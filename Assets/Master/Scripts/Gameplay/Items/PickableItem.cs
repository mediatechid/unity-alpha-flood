using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : ItemObject, IPickable, IInteractablePrompt, IInteractableAction
{
    
    [SerializeField] private SGoap.StringReference m_worldItemCountState;
    
    public void OnInteract(object callerContext) => OnPick(callerContext);
    
    public void OnPick(object contextCaller)
    {
        if (contextCaller is MonoBehaviour caller)
        {
            if (caller.CompareTag("Player"))
            {
                if (caller.TryGetComponent(out PlayerRuntimeData playerRuntimeData))
                {
                    if (playerRuntimeData.PickedUpItem != null)
                        return;
                    
                    playerRuntimeData.PickedUpItem = InventoryItem;
                    
                }
            }
        }
        
        SGoap.World.ModifyState(m_worldItemCountState.Value, -1);
        BfaWorldStateManager.Instance.TargetableWorldPickableItems.Remove(this);
        Destroy(gameObject);
    }

    public void OnFocused()
    {
    }

    public void EndFocused()
    {
    }
}
