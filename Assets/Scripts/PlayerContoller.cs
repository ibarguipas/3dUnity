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

        // Calcula la dirección de movimiento basada en las teclas de entrada Horizontal y Vertical
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection.Normalize();  // Normaliza el vector para mantener la misma dirección pero con magnitud 1
        moveDirection = moveDirection * movespeed; // Aplica la velocidad de movimiento a la dirección


        moveDirection.y = yStore; // Restaura la componente y del vector de movimiento



        //salto

        if (playerController.isGrounded)
        {
           

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpforce; // Aplica la fuerza de salto a la componente y del vector de movimiento
            
            }
        }
        

        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale; // Aplica la gravedad al movimiento en el eje y

        playerController.Move(moveDirection * Time.deltaTime); // Mueve el jugador usando CharacterController con la dirección de movimiento




        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {

            // Ajusta la rotación del jugador para mirar en la dirección de movimiento
            transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);

        }


        // Configuración de animaciones

        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));


        animator.SetBool("isGrounded", playerController.isGrounded);

    }


}
