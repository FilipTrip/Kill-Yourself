using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour, ITriggeredByExplosion
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;
    [SerializeField] private float friction;

    public void OnTriggeredByExplosion(Explosion explosion)
    {
        Trigger();
    }

    public void Trigger()
    {
        animator.Play("Trigger");
        DelayedCall.Create(this, Explode, 1f);
    }

    public void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity *= new Vector2(friction * Time.fixedDeltaTime, 1f);
    }
}
