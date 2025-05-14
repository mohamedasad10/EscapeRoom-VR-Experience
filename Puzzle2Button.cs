// Puzzle2Button.cs
// Triggers an action when the player gazes at the button for a set duration (2 seconds). Useful for gaze-based keypad input in puzzles.


using UnityEngine;
using UnityEngine.Events;

public class Puzzle2Button : MonoBehaviour
{
    public string digit;  // Set this manually in the inspector
    public UnityEvent onGazeClick;

    private float gazeTime = 2f;
    private float timer = 0f;
    private bool isGazing = false;

    void Update()
    {
        if (isGazing)
        {
            timer += Time.deltaTime;
            if (timer >= gazeTime)
            {
                onGazeClick.Invoke(); // Triggers the event
                timer = 0f;
                isGazing = false;
            }
        }
    }

    // These will be hooked via EventTrigger
    public void StartGaze()
    {
        isGazing = true;
    }

    public void StopGaze()
    {
        isGazing = false;
        timer = 0f;
    }
}
