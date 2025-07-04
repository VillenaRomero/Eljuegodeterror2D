using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movedplayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anin;

    public int life = 10;
    public int speed = 10;
    public int dash = 30;

 
  

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
       
    }
    void Update()
    {
        Movement();
    }
    public void Movement()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anin.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anin.SetBool("Run", false);
        }
        if (Input.GetKey(KeyCode.W))
        {

            if (anin.GetBool("Run"))
            {
                anin.Play("Correr hacia arriba");
                transform.position += Vector3.up * dash * Time.deltaTime;
            }
            else
            {
                anin.Play("Caminar hacia arriba");
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {

            if (anin.GetBool("Run"))
            {
                anin.Play("Correr hacia abajo");
                transform.position += Vector3.down * dash * Time.deltaTime;
            }
            else
            {
                anin.Play("Caminar hacia abajo");
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {

            if (anin.GetBool("Run"))
            {
                anin.Play("Correr hacia Izquierda");
                transform.position += Vector3.left * dash * Time.deltaTime;

            }
            else
            {
                anin.Play("Caminar hacia izquierda");
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {

            if (anin.GetBool("Run"))
            {
                anin.Play("Correr hacia derecha");
                transform.position += Vector3.right * dash * Time.deltaTime;
            }
            else
            {
                anin.Play("Caminar hacia la derecha");
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

         
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Iinteractuable interactuable = other.gameObject.GetComponent<Iinteractuable>();
        if (interactuable != null)
        {
            interactuable.OnSelect();
        }
    }

   private void OnTriggerExit2D(Collider2D other)
   {
      
   }
}
