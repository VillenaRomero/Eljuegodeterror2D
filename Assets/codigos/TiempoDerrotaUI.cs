using UnityEngine;
using UnityEngine.UI;

public class TiempoDerrotaUI : MonoBehaviour
{
    public Text tiempoText;

    void Start()
    {
        float tiempoGuardado = PlayerPrefs.GetFloat("CurrentTime", -1f);

        if (tiempoGuardado >= 0f)
        {
            int segundos = Mathf.FloorToInt(tiempoGuardado);
            tiempoText.text = "Sobreviviste: " + segundos + " segundos";
            Debug.Log("Tiempo mostrado en derrota: " + segundos); // DEBUG
        }
        else
        {
            tiempoText.text = "No se encontr� tiempo jugado.";
            Debug.LogWarning("No se encontr� 'CurrentTime' en PlayerPrefs");
        }

        // Opcional: limpiar para pr�ximo intento
        PlayerPrefs.DeleteKey("CurrentTime");
    }
}
