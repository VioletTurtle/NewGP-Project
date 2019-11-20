using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    void OnTriggerEnter(Collider o)
    {
        //if (o.tag == "Player")
        if (o.gameObject.CompareTag("Player1"))
        {
            SceneManager.LoadScene("Win");
        }
            
    }
}
