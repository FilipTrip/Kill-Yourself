using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : TriggerTile
{
    protected override void OnTriggered()
    {
        GameManager.Instance.LevelCompleted();
    }
}
