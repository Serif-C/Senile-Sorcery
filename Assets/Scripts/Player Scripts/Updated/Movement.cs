using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private float moveSpeed = 12f;

    [SerializeField] private Animator animator;

    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(inputX * moveSpeed, inputY * moveSpeed) * Time.deltaTime;

        // Play WalkHorizontal animation when moving on the x-axis
        if(Mathf.Abs(inputX) > 0)
        {
            // IsWalkingRight is true when moving on positive x-axis, IsWalkingLeft is false
            if (inputX > 0)
            {
                animator.SetBool("IsWalkingRight", true);
                animator.SetBool("IsWalkingLeft", false);
            }
            // IsWalkingRight is false when moving on negatice x-axis, IsWalkingLeft is true
            else if (inputX < 0)
            {
                animator.SetBool("IsWalkingRight", false);
                animator.SetBool("IsWalkingLeft", true);
            }
        }
        // Stops WalkHorizontal animation when not moving on the x-axis
        else
        {
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingLeft", false);
        }

        // Play WalkUp/Down animation when moving on the y-axis
        if (Mathf.Abs(inputY) > 0)
        {
            // IsWalkingUp is true when moving on positive y-axis, IsWalkingDown is false
            if (inputY > 0)
            {
                animator.SetBool("IsWalkingUp", true);
                animator.SetBool("IsWalkingDown", false);
            }
            // IsWalkingUp is false when moving on negative y-axis, IsWalkingDown is true
            else if (inputY < 0)
            {
                animator.SetBool("IsWalkingUp", false);
                animator.SetBool("IsWalkingDown", true);
            }
        }
        // Stops WalkUp/Down animation when not moving on the y-axis
        else
        {
            animator.SetBool("IsWalkingUp", false);
            animator.SetBool("IsWalkingDown", false);
        }


        transform.position += move;
    }
}
