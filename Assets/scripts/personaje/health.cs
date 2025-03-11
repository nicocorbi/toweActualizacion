using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class salud : MonoBehaviour
{
  
    public float maxHealth = 100; 
    public float currentHealth;
    [SerializeField] TMP_Text gameOverUI;
    [SerializeField] public bool isPlayerDead = false;
    public Gradient gradient;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float gradientValue = 1f;
    [SerializeField] atributos attributes;
    [SerializeField] private float regenerationInterval = 2f;

    private void OnEnable()
    {
        GameEvents.onPlayerDeath.AddListener(OnPlayerDeath);
        GameEvents.onRestart.AddListener(RestartGame);

    }

    private void OnDisable()
    {
        GameEvents.onPlayerDeath.RemoveListener(OnPlayerDeath);
    }

    void Start()
    {
        currentHealth = maxHealth;
        gradient.Evaluate(1);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            spriteRenderer.color = gradient.Evaluate(gradientValue);
        }
        if (attributes.time >= regenerationInterval)
        {
            currentHealth = currentHealth + attributes.healthRegeration;
            attributes.time = 0f;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            GameEvents.onRestart.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= collision.gameObject.GetComponent<Enemigo>().damage;
            currentHealth = Mathf.Max(currentHealth, 0);
            gradientValue = currentHealth / maxHealth;
            spriteRenderer.color = gradient.Evaluate(gradientValue);

            if (currentHealth <= 0 && !isPlayerDead)
            {
                isPlayerDead = true;
                GameEvents.onPlayerDeath.Invoke();
                gameOverUI.gameObject.SetActive(true);
            }
        }

    }
    private void OnPlayerDeath()
    {
        Debug.Log("El personaje ha muerto.");

    }
    private void RestartGame()
    {
        Debug.Log("Reiniciando el juego...");
        SceneManager.LoadScene("SampleScene");
    }
}
