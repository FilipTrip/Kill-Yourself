using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, ITriggeredByExplosion
{
    public static Player Instance { get; private set; }

    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private GameObject keyObject;
    [SerializeField] private SpriteRenderer keySpriteRenderer;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Jump jump;

    [Header("Values")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;

    [Header("Animation")]
    [SerializeField] private Sprite[] idleSprites;
    [SerializeField] private Sprite[] movingLeftSprites;
    [SerializeField] private Sprite[] movingRightSprites;
    [SerializeField] private float animationInterval;

    private Sprite[] activeSprites;
    private float animationTimer;
    private int animationIndex;

    private bool hasKey;

    public static UnityEvent OnKilled = new UnityEvent();
    public static UnityEvent OnSpawned = new UnityEvent();
    public static UnityEvent KeysChanged = new UnityEvent();

    public bool HasKey
    {
        get { return hasKey; }
        set { hasKey = value; keyObject.SetActive(value); }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnSpawned.Invoke();
        KeysChanged.Invoke();
        activeSprites = idleSprites;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(horizontalInput * movementSpeed, rigidbody.velocity.y);

        if (jump.CanJump && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            rigidbody.AddForce(new Vector2(0f, jumpForce * Physics.gravity.magnitude));
            jump.Cooldown();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Kill();
        }

        Animate(horizontalInput);
    }

    public void Kill()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        OnKilled.Invoke();
    }

    public void OnTriggeredByExplosion(Explosion explosion)
    {
        Kill();
    }

    private void Animate(float horizontalInput)
    {
        bool newAnimation = false;
        Sprite[] previousSprites = activeSprites;

        // Determine which animation to use

        if (horizontalInput < 0f)
            activeSprites = movingLeftSprites;

        else if (horizontalInput > 0f)
            activeSprites = movingRightSprites;

        else
            activeSprites = idleSprites;

        // Check if animation was changed

        if (previousSprites != activeSprites)
            newAnimation = true;

        // Animate

        if (newAnimation)
            animationTimer = 0f;
        else
            animationTimer -= Time.deltaTime;

        if (animationTimer <= 0f)
        {
            animationTimer += animationInterval;
            animationIndex++;

            if (animationIndex >= activeSprites.Length)
                animationIndex = 0;

            spriteRenderer.sprite = activeSprites[animationIndex];
        }

        // Move key

        if (hasKey)
        {
            if (activeSprites == idleSprites)
            {
                keyObject.transform.localPosition = new Vector3(0.38f, keyObject.transform.localPosition.y, 0f);
                keySpriteRenderer.flipX = false;
            }

            else if (activeSprites == movingLeftSprites)
            {
                keyObject.transform.localPosition = new Vector3(-0.28f, keyObject.transform.localPosition.y, 0f);
                keySpriteRenderer.flipX = true;
            }

            else if (activeSprites == movingRightSprites)
            {
                keyObject.transform.localPosition = new Vector3(0.28f, keyObject.transform.localPosition.y, 0f);
                keySpriteRenderer.flipX = false;
            }
        }
    }
}
