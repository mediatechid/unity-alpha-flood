using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractablePrompt
{
    void OnFocused();
    void EndFocused();
}
