using UnityEngine;
using UnityEngine.UI;

public class DialogoTemporral : MonoBehaviour
{
    public Text dialogoUI;
    public string mensaje;
    public float duracion = 3f;
    private float tiempoRestante = 0f;

    void Update()
    {
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0)
            {
                dialogoUI.enabled = false;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            dialogoUI.text = mensaje;
            dialogoUI.enabled = true;
            tiempoRestante = duracion;
        }
    }
}
