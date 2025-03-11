using UnityEngine;

public class disparo1 : MonoBehaviour
{
    
    public float speed = 0f;
    public int damage = 40;
    
    
    

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
