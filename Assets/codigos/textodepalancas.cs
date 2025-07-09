using System;
using UnityEngine;
using UnityEngine.UI;

public class textodepalancas : MonoBehaviour
{
    public Text textoPalancas;
    private GameManagernivel1 gameManager;
    private int totalPalancas;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManagernivel1>();

        if (gameManager != null && gameManager.newPalancas != null)
        {
            totalPalancas = gameManager.newPalancas.Count;
        }
    }

    void Update()
    {
        if (textoPalancas != null && gameManager != null)
        {
            textoPalancas.text = "Palancas: " + gameManager.palancaActual + " / " + totalPalancas;

            if (gameManager.palancaActual >= totalPalancas)
            {
                textoPalancas.text += "\n¡Puerta abierta!";
            }
        }
    }
}
