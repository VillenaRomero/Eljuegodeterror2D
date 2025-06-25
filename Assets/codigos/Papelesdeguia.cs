using UnityEngine;

public class Papelesdeguia : MonoBehaviour
{
    public string nametag;
    public LibroController libro;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == nametag)
        {
            libro.AbrirLibro();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == nametag)
        {
            libro.CerrarLibro();
        }
    }
}
