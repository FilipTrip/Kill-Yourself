using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, ITriggeredByExplosion
{
    public void OnTriggeredByExplosion(Explosion explosion)
    {
        Destroy();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
