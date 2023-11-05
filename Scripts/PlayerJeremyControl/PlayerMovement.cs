using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string MOVEMENT_SPEED = "Speed";
    private const float ANIMATION_DAMPENING = 0.1f;

    //VARIABLES
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    //REFERENCES
    private CharacterController characterController;
    private Animator animator;

    private void Start() {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        Move();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
        }
    }

    private void Move() {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {

                Idle();
            }
            moveDirection *= moveSpeed * Time.deltaTime;

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }

        characterController.Move(moveDirection);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void Idle() => animator.SetFloat(MOVEMENT_SPEED, 0f, ANIMATION_DAMPENING, Time.deltaTime);

    private void Walk() {
        moveSpeed = walkSpeed;
        animator.SetFloat(MOVEMENT_SPEED, 0.5f, ANIMATION_DAMPENING, Time.deltaTime);
    }

    private void Run() {
        moveSpeed = runSpeed;
        animator.SetFloat(MOVEMENT_SPEED, 1f, ANIMATION_DAMPENING, Time.deltaTime);
    }

    private void Jump() => velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

    private IEnumerator Attack() {
        animator.SetLayerWeight(animator.GetLayerIndex("Attack Layer"), 1);
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.9f);
        animator.SetLayerWeight(animator.GetLayerIndex("Attack Layer"), 0);
    }
}
