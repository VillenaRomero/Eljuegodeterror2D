using UnityEngine;
using UnityEngine.UI;

public class LibroController : MonoBehaviour
{
    public GameObject libroUI;
    public Image hojaIzquierda;
    public Image hojaDerecha;
    public Button btnSiguiente;
    public Button btnAnterior;

    public Sprite[] hojas;
    private int paginaActual = 0; 

    private void Start()
    {
        libroUI.SetActive(false);
        btnSiguiente.onClick.AddListener(SiguientePagina);
        btnAnterior.onClick.AddListener(PaginaAnterior);
        ActualizarPaginas();
    }
    public void AbrirLibro()
    {
        libroUI.SetActive(true);
        paginaActual = 0;
        ActualizarPaginas();
    }
    public void CerrarLibro()
    {
        libroUI.SetActive(false);
    }
    private void SiguientePagina()
    {
        if (paginaActual < 3)
        {
            paginaActual++;
            ActualizarPaginas();
        }
    }

    private void PaginaAnterior()
    {
        if (paginaActual > 0)
        {
            paginaActual--;
            ActualizarPaginas();
        }
    }

    private void ActualizarPaginas()
    {
        int index = paginaActual * 2;
        hojaIzquierda.sprite = hojas[index];
        hojaDerecha.sprite = hojas[index + 1];

        btnAnterior.interactable = (paginaActual > 0);
        btnSiguiente.interactable = (paginaActual < 3);
    }
}
