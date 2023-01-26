using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FamilyAgentRuntimeData : MonoBehaviour
{
    [Header("Required:")]
    [SerializeField] private Transform m_dropPoint;
    [SerializeField] private CharacterInventoryComponent m_inventoryComponent;
    
    public Transform DropPoint => m_dropPoint;
    public CharacterInventoryComponent InventoryComponent => m_inventoryComponent;

    /// <summary>
    /// AI Character Picked Up Item
    /// </summary>
    public InventoryItem PickedUpItem { get; set; }
    
    private void Start()
    {

    }
}
