using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    public float movespeed;
    public float jumpforce;
    public CharacterController playerController;
    public float gravityScale;
    public Camera playerCamera;
    public GameObject playerModel;
    public float rotateSpeed;
    public Animator animator;


    private Vector3 moveDirection;
    private float yStore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yStore = moveDirection.y;


        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection.Normalize();
        moveDirection = moveDirection * movespeed;

        moveDirection.y = yStore;





        //salto

        if (playerController.isGrounded)
        {
           

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpforce;
            }
        }
        

        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

        playerController.Move(moveDirection * Time.deltaTime);

        


        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);

        }
        else 
        {
            playerCamera.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));


        animator.SetBool("isGrounded", playerController.isGrounded);

    }


}
