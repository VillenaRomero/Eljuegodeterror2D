using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagernivel1 : MonoBehaviour
{
    public static GameManagernivel1 Instance;


    public float timeTiCreate;
    public float currentTimetuCreate;
    public string nivel;
    public string nivel2;

    public GameObject puerta;
    public List<Palanca> newPalancas;

    private bool cambiarNivelDerrota = false;

    public int palancaActual = 0;
    
    
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        
    }

    void Start()
    {

        for (int i = 0; i < newPalancas.Count; i++)
        {
            if (newPalancas[i] != null)
            {
                if (i == 0)
                {
                    newPalancas[i].gameObject.SetActive(true);
                }
                else
                {
                    newPalancas[i].gameObject.SetActive(false);
                }

                newPalancas[i].isEnabled = false;
            }
        }

        if (puerta != null)
        {
            puerta.SetActive(false);
        }

    }

    public void UpdatePalancas(Palanca palancaActivada)
    {
        int index = newPalancas.IndexOf(palancaActivada);

        if (index >= 0)
        {
            palancaActivada.gameObject.SetActive(false);
            palancaActivada.isEnabled = false;
            palancaActual++;


            if ((index + 1) < newPalancas.Count && newPalancas[index + 1] != null)
            {
                newPalancas[index + 1].gameObject.SetActive(true);
            }

            if (palancaActual >= newPalancas.Count && puerta != null)
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
