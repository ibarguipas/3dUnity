using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightController : MonoBehaviour
{

    public Light myLight;
    bool onRange = false;
    public GameObject textoFlotante;

    // Start is called before the first frame update
    void Start()
    {
        textoFlotante.SetActive(false);
        myLight = GetComponent<Light>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //Desactiva o activa la luz si el jugador esta dentro del area y presiona "E"

        if (Input.GetKeyDown(KeyCode.E) && onRange)
        {
            myLight.enabled = !myLight.enabled;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            onRange = true;
            textoFlotante.SetActive(true); // Activa el texto flotante cuando el jugador se acerque
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            onRange = false;
            textoFlotante.SetActive(false); // Desactiva el texto flotante cuando el jugador se aleje
        }
    }
}
