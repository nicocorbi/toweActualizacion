using System;
using UnityEngine;

public class atributos : MonoBehaviour
{
    public float healthRegeration = 0f;
    public float time = 0;
    public int damageMultiplier = 2;
    public float timeDamage = 0;




    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeDamage += Time.deltaTime;

       
     

       



    }
}
