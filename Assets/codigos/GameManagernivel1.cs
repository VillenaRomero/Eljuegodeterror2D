using System.Collections.Generic;
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


    public List<Palanca> newPalancas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     /*   ActivarSoloUnaPalanca(0);*/

        foreach (var item in newPalancas)
        {
            item.gameObject.SetActive(false);

           
            
        }
        
        newPalancas[0].gameObject.SetActive(true);

    }
    public void UpdatePalancas()
    {
        for (int i = 0; i < newPalancas.Count; i++)
        {
            if (newPalancas[i].isEnabled && (i+1)<newPalancas.Count )
            {
                
                newPalancas[i + 1].gameObject.SetActive(true);
                newPalancas[i].gameObject.SetActive(false);
                newPalancas[i].isEnabled = false;
            }
            
        }
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
