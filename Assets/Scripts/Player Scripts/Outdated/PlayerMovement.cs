using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Camera cam;
    [SerializeField] private Animator animator;

    private Vector2 movement;
    private Vector2 mousePos;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("SpeedX", movement.x);
        animator.SetFloat("SpeedY", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        // Input.mousePosition returns the pixel coordinate of cursor position
        // cam.ScreenToWorldPoint converts the pixel coordinate into unity coordinate
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        /* moveDirection is the vector between Mouse Position and Player Position
         * the player's rotation is set to always be the angle between Mouse Position and Player Position
         * therefore the player is always facing the Mouse Position
         * 
         * [CHANGE THIS LATER TO ONLY AFFECT PLAYER"S WEAPON]
         */
        Vector2 moveDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
