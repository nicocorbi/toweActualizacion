using UnityEngine;

public class movementProyectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 0f;
    public int damage = 50;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = transform.up;
        transform.position += direccion * speed * Time.deltaTime;
    }
   
}
