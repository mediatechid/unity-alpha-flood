using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour, IInteractableAction, IInteractablePrompt
{
    public void OnInteract(object callerContext)
    {
        if (callerContext is MonoBehaviour callerComponent)
        {
            if (callerComponent.TryGetComponent(out PlayerRuntimeData playerRuntimeData) &&
                callerComponent.TryGetComponent(out CharacterInventoryComponent inventoryComponent))
            {
                if (playerRuntimeData.PickedUpItem == null)
                    return;
                
                //Check Player Runtime Data for the pick up item
                //If valid remove it from the runtime data and add it to inventory
                //As Simple as that future me
                inventoryComponent.AddItem(playerRuntimeData.PickedUpItem);
                playerRuntimeData.PickedUpItem = null;
                --BfaWorldStateManager.Instance.ItemLeft;

            }
        }
    }

    public void OnFocused()
    {
        Debug.Log("Focused");
    }

    public void EndFocused()
    {
        Debug.Log("end fcoused");
    }
}
