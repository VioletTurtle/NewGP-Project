using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    void onTriggerEnter(GameObject o)
    {
        if (o.tag == "Player");
            SceneManager.LoadScene("Win");
    }
}
