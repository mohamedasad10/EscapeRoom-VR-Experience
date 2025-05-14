// SceneReloader.cs
// Reloads the current active scene. Useful for resetting the scene or reloading after an event.


using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
