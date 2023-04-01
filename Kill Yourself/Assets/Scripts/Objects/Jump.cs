using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Jump : MonoBehaviour
{
    [SerializeField] private float cooldownTime;

    private bool cooldown = true;
    private bool canJump = false;

    public bool CanJump => canJump && cooldown;

    private void FixedUpdate()
    {
        canJump = false;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (canJump)
            return;

        if (collider.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            canJump = true;
        }
            
    }

    public void Cooldown()
    {
        cooldown = false;
        DelayedCall.Create(this, () => cooldown = true, cooldownTime);
    }
}
