using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    //increase the speed depending on size
    [SerializeField] public float moveSpeed;
    public PlayerInputActions playerMovement;
    [SerializeField] public float scaleSize;
    private SpriteRenderer circlePlayer;

    Vector2 moveDirection;

    [SerializeField] private float minScale = 0.2f;
    [SerializeField] private float maxScale = 1f;

    private InputAction move;
    private InputAction fire;
    private InputAction grow;
    private InputAction shrink;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            circlePlayer = player.GetComponent<SpriteRenderer>();
        }
    }

    private void Awake()
    {
        playerMovement = new PlayerInputActions();
        this.transform.position = new Vector3(0f, 0f, 0f);
    }

    private void OnEnable()
    {
        move = playerMovement.Player.Move;
        move.Enable();

        fire = playerMovement.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

        grow = playerMovement.Player.Grow;
        grow.Enable();
        grow.performed += Grow;

        shrink = playerMovement.Player.Shrink;
        shrink.Enable();
        shrink.performed += Shrink;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        grow.Disable();
        shrink.Disable();
    }

    void Update()
    {
        // Get the movement direction from input
        moveDirection = move.ReadValue<Vector2>();
    
        // Apply movement logic (moveSpeed can be set according to your movement system)
        Vector3 newPosition = transform.position + new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed * Time.deltaTime;
    
        // Clamp the new position within the defined boundaries (e.g., -21 to 21 for x and y)
        newPosition.x = Mathf.Clamp(newPosition.x, -21f, 21f);
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);
    
        // Apply the clamped position to the transform
        transform.position = newPosition;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("We fired");
    }

    private void Grow(InputAction.CallbackContext context)
    {
        if (rb.transform.localScale.x >= maxScale)
        {
            Debug.Log("Cannot grow, max scale reached");
            return;
        }

        Vector3 newScale = rb.transform.localScale + new Vector3(scaleSize, scaleSize, 0f);

        if (newScale.x <= maxScale)
        {
            rb.transform.localScale = newScale;
            Debug.Log("We Grew");
        }
    }

    private void Shrink(InputAction.CallbackContext context)
    {
        if (rb.transform.localScale.x <= minScale)
        {
            Debug.Log("Cannot shrink, min scale reached");
            return;
        }

        Vector3 newScale = rb.transform.localScale - new Vector3(scaleSize, scaleSize, 0f);

        if (newScale.x >= minScale)
        {
            rb.transform.localScale = newScale;
            Debug.Log("We Shrank");
        }
    }
}