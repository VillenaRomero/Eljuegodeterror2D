using UnityEngine;

public class botonactivate :MonoBehaviour /* InteractuableOvbject, Iinteractualbe*/
{
    /*private Nivelesdeboton lvbuton;*/
    private bool yaActivado = false;

    /*private void Start()
    {
        lvbuton = FindFirstObjectByType<Nivelesdeboton>();
    }

    public override void OnSelect()
    {
        yaActivado = true;
        if (lvbuton != null) {
            lvbuton.BotonActivado(this);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!yaActivado && other.CompareTag("player"))
        {
            yaActivado = true;

            Nivelesdeboton manager = FindFirstObjectByType<Nivelesdeboton>();
            if (manager != null)
            {
                manager.BotonPresionado();
                gameObject.SetActive(false);
            }
        }
       /* if(yaActivado && lvbuton !=null && lvbuton.newbutton.Count> 3 && lvbuton.newbutton[3] == this && other.gameObject.tag == "player")
        {
            if (lvbuton.puerta != null) {
                lvbuton.puerta.SetActive(true);
            }
            gameObject.SetActive(false);
            yaActivado = false;
        }*/
    }
}
