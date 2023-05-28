using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, ITriggeredByExplosion
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float friction;

    public void OnTriggeredByExplosion(Explosion explosion)
    {
        Destroy();
    }

    public void Destroy()
    {
        GameObject particleSystem = transform.GetChild(0).gameObject;
        particleSystem.SetActive(true);
        particleSystem.transform.parent = null;

        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (!rigidbody)
            return;

        rigidbody.velocity *= new Vector2(friction * Time.fixedDeltaTime, 1f);

    }
}
