//This script is attached to the Head GameObject

using System.Collections;
using UnityEngine;

public class GyroCamera : MonoBehaviour
{
    // STATE
    private float _initialYAngle = 0f;
    private float _appliedGyroYAngle = 0f;
    private float _calibrationYAngle = 0f;
    private Transform _rawGyroRotation;
    private float _tempSmoothing;

    // SETTINGS
    [SerializeField] private float _smoothing = 0.1f;

    private IEnumerator Start()
    {
        Input.gyro.enabled = true;
        Application.targetFrameRate = 60;
        _initialYAngle = transform.eulerAngles.y;

        _rawGyroRotation = new GameObject("GyroRaw").transform;
        _rawGyroRotation.position = transform.position;
        _rawGyroRotation.rotation = transform.rotation;

        // Wait until gyro is active, then calibrate to reset starting rotation.
        yield return new WaitForSeconds(1);
        StartCoroutine(CalibrateYAngle());
    }

    private void Update()
    {
        ApplyGyroRotation();
        ApplyCalibration();
        transform.rotation = Quaternion.Slerp(transform.rotation, _rawGyroRotation.rotation, _smoothing);
    }

    private IEnumerator CalibrateYAngle()
    {
        _tempSmoothing = _smoothing;
        _smoothing = 1;
        _calibrationYAngle = _appliedGyroYAngle - _initialYAngle;
        yield return null;
        _smoothing = _tempSmoothing;
    }

    private void ApplyGyroRotation()
    {
        _rawGyroRotation.rotation = Input.gyro.attitude;
        _rawGyroRotation.Rotate(0f, 0f, 180f, Space.Self);
        _rawGyroRotation.Rotate(90f, 180f, 0f, Space.World);
        _appliedGyroYAngle = _rawGyroRotation.eulerAngles.y;
    }

    private void ApplyCalibration()
    {
        _rawGyroRotation.Rotate(0f, -_calibrationYAngle, 0f, Space.World);
    }

    public void SetEnabled(bool value)
    {
        enabled = value;
        if (value) StartCoroutine(CalibrateYAngle());
    }
}
