using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (Player.Instance.HasKey)
            {
                Player.Instance.HasKey = false;
                Unlock();
            }
        }
    }

    public void Unlock()
    {
        Destroy(gameObject);
    }
}
