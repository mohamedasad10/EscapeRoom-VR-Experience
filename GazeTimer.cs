// This script is attached to the object that will be gazed at.
// It uses Unity's Event System to trigger an event when the gaze is held for a certain duration.
// It also uses Unity's UnityEvent to allow for easy assignment of functions in the Inspector.
// This script is attached to the object that will be gazed at.

using UnityEngine;
using UnityEngine.Events;

public class GazeTimer : MonoBehaviour
{
    public UnityEvent onGazeComplete = new UnityEvent(); // ? Add this default initialization

    private float gazeTime = 2f;
    private float timer = 0f;
    private bool isGazing = false;

    public void StartGaze()
    {
        isGazing = true;
        timer = 0f;
        Debug.Log("Gaze started");
    }

    public void StopGaze()
    {
        isGazing = false;
        timer = 0f;
        Debug.Log("Gaze stopped");
    }

    void Update()
    {
        if (isGazing)
        {
            timer += Time.deltaTime;
            if (timer >= gazeTime)
            {
                isGazing = false;
                Debug.Log("Gaze complete!");
                onGazeComplete.Invoke();  // ? Now this won't throw error
            }
        }
    }
}
