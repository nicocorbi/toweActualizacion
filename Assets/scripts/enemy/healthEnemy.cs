using UnityEngine;

public class saludEnemigo : MonoBehaviour
{
    public float maxhealth = 100;
    public float currentHealth;
    public Gradient gradient;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float gradientValue = 1f;

    private void OnEnable()
    {
        GameEvents.onEnemyDeath.AddListener(OnEnemyDeath); 
    }

    private void OnDisable()
    {
        GameEvents.onEnemyDeath.RemoveListener(OnEnemyDeath); 
    }

    void Start()
    {
        currentHealth = maxhealth;
        gradient.Evaluate(1);
    }

    void Update()
    {
        if (currentHealth >= maxhealth)
        {
            currentHealth = 100;
            spriteRenderer.color = gradient.Evaluate(gradientValue);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("proyectil"))
        {
            gradientValue = 1f - (currentHealth / maxhealth);
            spriteRenderer.color = gradient.Evaluate(gradientValue);
            Destroy(collision.gameObject);
            currentHealth = currentHealth - collision.gameObject.GetComponent<disparo1>().damage;
            if (currentHealth <= 0)
            {
                GameEvents.onEnemyDeath.Invoke();  
                Destroy(gameObject);
                Destroy(collision.gameObject);
                gradientValue = 1f;
                spriteRenderer.color = gradient.Evaluate(gradientValue);
            }
        }

        if (collision.gameObject.CompareTag("proyectilGrande"))
        {
            gradientValue = Mathf.Clamp01(1f - (currentHealth / maxhealth));
            spriteRenderer.color = gradient.Evaluate(gradientValue);
            Destroy(collision.gameObject);
            currentHealth = currentHealth - collision.gameObject.GetComponent<movementProyectile>().damage;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
                gradientValue = 1f;
                spriteRenderer.color = gradient.Evaluate(gradientValue);
            }
        }
    }

    private void OnEnemyDeath()
    {
        Debug.Log("El enemigo ha muerto.");
        
    }
}

