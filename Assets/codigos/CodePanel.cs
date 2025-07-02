using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    public Text codeText;
    string codeTextValue = "";
    void Start()
    {
        
    }
    void Update()
    {
        codeText.text = codeTextValue;
        if (codeTextValue == "2745") {
            cajafuerte.isSafeOpened = true;
        }
        if (codeTextValue.Length >= 4) {
            codeTextValue = "";
        }
    }
    public void AddDigit(string digit) {
        codeTextValue += digit;
    }
}
