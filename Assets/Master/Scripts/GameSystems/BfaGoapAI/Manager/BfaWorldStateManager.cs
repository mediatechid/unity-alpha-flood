using System;
using System.Collections;
using System.Collections.Generic;
using SGoap;
using UnityEngine;

public class BfaWorldStateManager : ModernBehaviour
{
    
    [Header("Pickable item Count World State", order = 1),SerializeField, Effect] 
    private State m_worldStatePickableItemCount;

    public List<ItemObject> TargetableWorldPickableItems { get; private set; } = new List<ItemObject>();

    public int ItemLeft { get; set; }

    #region Singleton

    public static BfaWorldStateManager Instance { get; private set; }

    private void OnEnable()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(this);
    }
    
    #endregion
    
    private void Awake()
    {
        foreach (var item in FindObjectsOfType<ItemObject>())
        {
            if (!item || !item.TryGetComponent(out IPickable itemPickable))
                continue;
            
            TargetableWorldPickableItems.Add(item);

        }

        ItemLeft = TargetableWorldPickableItems.Count;
        
        if (World.Instance.States.HasState(m_worldStatePickableItemCount.Key)) 
            World.SetState(m_worldStatePickableItemCount.Key, TargetableWorldPickableItems.Count);
        else
            World.AddState(m_worldStatePickableItemCount.Key, TargetableWorldPickableItems.Count);

    }

    protected override void IntervalUpdate()
    {
        base.IntervalUpdate();

        Debug.Log("Item left: " + TargetableWorldPickableItems.Count);
        if (ItemLeft <= 0)
        {
            BFAGameManager.Instance.GameOver();
        }

    }
}
