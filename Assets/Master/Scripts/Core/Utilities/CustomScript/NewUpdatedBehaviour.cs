using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewUpdatedBehaviour : ModernBehaviour
{
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
