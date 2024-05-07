using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sprite;
    private GameObject _interactText;
    
    [SerializeField] private float speed;
    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private bool _isMoving;
    // private bool _bufferedInput;

    public GameObject dialogueText;

    private static readonly int IsMoving = Animator.StringToHash("isWalking");

    private IInteractable _interacting;

    // Start is called before the first frame update
    private void Start()
    {
        // _bufferedInput = false;
        _interactText = GameObject.FindGameObjectWithTag("Interact Text");
        _interactText.SetActive(false);
        _rb = GetComponent<Rigidbody2D>();
        _isMoving = false;
    }

    private void Update()
    {
        // _bufferedInput = Input.GetKey(KeyCode.Space);
        if (_interacting != null && Input.GetKeyDown(KeyCode.Space))
            _interacting.Interact();
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
        // if ((_bufferedInput || Input.GetKey(KeyCode.Space)) && 
        //     other.gameObject.TryGetComponent<IInteractable>(out var interactable))
        // {
        //     interactable.Interact();
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.TryGetComponent<IInteractable>(out var interactable);
        _interacting = interactable;
        
        if (_interactText != null)
            _interactText.SetActive(true);
        
        if (dialogueText != null && other.CompareTag("Guy"))
            dialogueText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _interacting = null;
        
        if (_interactText != null)
            _interactText.SetActive(false);
        
        if (dialogueText != null && other.CompareTag("Guy"))
            dialogueText.SetActive(true);
    }
}
