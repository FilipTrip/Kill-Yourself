using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : TriggerTile
{
    protected override void OnTriggered()
    {
        if (!Player.Instance.HasKey)
        {
            Player.Instance.HasKey = true;
            Destroy(gameObject);
        }
    }
}
