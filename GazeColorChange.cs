// GazeColorChange.cs
// Changes the object's color when gazed at and registers the object with the PuzzleSequenceManager after a 1-second delay to track puzzle interaction.


using System.Collections;
using UnityEngine;

public class GazeColorChange : MonoBehaviour
{
    public Color gazeColor = Color.green;
    private Color originalColor;
    private Renderer cubeRenderer;

    public PuzzleSequenceManager puzzleSequenceManager;
    public string objectName; // e.g., "PuzzleObject1"

    private Coroutine gazeCoroutine;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        originalColor = cubeRenderer.material.color;
    }

    public void OnGazeEnter()
    {
        cubeRenderer.material.color = gazeColor;
        gazeCoroutine = StartCoroutine(RegisterAfterDelay());
    }

    public void OnGazeExit()
    {
        

        if (gazeCoroutine != null)
        {
            StopCoroutine(gazeCoroutine);
        }
    }

    IEnumerator RegisterAfterDelay()
    {
        yield return new WaitForSeconds(1f); // 1 second gaze delay
        puzzleSequenceManager.RegisterObject(objectName);
    }
}
