using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagernivel1 : MonoBehaviour
{
    public float timeTiCreate;
    public float currentTimetuCreate;
    public string nivel;
    public string nivel2;

    public GameObject puerta;
    public List<Palanca> newPalancas;

    private bool cambiarNivelDerrota = false;
    private bool cambiarNivelVictoria = false;

    public tiempofinalniveles tiempoFinal;

    public int palancaActual = 0; // Contador de palancas activadas

    void Start()
    {
        // Desactiva todas las palancas menos la primera
        for (int i = 0; i < newPalancas.Count; i++)
        {
            if (newPalancas[i] != null)
            {
                newPalancas[i].gameObject.SetActive(i == 0); // Solo la primera se activa
                newPalancas[i].isEnabled = false;
            }
        }

        // ✅ Asegura que la puerta esté desactivada al iniciar
        if (puerta != null)
        {
            puerta.SetActive(false);
        }

        if (tiempoFinal == null)
            tiempoFinal = FindObjectOfType<tiempofinalniveles>();
    }

    public void UpdatePalancas(Palanca palancaActivada)
    {
        int index = newPalancas.IndexOf(palancaActivada);

        if (index >= 0)
        {
            palancaActivada.gameObject.SetActive(false); // Oculta palanca activada
            palancaActivada.isEnabled = false;
            palancaActual++; // Aumenta el contador

            // Activa la siguiente palanca si existe
            if ((index + 1) < newPalancas.Count && newPalancas[index + 1] != null)
            {
                newPalancas[index + 1].gameObject.SetActive(true);
            }

            // ✅ Si se activaron 4 palancas, abre la puerta
            if (palancaActual >= 4 && puerta != null)
            {
                puerta.SetActive(true);
            }
        }
    }

    public void CambioDeNivelDerrota()
    {
        cambiarNivelDerrota = true;
    }

    public void CambioDeNivelVctoria()
    {
        if (tiempoFinal != null)
            tiempoFinal.levelfinished();
        SceneManager.LoadScene(nivel);
    }

    void Update()
    {
        currentTimetuCreate += Time.deltaTime;

        if (currentTimetuCreate >= timeTiCreate || cambiarNivelDerrota)
        {
            SceneManager.LoadScene(nivel2);
        }
    }
}
