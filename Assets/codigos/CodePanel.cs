using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    public Text codeText;
    public string correctCode;
    public cajafuerte cajafuerte;
    private string codeTextValue = "";

    void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue.Length == correctCode.Length)
        {
            if (codeTextValue == correctCode)
            {
                cajafuerte.isSafeOpened = true;
            }

            codeTextValue = "";
        }
    }

    public void AddDigit(string digit)
    {
        if (codeTextValue.Length < correctCode.Length)
        {
            codeTextValue += digit;
        }
    }

    public void ClearCode()
    {
        codeTextValue = "";
    }
}
