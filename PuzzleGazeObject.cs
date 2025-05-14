// PuzzleGazeObject.cs
// This script enables gaze interaction for a puzzle object. It uses a GazeTimer to detect when the
// player has looked at the object long enough, then notifies the PuzzleSequenceManager with the object’s name.



using UnityEngine;

public class PuzzleGazeObject : MonoBehaviour
{
    private GazeTimer gazeTimer;
    private PuzzleSequenceManager puzzleManager;

    void Start()
    {
        Debug.Log("PuzzleGazeObject Start ran");

        gazeTimer = gameObject.AddComponent<GazeTimer>();
        gazeTimer.onGazeComplete.AddListener(NotifyManager);

        GameObject managerObject = GameObject.Find("Puzzle1Manager");
        if (managerObject != null)
        {
            puzzleManager = managerObject.GetComponent<PuzzleSequenceManager>();
        }
        else
        {
            Debug.LogWarning("Puzzle1Manager not found in scene!");
        }
    }


    public void StartGaze()
    {
        gazeTimer.StartGaze();
    }

    public void StopGaze()
    {
        gazeTimer.StopGaze();
    }

    void NotifyManager()
    {
        Debug.Log("Gazed at: " + gameObject.name);
        puzzleManager.RegisterObject(gameObject.name); // Optional if puzzleManager is not null
    }


}
