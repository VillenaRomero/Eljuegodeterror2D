using System;
using UnityEngine;
using UnityEngine.UI;

public class textodepalancas : MonoBehaviour
{
    public Text textoPalancas;
    private GameManagernivel1 gameManager;
    private int totalPalancas = 4;

    void Start()
    {
        if (gameManager == null)
            gameManager = FindFirstObjectByType<GameManagernivel1>();
    }

    void Update()
    {
        if (textoPalancas != null && gameManager != null)
        {
            textoPalancas.text = "Palancas bajadas: " + gameManager.palancaActual + " / " + totalPalancas;

            if (gameManager.palancaActual >= totalPalancas)
            {
                textoPalancas.text += "\n¡Puerta abierta!";
            }
        }
    }
}
