using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public struct ItemData
{
    [Header("Item Information:")]
    [SerializeField] private string m_itemName;
    [SerializeField, TextArea] private string m_itemDesc;
    [Space]
    [SerializeField,ShowAssetPreview] private Sprite m_itemIcon;
    [SerializeField] private bool m_isStackable;
    [SerializeField] private int m_scorePerItem;
    [Space]
    [SerializeField] private EPriorityState m_priorityState;
    [SerializeField] private int m_itemPriority;

    public string ItemName => m_itemName;
    public string ItemDescription => m_itemDesc;
    public Sprite ItemItemIcon => m_itemIcon;
    public bool IsStackable => m_isStackable;
    public int ScorePerItem => m_scorePerItem;
    public EPriorityState ItemPriorityState => m_priorityState;
    public int ItemPriority => m_itemPriority;
}
