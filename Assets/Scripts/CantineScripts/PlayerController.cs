using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(CharacterController))]

public class PlayerController: NetworkBehaviour
{

    //!!!Values For the Character Controller
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public GameObject interactableText;
    public ActiveObject activeObjectScript;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        //!!!Character controller
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        // Disable camera if we are not the local player
        if(!isLocalPlayer)
        {
            playerCamera.gameObject.SetActive(false);
        }

        //Find the interactable object
        activeObjectScript = GameObject.FindGameObjectWithTag("Active Object").GetComponent<ActiveObject>();
    }

    void Update()
    {
        /// !!! Character Controller
        //if we are not the main client, don't run this method
        if (!isLocalPlayer)
        {
            return;
        }
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (!isLocalPlayer)
        {
            return;
        }

        interactableText.SetActive(true);    

        if (Input.GetKeyDown(KeyCode.E) && activeObjectScript.activeObjectWindow.activeInHierarchy == false)
        {    
            activeObjectScript.EnableActiveObjectWindow();
            interactableText.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.E) && activeObjectScript.activeObjectWindow.activeInHierarchy == true)
        {
            activeObjectScript.EnableActiveObjectWindow();
            interactableText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if (!isLocalPlayer)
        {
            return;
        }

        //if (other.tag == "Player" && !isLocalPlayer)
        interactableText.SetActive(false);
        activeObjectScript.activeObjectWindow.SetActive(false);
    }
}
