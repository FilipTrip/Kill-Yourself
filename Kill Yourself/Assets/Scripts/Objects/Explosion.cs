using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float radius = 1.5f;
    [SerializeField] private float lifeTime = 5f;

    private void Start()
    {
        Explode();
    }

    private void Explode()
    {
        Collider2D[] collideres = Physics2D.OverlapCircleAll(transform.position, radius);

        ITriggeredByExplosion triggeredByExplosion;
        foreach (Collider2D collider in collideres)
        {
            triggeredByExplosion = collider.GetComponent<ITriggeredByExplosion>();

            if (triggeredByExplosion != null)
                triggeredByExplosion.OnTriggeredByExplosion(this);
        }

        Destroy(gameObject, lifeTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
