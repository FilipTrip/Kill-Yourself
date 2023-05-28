using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExplosionStrength { Weak, Strong }

public class Explosion : MonoBehaviour
{
    [SerializeField] private ExplosionStrength strength;
    [SerializeField] private float radius = 1.5f;
    [SerializeField] private float lifeTime = 5f;

    public ExplosionStrength Strength => strength;

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

        SoundManager.Instance.Play(strength == ExplosionStrength.Weak ? "Explosion Small" : "Explosion Large");
        Destroy(gameObject, lifeTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
