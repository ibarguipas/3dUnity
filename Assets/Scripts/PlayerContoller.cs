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

        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveDirection = moveDirection * movespeed;

        moveDirection.y = yStore;

        



        //salto
        if (Input.GetButtonDown("Jump")) 
        {
            moveDirection.y = jumpforce;
        }

        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

        playerController.Move(moveDirection * Time.deltaTime);


        transform.rotation = Quaternion.Euler(0f,playerCamera.transform.rotation.eulerAngles.y, 0f);

    }


}
