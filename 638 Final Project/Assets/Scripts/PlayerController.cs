using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sprite;
    public GameObject interactText;
    
    [SerializeField] private float speed;
    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private bool _isMoving;
    
    private static readonly int IsMoving = Animator.StringToHash("isWalking");

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _isMoving = false;
    }
    
    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveInput.x * speed, _rb.velocity.y);

        anim.SetBool(IsMoving, _isMoving);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

        _isMoving = _moveInput != Vector2.zero;
        
        if (_isMoving)
            sprite.flipX = _moveInput.x < 0;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Space) && 
            other.gameObject.TryGetComponent<IInteractable>(out var interactable))
        {
            interactable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        interactText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactText.SetActive(false);
    }
}
