using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class BaseHUD : MonoBehaviour
{
    [Header("Config:")] [SerializeField] private bool m_hideAtStart = false;
    [SerializeField] private bool m_usingSetActiveObject = false;
    [SerializeField] private CanvasGroup m_hudCanvasGroup;

    #region Public Property

    /// <summary>
    /// Only to read the HUD visibility, change the HUD Visibility using SetVisibility() function instead!
    /// </summary>
    public bool HUDVisibility => m_hudCanvasGroup.alpha > 0;

    private bool IsChangingVisibility { get; set; }

    /// <summary>
    /// The current visibility of a HUD. Can be change using SetVisibility() Function
    /// </summary>
    public bool Visibility
    {
        get => _visibility;
        private set
        {
            _visibility = value;
            OnVisibilityChange?.Invoke(value);
        }
    }

    public UnityAction<bool> OnVisibilityChange { get; set; }

    #endregion

    /// <summary>
    /// Always use Visibility public property to change the value
    /// </summary>
    private bool _visibility;

    protected void Awake()
    {
        InitHUD();
    }

    protected void Start()
    {

        _visibility = true;

        if (m_hideAtStart)
        {
            if (m_hudCanvasGroup)
            {
                SetVisibility(false);
            }
            else
                Debug.Log("HUD Component Missing canvas group");
        }

        StartHUD();

    }

    protected void LateUpdate() => UpdateHUD();

    #region VisibilityFunction

    public void SetVisibility(bool visibility)
    {
        if (Visibility == visibility || IsChangingVisibility)
            return;

        // Instant Change
        if (visibility)
        {
            m_hudCanvasGroup.alpha = 1;
            if (Visibility != visibility)
                Visibility = visibility;
        }
        else
        {
            m_hudCanvasGroup.alpha = 0;
            if (Visibility != visibility)
                Visibility = visibility;

        }

        if (m_usingSetActiveObject)
            m_hudCanvasGroup.gameObject.SetActive(visibility);
    }

    #endregion

    #region ChildFunction

    protected virtual void InitHUD()
    {
    }

    protected virtual void StartHUD()
    {
    }

    protected virtual void UpdateHUD()
    {
    }

    #endregion

}