using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class InteractuableObject : BaseObject ,Iinteractuable
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Collider2D col;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    public virtual void OnSelect()
    {
    }
}
