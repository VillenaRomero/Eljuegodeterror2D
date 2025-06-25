using System.Globalization;
using UnityEngine;

public class cajafuerte : MonoBehaviour
{
    public string nametag;
    public GameObject codePanel, openedSafe;
    public static bool isSafeOpened = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        codePanel.SetActive(false);
        openedSafe.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (isSafeOpened)
        {
            codePanel.SetActive(false);
            openedSafe.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == nametag && !isSafeOpened)
        {
            codePanel.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == nametag)
        {
            codePanel.SetActive(false);
        }
    }
}
