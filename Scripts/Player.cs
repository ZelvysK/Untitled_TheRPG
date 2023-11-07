using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO:
// Fix player rotation causing a bug where it offsets the avatar by a bit. Caused by playing walking animation while rotating.
public class Player : MonoBehaviour
{

    //VARIABLES
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 7f;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private GameInput gameInput;

    private float blendFloat;
    private Vector3 moveDir;
    //private Vector3 velocity;

    //REFERENCES
    private CharacterController characterController;
    //private Rigidbody rb;

    private bool isWalking;

    private void Start() {
        characterController = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();

        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        //Get inputs for characterController and rigidBody
        //float moveX = Input.GetAxis("Horizontal");
        //float moveZ = Input.GetAxis("Vertical");
        Rotate();

        Vector2 inputVector = gameInput.GetMovementNormalized();

        moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        moveDir = transform.TransformDirection(moveDir);

        if (moveDir != Vector3.zero && !gameInput.GetSprintInput())
        {
            Walk();
        }
        else if (moveDir != Vector3.zero && gameInput.GetSprintInput())
        {
            Run();
        }
        else if (moveDir == Vector3.zero)
        {
            Idle();
        }
        moveDir *= moveSpeed * Time.deltaTime;

        characterController.Move(moveDir);
    }

    public bool IsWalking() => isWalking;

    public float GetBlendFloat() => blendFloat;

    private void Idle() {
        isWalking = false;
        blendFloat = 0f;
    }
    private void Walk() {
        moveSpeed = walkSpeed;
        isWalking = true;
        blendFloat = 0.5f;
    }
    private void Run() {
        moveSpeed = runSpeed;
        isWalking = true;
        blendFloat = 1f;
    }

    private void Rotate() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up, mouseX);
    }
}
