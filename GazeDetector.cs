// GazeDetector.cs
// This script detects which object the player is looking at using raycasting.
// It sends "OnGazeEnter" when the player starts looking at an object,
// and "OnGazeExit" when they look away. Used for gaze-based interactions.


using UnityEngine;

public class GazeDetector : MonoBehaviour
{
    private GameObject currentGazedObject;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject != currentGazedObject)
            {
                if (currentGazedObject != null)
                    currentGazedObject.SendMessage("OnGazeExit", SendMessageOptions.DontRequireReceiver);

                currentGazedObject = hitObject;
                currentGazedObject.SendMessage("OnGazeEnter", SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            if (currentGazedObject != null)
            {
                currentGazedObject.SendMessage("OnGazeExit", SendMessageOptions.DontRequireReceiver);
                currentGazedObject = null;
            }
        }
    }
}
