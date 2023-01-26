using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionComponent : PlayerComponentBase
{
    [SerializeField] private float m_updateInterval = 0.5f;

    [Header("Optimization:")] [SerializeField]
    private bool m_isDebug = false;

    [SerializeField, Min(1)] private int m_maxObjectsDetection = 10;
    [SerializeField] private LayerMask m_targetObjectsLayer;

    [Space] [Header("Config:")] [SerializeField]
    private float m_interactionRange = 2.5f;

    [Space] [Header("Events:")] [SerializeField]
    public UnityEvent m_onInteract;

    [SerializeField] public UnityEvent m_onFocused;
    [SerializeField] public UnityEvent m_endFocused;

    public IInteractableAction FocusedObject { get; private set; }

    public bool IsOwnerMoving => _movementComponent.IsMoving;

    public IInteractableAction[] ObjectsInRange => _objectsInRange.ToArray();

    public float InteractionRange => m_interactionRange;

    private PlayerMovementComponent _movementComponent;
    private Collider2D[] _collidersInRange;
    private IInteractablePrompt _focusedObjPrompt;
    private List<IInteractableAction> _objectsInRange;
    private float _updateTimer;

    public override void ComponentInit()
    {

        GameplayInputManager.Instance.CharacterInput.Interact.performed += inputContext => { if (FocusedObject != null) Interact(); };

        _movementComponent = OwnerController.GetControllerComponent<PlayerMovementComponent>();
        _collidersInRange = new Collider2D[m_maxObjectsDetection];
        _objectsInRange = new List<IInteractableAction>(m_maxObjectsDetection);
    }

    public override void ComponentUpdate(float deltaTime)
    {
        if (_updateTimer >= m_updateInterval)
        {
            _updateTimer += deltaTime;
            return;
        }
        else
            _updateTimer = 0;

        if (GetObjectsInRange())
        {
            var cacheFocusedObject = GetClosestObject();

            if (cacheFocusedObject != FocusedObject && cacheFocusedObject != null)
            {
                if (FocusedObject != null)
                    ResetFocusedObject();

                SetFocusedObject(cacheFocusedObject);

            }
        }
        else
        {
            _objectsInRange.Clear();
            ResetFocusedObject();
        }
    }

    /// <summary>
    /// Call this to interact with a focused Object
    /// </summary>
    protected virtual void Interact()
    {
        FocusedObject.OnInteract(OwnerController);
        m_onInteract?.Invoke();
        
    }

    private void SetFocusedObject(in IInteractableAction focusedObject)
    {
        FocusedObject = focusedObject;

        _focusedObjPrompt = FocusedObject as IInteractablePrompt;
        _focusedObjPrompt?.OnFocused();

        m_onFocused?.Invoke();
    }

    private void ResetFocusedObject()
    {
        if (FocusedObject == null) return;

        m_endFocused?.Invoke();
        _focusedObjPrompt?.EndFocused();
        _focusedObjPrompt = null;
        FocusedObject = null;
    }

    /// <summary>
    /// Get the closest object in range
    /// </summary>
    /// <returns></returns>
    private IInteractableAction GetClosestObject()
    {
        IInteractableAction cacheObject = null;

        foreach (var objInRange in _objectsInRange)
        {
            if (cacheObject == null)
                cacheObject = objInRange;
            else
            {
                var position = OwnerController.transform.position;

                var ownerToCacheObject =
                    Vector3.Distance(position, cacheObject.transform.position);

                var ownerToObjInRange =
                    Vector3.Distance(position, objInRange.transform.position);

                if (ownerToCacheObject > ownerToObjInRange)
                    cacheObject = objInRange;

            }
        }

        return cacheObject;
    }

    /// <summary>
    /// Get Objects in range that will be stored at ObjectsInRange variable
    /// </summary>
    /// <returns> Whether there is objects in range or not </returns>
    private bool GetObjectsInRange()
    {
        _objectsInRange.Clear();
        System.Array.Clear(_collidersInRange, 0, _collidersInRange.Length);

        var detectedColliders = Physics2D.OverlapCircleNonAlloc(OwnerController.BodyCenterPoint.position,
            m_interactionRange,
            _collidersInRange, m_targetObjectsLayer);

        if (detectedColliders > 0)
        {
            foreach (var objInRange in _collidersInRange)
            {
                if (!objInRange) continue;
                if (objInRange.TryGetComponent(out IInteractableAction cacheObj))
                    _objectsInRange.Add(cacheObj);

            }
        }

        return _objectsInRange.Count > 0;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (m_isDebug && OwnerController)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(OwnerController.BodyCenterPoint.position, m_interactionRange);
        }
    }
#endif
}

