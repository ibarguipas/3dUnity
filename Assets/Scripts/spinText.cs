using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinText : MonoBehaviour
{

    //Este codig es para girar el texto

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        if (player != null)
        {
            Quaternion camRotation = Camera.main.transform.rotation;

            // Establece la rotación del objeto en el eje Y de acuerdo a la cámara
            transform.rotation = Quaternion.Euler(0f, camRotation.eulerAngles.y, 0f);

        }
    }
}
