using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasySurvivalScripts
{
    public enum PlayerStates
    {
        Idle,
        Walking,
        Running,
        Jumping
    }

    public class PlayerMovement : MonoBehaviour
    {
        public PlayerStates playerStates;

        [Header("Inputs")]
        public string HorizontalInput = "Horizontal";
        public string VerticalInput = "Vertical";
        public string RunInput = "Run";
        public string JumpInput = "Jump";

        [Header("Player Motor")]
        [Range(1f,15f)]
        public float walkSpeed;
        [Range(1f,15f)]
        public float runSpeed;
        [Range(1f,15f)]
        public float JumpForce;

        CharacterController characterController;

        // Use this for initialization
        void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            //handle controller
            HandlePlayerControls();
        }

        void HandlePlayerControls()
        {
            float hInput = Input.GetAxisRaw(HorizontalInput);
            float vInput = Input.GetAxisRaw(VerticalInput);

            Vector3 fwdMovement = characterController.isGrounded == true ? transform.forward * vInput : Vector3.zero;
            Vector3 rightMovement = characterController.isGrounded == true ? transform.right * hInput : Vector3.zero;

            float _speed = Input.GetButton(RunInput) ? runSpeed : walkSpeed;
            if (!elevDoor.doorClosed)
            {
                characterController.SimpleMove(Vector3.ClampMagnitude(fwdMovement + rightMovement, 1f) * _speed);
            }

            if (characterController.isGrounded)
                Jump();

            //Managing Player States
            if (characterController.isGrounded)
            {
                if (hInput == 0 && vInput == 0)
                    playerStates = PlayerStates.Idle;
                else
                {
                    if (_speed == walkSpeed)
                        playerStates = PlayerStates.Walking;
                    else
                        playerStates = PlayerStates.Running;
                }
            }
            else
                playerStates = PlayerStates.Jumping;
        }

        void Jump()
        {
            if (Input.GetButtonDown(JumpInput) && !elevDoor.doorClosed)
            {
                StartCoroutine(PerformJumpRoutine());
            }
        }

        IEnumerator PerformJumpRoutine()
        {
            float _jump = JumpForce;

            do
            {
                characterController.Move(Vector3.up * _jump * Time.deltaTime);
                _jump -= Time.deltaTime;
                yield return null;
            }
            while (!characterController.isGrounded);
        }

    }
}