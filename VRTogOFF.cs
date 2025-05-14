// VRTogOFF.cs
// Toggles VR mode on and off when a specific object ("VR Split") is clicked.
// Uses raycasting to detect mouse clicks and switches between VR and non-VR (cardboard) settings.


using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class VRTogOFF : MonoBehaviour
{
    //TurnOff VR on click
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "VR Split")
                {
                    ToggleVR();
                }
            }
        }
    }

    // Start is called before the first frame update
    public void ToggleVR()
    {

        if (XRSettings.loadedDeviceName == "kardboard")
        {
            StartCoroutine(LoadDevice("None"));
        }
        else
        {
            StartCoroutine(LoadDevice("kardboard"));
        }
    }

    IEnumerator LoadDevice(string newDevice)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = false;
    }
}
