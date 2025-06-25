using UnityEngine;
using UnityEngine.UI;

public class textodepalancas : MonoBehaviour
{
    public Text textoPalancas;
    public GameManagernivel1 gameManager;

    void Update()
    {
        textoPalancas.text = "Palancas bajadas: " + gameManager.palancaActual;
    }
}
