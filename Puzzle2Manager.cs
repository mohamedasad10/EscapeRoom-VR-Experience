// Puzzle2Manager.cs
// Manages a 4-digit gaze-based keypad puzzle. Verifies the entered code, shows a "solved" message, activates the next puzzle, and notifies the PuzzleManager.



using UnityEngine;
using TMPro;

public class Puzzle2Manager : MonoBehaviour
{
    public GameObject solvedMessage3D;
    public GameObject puzzle3Object; // next puzzle trigger
    public TMP_Text codeDisplayText;
    public PuzzleManager puzzleManager; // ?? Link PuzzleManager in Inspector

    private string enteredCode = "";
    private string correctCode = "2580";

    public void AddDigit(string digit)
    {
        if (enteredCode.Length < 4)
        {
            enteredCode += digit;
            UpdateDisplay();
            Debug.Log("Entered: " + enteredCode);
        }

        if (enteredCode.Length == 4)
        {
            CheckCode();
        }
    }

    private void CheckCode()
    {
        if (enteredCode == correctCode)
        {
            Debug.Log("Puzzle 2 Solved!");
            if (solvedMessage3D)
            {
                solvedMessage3D.SetActive(true);
                StartCoroutine(HideSolvedMessageAfterDelay());
            }
            if (puzzle3Object) puzzle3Object.SetActive(true);

            if (puzzleManager != null)
            {
                puzzleManager.PuzzleSolved(2); // ? Notify PuzzleManager
            }
        }
        else
        {
            Debug.Log("Wrong Code. Try Again.");
            enteredCode = "";
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        if (codeDisplayText != null)
        {
            codeDisplayText.text = enteredCode;
        }
    }

    public void ClearCode()
    {
        enteredCode = "";
        UpdateDisplay();
    }

    private System.Collections.IEnumerator HideSolvedMessageAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        if (solvedMessage3D)
        {
            solvedMessage3D.SetActive(false);
        }
    }
}
