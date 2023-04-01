using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : TriggerTile
{
    protected override void OnTriggered()
    {
        Destroy(gameObject);
    }
}
