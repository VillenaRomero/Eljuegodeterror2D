using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public GameObject luzandbloodAPrefab;
    public GameObject luzandbloodBPrefab;

    public Transform puntoInstancia;

    private GameObject luzActual;
    private bool activo = false;

    public void Toggle()
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
}
