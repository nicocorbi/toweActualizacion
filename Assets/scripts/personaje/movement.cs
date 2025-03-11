using Unity.Mathematics;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    private Vector3 objetivo;
    [SerializeField] Camera camara;

    private float anguloRadianes;
    private float angleDegrees;
    public ParticleSystem particlesHealth;
    public ParticleSystem particlesForce;


    void Start()
    {
        particlesForce.Stop();
        particlesHealth.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        objetivo = camara.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - camara.transform.position.z));

        //anguloRadianes = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
        //anguloGrados = (180 / Mathf.PI) * anguloRadianes;
        Vector3 direccion = objetivo - transform.position;
        angleDegrees = Vector3.SignedAngle(Vector3.up, direccion,Vector3.forward);
        

        transform.rotation = Quaternion.Euler(0,0,angleDegrees);
    }
}
