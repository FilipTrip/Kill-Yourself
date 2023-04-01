using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour, ITriggeredByExplosion
{
    [SerializeField] private GameObject explosionPrefab;

    public void OnTriggeredByExplosion(Explosion explosion)
    {
        Explode();
    }

    public void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
