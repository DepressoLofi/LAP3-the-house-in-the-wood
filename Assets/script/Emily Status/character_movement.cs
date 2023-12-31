using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    Vector2 movement;
    private Animator animator;
    private bool canMove = true;
    public bool transitioning = false;
    private Player player;


    public VectorValue startingPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player= GetComponent<Player>();

        animator.SetFloat("horizontal", startingPosition.facing.x);
        animator.SetFloat("vertical", startingPosition.facing.y);
        transform.position = startingPosition.initialValue; 
    }

    void Update()
    {
        if (canMove && !player.die)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        animator.SetFloat("momentum", movement.sqrMagnitude);
        if (movement != Vector2.zero && !transitioning)
        {
            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);

            movecharacter();
        }
    }

    void movecharacter()
    {
        movement.Normalize();
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void SetCanMove(bool move)
    {
        canMove = move;
    }
    public void SetTransition(bool trans)
    {
        transitioning = trans;
    }

    

}