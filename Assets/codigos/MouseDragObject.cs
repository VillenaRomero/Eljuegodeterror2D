using UnityEngine;
using UnityEngine.UI;
public class MouseDragObject : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera cam;
    private bool yaRegistrado = false;

    public float aguante = 100f;
    public float aguanteMax = 100f;
    public float aguanteBaja = 20f;
    public float aguanteRecuperacion = 15f;
    public Slider aguanteSlider;

    void Start()
    {
        cam = Camera.main;

        if (aguanteSlider != null)
        {
            aguanteSlider.maxValue = aguanteMax;
            aguanteSlider.value = aguante;
        }
    }

    void Update()
    {
        if (isDragging && aguante > 0)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos + offset;

            aguante -= aguanteBaja * Time.deltaTime;
            if (aguante <= 0)
            {
                aguante = 0;
                isDragging = false;
            }
        }
        else if (!isDragging && aguante < aguanteMax)
        {
            aguante += aguanteRecuperacion * Time.deltaTime;
            if (aguante > aguanteMax)
                aguante = aguanteMax;
        }

        if (aguanteSlider != null)
        {
            aguanteSlider.value = aguante;
        }
    }

    private void OnMouseDown()
    {
        if (aguante > 0)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            offset = transform.position - mousePos;
            isDragging = true;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mesa") && !yaRegistrado)
        {
            if (transform.position.y > other.transform.position.y + 0.1f)
            {
                MesaGameManagerMoneda gameManager = FindObjectOfType<MesaGameManagerMoneda>();
                if (gameManager != null)
                {
                    gameManager.SumarMesa();
                    yaRegistrado = true;
                }
            }
        }
    }
}
