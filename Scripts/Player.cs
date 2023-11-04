using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private GameInput gameInput;


    [SerializeField] private float rotateSpeedTP = 7f;
    [SerializeField] private float rotateSpeedCC = 150f;
    //Test bools
    [SerializeField] private bool characterControllerBool = false;
    [SerializeField] private bool rigidBodyBool = false;
    [SerializeField] private bool transformPositionBool = true;
    //[SerializeField] private Entity entity;

    private CharacterController characterController;
    private Rigidbody rb;

    private bool isWalking;


    /// <summary>
    /// Need to fix player rotation causing a bug where it offsets the avatar by a bit. Caused by playing walking animation while rotating.
    /// </summary>


    private void Start() {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {

        //Get inputs for characterController and rigidBody
        float horizonalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (characterControllerBool)
        {
            Vector3 movement = transform.forward * verticalInput + transform.right * horizonalInput;
            isWalking = movement != Vector3.zero;
            characterController.Move(movement * moveSpeed * Time.deltaTime);

            //RotatePlayer();
        }
        else if (rigidBodyBool)
        {
            Vector3 movement = new Vector3(horizonalInput, 0, verticalInput);
            rb.AddForce(movement * moveSpeed);
        }
        else if (transformPositionBool)
        {
            Vector2 inputVector = gameInput.GetMovementNormalized();

            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.position += moveDir * moveSpeed * Time.deltaTime;

            isWalking = moveDir != Vector3.zero;

            transform.forward = Vector3.Lerp(transform.forward, moveDir , rotateSpeedTP * Time.deltaTime);

        }


    }

    public bool IsWalking() {
        return isWalking;
    }


}
