// PuzzleManager.cs
// Tracks completion of multiple puzzles. When both Puzzle 1 and Puzzle 2 are solved, this script plays a door sound and hides the door GameObject to signal puzzle completion.


using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public GameObject door;               // Assign the door GameObject
    public AudioSource doorAudioSource;   // Drag an AudioSource here (with the sound assigned)


    private bool puzzle1Solved = false;
    private bool puzzle2Solved = false;

    public void PuzzleSolved(int puzzleNumber)
    {
        if (puzzleNumber == 1) puzzle1Solved = true;
        if (puzzleNumber == 2) puzzle2Solved = true;

        if (puzzle1Solved && puzzle2Solved)
        {
            Debug.Log("Both puzzles solved. Door will disappear and play sound.");
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (doorAudioSource != null)
        {
            doorAudioSource.Play(); // ?? Play sound
        }

        if (door != null)
        {
            door.SetActive(false); // ?? Hide door
        }
    }
}
