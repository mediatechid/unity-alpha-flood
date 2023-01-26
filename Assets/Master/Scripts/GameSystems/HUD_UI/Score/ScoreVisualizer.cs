using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreVisualizer : BaseHUD
{
    [Header("Required:")] 
    [SerializeField] private string m_ownerName;
    [SerializeField] private CharacterInventoryComponent m_ownerInventory;
    [Space, Header("Visual:")]
    [SerializeField] private TextMeshProUGUI m_ownerText;
    [SerializeField] private TextMeshProUGUI m_scoreDescText;

    private Dictionary<ItemAsset, InventoryItem> OwnerDictionary => m_ownerInventory.ItemsDictionary;

    protected override void StartHUD()
    {
        base.StartHUD();
    }

    protected override void UpdateHUD()
    {
        base.UpdateHUD();
        if (OwnerDictionary == null)
        {
            Debug.Log("iwvjq-jqw-d0");
        }
    }

    public void VisualizeScore()
    {
        m_ownerText.text = m_ownerName;
        m_scoreDescText.text = GetScoreDescription();
    }

    public int GetTotalItemPicked() => OwnerDictionary.Values.Sum(inventoryItem => inventoryItem.StackUnit);

    public int GetTotalScore() => OwnerDictionary.Keys.Sum(itemType => (itemType.ScorePerItem * OwnerDictionary[itemType].StackUnit));

    public string GetScoreDescription() => GetTotalItemPicked() + " items picked, with total score " + GetTotalScore();
    
}
