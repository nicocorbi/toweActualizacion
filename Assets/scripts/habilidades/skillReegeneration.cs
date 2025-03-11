using UnityEngine;

public class HabilityHolder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Ability[] abilities;
    int abilityNumber;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            abilities[abilityNumber].Trigger();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CambiarHabilidad(0, image1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CambiarHabilidad(1, image2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CambiarHabilidad(2, image3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CambiarHabilidad(3, image4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CambiarHabilidad(4, image5);
        }
    }

    void CambiarHabilidad(int nuevaHabilidad, GameObject nuevaImagen)
    {
        
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        image4.SetActive(false);
        image5.SetActive(false);
        abilityNumber = nuevaHabilidad;
        nuevaImagen.SetActive(true);
    }
}

