using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   
    public float playerSpeed = 20f;
    private CharacterController mvCC;
    public float momentumDamping = 5f;
    //public Animator camAnimator;
    //private bool isWalking;

    private Vector3 input;
    private Vector3 move;
    private float gravity = -10f;

    void Start()
    {
        mvCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
        //  camAnimator.SetBool("isWalking", isWalking);
    }

    void GetInput() {
        if (Input.GetKey(KeyCode.W) || 
            Input.GetKey(KeyCode.S) || 
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D))
        {
            input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            input.Normalize();
            input = transform.TransformDirection(input);
            //isWalking = true;
        } else {
            input = Vector3.Lerp(input, Vector3.zero, momentumDamping * Time.deltaTime);
            //isWalking = false;
        }
        move = (input * playerSpeed) + (Vector3.up * gravity);
    }

    void MovePlayer() {
        mvCC.Move(move * Time.deltaTime);
    }
    
}
