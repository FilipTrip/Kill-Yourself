using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private float delay;

    private Player player;

    private void Start()
    {
        DelayedCall.Create(this, SpawnPlayer, 0.5f);
        Player.OnKilled.AddListener(() => DelayedCall.Create(this, SpawnPlayer, delay));
    }

    public void SpawnPlayer()
    {
        player = Instantiate(playerPrefab).GetComponent<Player>();
        player.transform.position = transform.position;
    }
}
