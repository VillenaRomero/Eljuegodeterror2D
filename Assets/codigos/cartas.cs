using System.Collections.Generic;
using UnityEngine;
public enum Palo { Corazon, Trebol, Espada, Rubi }

public class cartas : MonoBehaviour
{
    public Palo palo;
    public int valor;
    public UnityEngine.Sprite imagen;

    public cartas(Palo palo, int valor, UnityEngine.Sprite imagen)
    {
        this.palo = palo;
        this.valor = valor;
        this.imagen = imagen;
    }
}
