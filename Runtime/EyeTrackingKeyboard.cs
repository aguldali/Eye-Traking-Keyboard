using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EyeTrackingKeyboard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI targetText;

    [SerializeField]
    GameObject lowerCase, upperCase, numbers;


    bool keyboardShifted = false;

    public void WriteOnTargetText(string newChar)
    {
        targetText.text += newChar;
    }
    public void DeleteOnTargetText()
    {
        if(targetText.text != "")
         targetText.text = targetText.text.Remove(targetText.text.Length - 1);
    }

    public void ShiftButtonAction()
    {
        if(keyboardShifted == false)
        {
            lowerCase.SetActive(false);
            upperCase.SetActive(true);
            keyboardShifted = true;
        }
        else if(keyboardShifted == true)
        {
            lowerCase.SetActive(true);
            upperCase.SetActive(false);
            keyboardShifted = false;
        }
    }

    public void SpaceButtonAction()
    {
        targetText.text += " ";
    }

}
