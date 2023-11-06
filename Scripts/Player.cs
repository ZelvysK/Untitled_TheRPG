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

    //[SerializeField] private float rotateSpeedTP = 7f;
    //[SerializeField] private float rotateSpeedCC = 150f;
    //Test bools
    //[SerializeField] private bool characterControllerBool = false;
    //[SerializeField] private bool rigidBodyBool = false;
    //[SerializeField] private bool transformPositionBool = true;
    //[SerializeField] private Entity entity;

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

        //if (characterControllerBool)
        //{
        //    Vector3 movement = transform.forward * verticalInput + transform.right * horizonalInput;
        //    isWalking = movement != Vector3.zero;
        //    characterController.Move(movement * moveSpeed * Time.deltaTime);

        //    //RotatePlayer();
        //}
        //else if (rigidBodyBool)
        //{
        //    Vector3 movement = new Vector3(horizonalInput, 0, verticalInput);
        //    rb.AddForce(movement * moveSpeed);
        //}
        //else if (transformPositionBool)
        //{
        //    Vector2 inputVector = gameInput.GetMovementNormalized();

        //    Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        //    transform.position += moveDir * moveSpeed * Time.deltaTime;

        //    isWalking = moveDir != Vector3.zero;

        //    transform.forward = Vector3.Lerp(transform.forward, moveDir, rotateSpeedTP * Time.deltaTime);
        //}
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
