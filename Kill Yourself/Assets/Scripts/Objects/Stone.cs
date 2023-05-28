using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour, ITriggeredByExplosion
{
    public void OnTriggeredByExplosion(Explosion explosion)
    {
        if (explosion.Strength == ExplosionStrength.Strong)
            Destroy();
    }

    public void Destroy()
    {
        GameObject particleSystem = transform.GetChild(0).gameObject;
        particleSystem.SetActive(true);
        particleSystem.transform.parent = null;

        Destroy(gameObject);
    }
}
