using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerTile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
            OnTriggered();
    }

    protected abstract void OnTriggered();
}
