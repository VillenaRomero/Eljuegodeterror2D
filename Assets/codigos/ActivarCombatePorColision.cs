using UnityEngine;

public class ActivarCombatePorColision : MonoBehaviour
{
    public GameObject mesaCombateUI;
    public GameObject enemigo;
    public Transform puntoEnemigo;
    public float distanciaMinima = 0.1f;

    private bool jugadorListo = false;
    private bool enemigoListo = false;
    private bool combateActivado = false;

    void Awake()
    {
        if (mesaCombateUI != null)
            mesaCombateUI.SetActive(false);
    }

    void Update()
    {
        if (!enemigoListo && enemigo != null && puntoEnemigo != null)
        {
            float distancia = Vector2.Distance(enemigo.transform.position, puntoEnemigo.position);
            if (distancia < distanciaMinima)
            {
                enemigoListo = true;
                VerificarInicioCombate();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            jugadorListo = true;
            other.GetComponent<movedplayer>().enabled = false;
            VerificarInicioCombate();
        }
    }

    void VerificarInicioCombate()
    {
        if (jugadorListo && enemigoListo && !combateActivado)
        {
            combateActivado = true;

            if (mesaCombateUI != null)
                mesaCombateUI.SetActive(true);

        }
    }
}
