// PuzzleSequenceManager.cs
// This script checks if the player interacts with puzzle objects in the correct order.
// It compares the input sequence to a predefined list, shows a success or failure message,
// and notifies the PuzzleManager when the puzzle is solved.
// PUZZLE 1

using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class PuzzleSequenceManager : MonoBehaviour
{
    public List<string> correctSequence = new List<string> { "PuzzleObject1", "PuzzleObject2", "PuzzleObject3" };
    private List<string> currentSequence = new List<string>();

    public TextMeshProUGUI puzzleMessageText;
    public PuzzleManager puzzleManager; // ?? Link PuzzleManager in Inspector

    public void RegisterObject(string objectName)
    {
        currentSequence.Add(objectName);

        if (currentSequence.Count == correctSequence.Count)
        {
            CheckSequence();
        }
    }

    void CheckSequence()
    {
        bool correct = true;
        for (int i = 0; i < correctSequence.Count; i++)
        {
            if (currentSequence[i] != correctSequence[i])
            {
                correct = false;
                break;
            }
        }

        if (correct)
        {
            Debug.Log("Puzzle 1 Solved!");
            puzzleMessageText.text = "Puzzle 1 Solved!";
            puzzleMessageText.gameObject.SetActive(true);
            StartCoroutine(HideMessageAfterDelay());

            if (puzzleManager != null)
            {
                puzzleManager.PuzzleSolved(1); // ? Notify PuzzleManager
            }
        }
        else
        {
            Debug.Log("Wrong order! Try again.");
            puzzleMessageText.text = "Wrong order! Try again.";
            puzzleMessageText.gameObject.SetActive(true);
            StartCoroutine(HideMessageAfterDelay());
        }

        currentSequence.Clear();
    }

    IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(3);
        puzzleMessageText.gameObject.SetActive(false);
    }
}
