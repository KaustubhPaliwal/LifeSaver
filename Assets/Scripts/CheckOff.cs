using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOff : MonoBehaviour
{
    public GameObject objectToDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ControllerGrabLocation" || other.gameObject.name == "Collider")
        {
            Destroy(objectToDestroy);
        }
    }
}
