using UnityEngine;

public class ActivarCombatePorColision : MonoBehaviour
{
    public GameObject mesaCombateUI;

    void Awake()
    {
        if (mesaCombateUI != null)
            mesaCombateUI.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            mesaCombateUI.SetActive(true);
            other.GetComponent<movedplayer>().enabled = false;
        }
    }
}
