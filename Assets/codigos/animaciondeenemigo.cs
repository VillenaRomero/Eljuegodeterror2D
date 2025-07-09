using UnityEngine;

public class animaciondeenemigo : MonoBehaviour
{
    public float velocidad = 2f;
    public Transform puntoDestino;

    private Animator animator;
    private bool caminando = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("caminar", true);
    }

    void Update()
    {
        if (caminando)
        {
            transform.position = Vector2.MoveTowards(transform.position, puntoDestino.position, velocidad * Time.deltaTime);

            if (Vector2.Distance(transform.position, puntoDestino.position) < 0.05f)
            {
                caminando = false;
                animator.SetBool("caminar", false);
            }
        }
    }
}
