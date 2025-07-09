using UnityEngine;

public class SwitchTrigger : InteractuableObject, Iinteractuable
{
    public GameObject luzandbloodAPrefab;
    public GameObject luzandbloodBPrefab;
    public Transform puntoInstancia;

    private GameObject luzActual;
    private bool activo = false;
    private bool jugadorEnRango = false;

    void Update()
    {
        if (jugadorEnRango && Input.GetKeyDown(KeyCode.E))
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        activo = !activo;

        if (luzActual != null)
        {
            Destroy(luzActual);
        }

        if (activo)
        {
            if (luzandbloodBPrefab != null && puntoInstancia != null)
            {
                luzActual = Instantiate(luzandbloodBPrefab, puntoInstancia.position, Quaternion.identity);
            }
        }
        else
        {
            if (luzandbloodAPrefab != null && puntoInstancia != null)
            {
                luzActual = Instantiate(luzandbloodAPrefab, puntoInstancia.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            jugadorEnRango = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            jugadorEnRango = false;
        }
    }
}
