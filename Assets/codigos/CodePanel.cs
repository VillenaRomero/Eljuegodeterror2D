using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    public Text codeText;
    public string correctCode = "1234";
    public cajafuerte cajafuerte;
    private string codeTextValue = "";

    void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue.Length == 4)
        {
            if (codeTextValue == correctCode)
            {
                cajafuerte.isSafeOpened = true;
            }
            else
            {
            }

            codeTextValue = "";
        }
    }

    public void AddDigit(string digit)
    {
        if (codeTextValue.Length < 4)
        {
            codeTextValue += digit;
        }
    }
}
