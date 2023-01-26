using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableAction
{
    Transform transform { get; }

    void OnInteract(object callerContext);
}