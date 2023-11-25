using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killPlayer : MonoBehaviour
{
    //Este codigo recarga la escena inicial cuando tocas esta lo suficientemente profundo en el agua

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            Debug.Log("toco");
            SceneManager.LoadScene("Escena1");

        }
    }
}
