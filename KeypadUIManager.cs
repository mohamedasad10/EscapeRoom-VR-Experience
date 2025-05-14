// KeypadUIManager.cs
// Handles user input for a keypad puzzle. Allows digits to be added, cleared, and updates the display text to show the current code.


using TMPro;
using UnityEngine;

public class KeypadUIManager : MonoBehaviour
{
    public TMP_Text codeDisplayText;

    private string currentCode = "";

    public void AddDigit(string digit)
    {
        if (currentCode.Length >= 4) return;

        currentCode += digit;
        UpdateDisplay();
    }

    public void ClearCode()
    {
        currentCode = "";
        UpdateDisplay();
    }

    public string GetCode()
    {
        return currentCode;
    }

    private void UpdateDisplay()
    {
        codeDisplayText.text = currentCode;
    }
}
