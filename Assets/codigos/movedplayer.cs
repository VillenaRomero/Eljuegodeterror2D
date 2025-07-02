using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movedplayer : MonoBehaviour
{
    public int life = 10;
    public int speed = 10;
    public int dash = 30;
    private Rigidbody2D _compRigidbody2D;
    public string nametag;
    public string nametag2;
    public string nametag3;
    public string nametag4;
    private SwitchTrigger currentSwitch;
    public Animator anin;
    private GameManagernivel1 gameManager;
    private Nivelesdeboton nivelesdeboton; 

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManagernivel1>();
        nivelesdeboton = FindFirstObjectByType<Nivelesdeboton>();
    }

    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (currentSwitch != null && Input.GetKeyDown(KeyCode.E))
        {
            currentSwitch.Toggle();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            anin.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            anin.SetBool("Run",false);
        }
        if (Input.GetKey(KeyCode.W)) {

            if (anin.GetBool("Run"))
            {
                anin.Play("Correr hacia arriba");
                transform.position += Vector3.up * dash * Time.deltaTime;
            }
            else {
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

        if (collision.gameObject.tag == nametag)
        {
           gameManager.CambioDeNivelDerrota();
        }

        if (collision.gameObject.tag == nametag2)
        {
            gameManager.CambioDeNivelVctoria();
        }

    Iinteractualbe interactuable = collision.gameObject.GetComponent<Iinteractualbe>();
    if (interactuable != null)
    {
        interactuable.OnSelect();
    }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag =="Interruptor")
        {
            currentSwitch = other.GetComponent<SwitchTrigger>();
        }
        if (other.gameObject.tag == nametag4)
        {
            life--;
            if (life <= 0)
            {
                nivelesdeboton.Niveldederrota();
            }
        }
        if (other.gameObject.tag == nametag) {
            nivelesdeboton.NiveldeGanar();
        }
    }

   private void OnTriggerExit2D(Collider2D other)
   {
       if (other.gameObject.tag =="Interruptor")
       {
           currentSwitch = null;
       }
   }
}
