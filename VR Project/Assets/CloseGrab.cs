using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGrab : MonoBehaviour
{
    public bool ballIsClose = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballIsClose = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        ballIsClose = false;
    }
}
