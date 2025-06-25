using UnityEngine;

public class MesaTrigger : MonoBehaviour
{
    public GameObject panelMesa;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            panelMesa.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            panelMesa.SetActive(false);
        }
    }
}
