using UnityEngine;

public class CrearObjetodeBloqueo : MonoBehaviour
{
    public GameObject bloqueo;
    public float xposition;
    public float yPosition;
    public string nametag = "player";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == nametag)
        {
            Vector2 positioncreate = new Vector2(xposition, yPosition);
            GameObject palanca = Instantiate(bloqueo, positioncreate, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
