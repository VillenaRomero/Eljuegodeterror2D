using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagernivel1 : MonoBehaviour
{
    public static GameManagernivel1 Instance;

    [Header("Configuración de escena")]
    public string nivel2;
    public float timeTiCreate;
    private float currentTimetuCreate;

    [Header("Elementos del nivel")]
    public List<Palanca> newPalancas;
    public GameObject puerta;

    public int palancaActual = 0;
    private bool cambiarNivelDerrota = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        if (puerta != null)
            puerta.SetActive(false);

        InicializarPalancas();
        ActivarPalancaPorIndice(0);
    }

    private void Update()
    {
        currentTimetuCreate += Time.deltaTime;

        if (currentTimetuCreate >= timeTiCreate || cambiarNivelDerrota)
        {
            SceneManager.LoadScene(nivel2);
        }
    }

    public void CambioDeNivelPorDerrota()
    {
        cambiarNivelDerrota = true;
    }

    #region Sistema de Palancas

    public void UpdatePalancas(Palanca palancaActivada)
    {
        int index = newPalancas.IndexOf(palancaActivada);

        if (index >= 0)
        {
            palancaActual++;
            DesactivarPalancaPorIndice(index);

            if (index + 1 < newPalancas.Count)
            {
                ActivarPalancaPorIndice(index + 1);
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

    public void ActivarPalancaPorIndice(int index)
    {
        if (index >= 0 && index < newPalancas.Count && newPalancas[index] != null)
        {
            newPalancas[index].gameObject.SetActive(true);
        }
    }
    public void DesactivarPalancaPorIndice(int index)
    {
        if (index >= 0 && index < newPalancas.Count && newPalancas[index] != null)
        {
            newPalancas[index].gameObject.SetActive(false);
            newPalancas[index].ResetearPalanca();
        }
    }

    public void InicializarPalancas()
    {
        for (int i = 0; i < newPalancas.Count; i++)
        {
            if (newPalancas[i] != null)
            {
                newPalancas[i].ResetearPalanca();
                newPalancas[i].gameObject.SetActive(false);
            }
        }
    }
    #endregion
}
