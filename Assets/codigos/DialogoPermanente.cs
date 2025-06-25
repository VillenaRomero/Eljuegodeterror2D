using UnityEngine;
using UnityEngine.UI;

public class DialogoPermanente : MonoBehaviour
{
    public Text dialogoUI;
    public string mensaje;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            dialogoUI.text = mensaje;
            dialogoUI.enabled = true;
        }
    }
}
