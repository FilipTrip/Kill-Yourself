using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool goBack;
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;
    [SerializeField] private UnityEvent OnPressed;

    private List<Collider2D> colliders = new List<Collider2D>();
    private bool on;

    public bool On => on;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        colliders.Add(collider);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        colliders.Remove(collider);
    }

    private void Update()
    {
        if (on)
        {
            if (!goBack)
                return;

            if (colliders.Count == 0)
            {
                on = false;
                spriteRenderer.sprite = offSprite;
            }
        }

        else
        {
            if (colliders.Count > 0)
            {
                on = true;
                spriteRenderer.sprite = onSprite;
                OnPressed.Invoke();
            }
        }
    }
}
