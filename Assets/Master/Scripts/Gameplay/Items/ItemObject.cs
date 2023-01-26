using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemObject : ModernBehaviour, ITargetable
{

    [FormerlySerializedAs("m_itemAsset")]
    [Header("Required:")]
    [SerializeField] private InventoryItem m_inventoryItem;
    
    public InventoryItem InventoryItem => m_inventoryItem;

    private void Start()
    {
        if (m_inventoryItem == null)
            Debug.LogError(name + ": Item Asset is null !!!");
    }

    protected override void Update()
    {
        //Don't delete the base.Update() else the IntervalUpdate won't work
        base.Update();
    }

    protected override void IntervalUpdate()
    {
        base.IntervalUpdate();
    }
}
