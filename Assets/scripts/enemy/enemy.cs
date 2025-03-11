using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Transform player;
    private salud playerHealth;  // Referencia al componente 'salud' del jugador
    public float speed = 3f; // Velocidad de movimiento
    public float damage = 100;

    void Start()
    {
        // Buscar al jugador por su etiqueta "Player" y obtener su componente 'salud'
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            player = jugador.transform;
            playerHealth = jugador.GetComponent<salud>();  // Almacenar la referencia al componente 'salud'
        }

        // Suscribirse al evento de muerte del jugador
        GameEvents.onPlayerDeath.AddListener(OnPlayerDeath);
    }

    void Update()
    {
        if (playerHealth != null && playerHealth.isPlayerDead)
        {
            // Si el personaje está muerto, los enemigos se alejan
            Vector3 direction = (transform.position - player.position).normalized; // Invertir la dirección para alejarse
            transform.position += direction * speed * Time.deltaTime;
        }
        else if (playerHealth != null)
        {
            // Si el personaje está vivo, los enemigos se acercan
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    // Método que se llama cuando el jugador muere
    private void OnPlayerDeath()
    {
        // En este caso, no necesitamos seguir buscando el componente 'salud' cada vez,
        // ya que hemos almacenado la referencia en 'playerHealth'.
        playerHealth.isPlayerDead = true; // Ejemplo de manipulación si es necesario
    }
}


