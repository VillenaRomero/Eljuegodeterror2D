using UnityEngine;

public class botonactivate : MonoBehaviour
{
    private bool yaActivado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!yaActivado && other.CompareTag("player"))
        {
            yaActivado = true;

            Nivelesdeboton manager = FindFirstObjectByType<Nivelesdeboton>();
            if (manager != null)
            {
                manager.BotonPresionado();
                gameObject.SetActive(false); // Desaparece tras ser activado
            }
        }
    }
}
