using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagernivel1 : MonoBehaviour
{
    public float timeTiCreate;
    public float currentTimetuCreate;
    public string nivel;
    public string nivel2;
    private bool cambiarNivelDerrota = false;
    private bool cambiarNivelVictoria = false;
    private float tiempoActual = 0f;
    public int palancaActual = 0;
    public GameObject[] palancas;
    public GameObject puerta;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivarSoloUnaPalanca(0);
    }

    public void CambioDeNivelDerrota()
    {
        cambiarNivelDerrota = true;
    }
    public void CambioDeNivelVctoria()
    {
        cambiarNivelVictoria = true;
    }

    public void CambiodePalanca() {
        if (palancaActual < palancas.Length)
        {
            palancas[palancaActual].SetActive(false);
            palancaActual++;
            if (palancaActual < palancas.Length)
            {
                palancas[palancaActual].SetActive(true);
            }
            else
            {
                if (puerta != null)
                {
                    puerta.SetActive(true);
                }
            }
        }

    }
    private void ActivarSoloUnaPalanca(int index)
    {
        for (int i = 0; i < palancas.Length; i++)
        {
            palancas[i].SetActive(i == index);
        }
        if (puerta != null) puerta.SetActive(false);
    }

    void Update()
    {
        currentTimetuCreate = currentTimetuCreate + Time.deltaTime;
        if (currentTimetuCreate >= timeTiCreate)
        {
            SceneManager.LoadScene(nivel2);
        }
        if (cambiarNivelDerrota)
        {
            SceneManager.LoadScene(nivel2);
        }
        if (cambiarNivelVictoria)
        {
            SceneManager.LoadScene(nivel);
        }
    }
}
