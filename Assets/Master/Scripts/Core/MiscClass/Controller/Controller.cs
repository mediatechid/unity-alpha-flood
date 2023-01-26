using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// A Controller Base Class
/// </summary>
/// <typeparam name="TComponentBase">The controller components base type</typeparam>
public class Controller<TComponentBase> : MonoBehaviour
    where TComponentBase : MonoBehaviour
{
    protected TComponentBase[] ControllerComponents;

    protected virtual void Awake() => ControllerComponents = GetComponentsInChildren<TComponentBase>();

    protected virtual void Update()
    {
    }

    protected virtual void FixedUpdate()
    {
    }

    protected virtual void LateUpdate()
    {
    }

    public virtual T GetControllerComponent<T>() where T : MonoBehaviour
    {
        return ControllerComponents
            .OfType<T>()
            .Select(t => t)
            .FirstOrDefault();
    }
}
