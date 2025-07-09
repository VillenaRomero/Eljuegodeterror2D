using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sierra : MonoBehaviour
{
    public int speedx;
    public int speedy;
    private Rigidbody2D rigibody2D_;
    private Transform comTransform;
    public float speed = 4;
    public string nametag = "pared de arriba";
    public string nametag1 = "pared de abajo";
    public string nametag2 = "sierra";
    public string nametag3;
    public string levelfailure;


    void Start()
    {
        rigibody2D_ = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigibody2D_.linearVelocity = new Vector2(speed * speedx, speed * speedy);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == nametag || collision.gameObject.tag == nametag1 || collision.gameObject.tag == nametag2)
        {
            speedy *= -1;
        }

        else if (collision.gameObject.tag == nametag3) {
            SceneManager.LoadScene(levelfailure);
        }
    }
}
