using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public Canvas canvasToDestroy;
    public Canvas canvasToInstantiate;

    private void OnTriggerEnter(Collider other)
    {
        if (canvasToDestroy != null && canvasToInstantiate != null)
        {
            if (other.gameObject.name == "ControllerGrabLocation" || other.gameObject.name == "Collider")
            {
                // Get the position and rotation of the canvas to be destroyed
                Vector3 position = canvasToDestroy.transform.position;
                Quaternion rotation = canvasToDestroy.transform.rotation;
                Transform parent = canvasToDestroy.transform.parent;

                // Destroy the old canvas
                Destroy(canvasToDestroy.gameObject);

                // Instantiate the new canvas at the same position and rotation
                Canvas newCanvas = Instantiate(canvasToInstantiate, position, rotation, parent);
            }
        }
    }
}
