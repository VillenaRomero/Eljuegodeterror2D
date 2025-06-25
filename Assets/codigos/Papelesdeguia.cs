using UnityEngine;

public class Papelesdeguia : MonoBehaviour
{
    public LibroController libro;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            libro.AbrirLibro();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            libro.CerrarLibro();
        }
    }
}
