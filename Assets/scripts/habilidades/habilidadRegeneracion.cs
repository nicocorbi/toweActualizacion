using UnityEngine;
using System.Collections;
public class habilidadRegeneracion : Ability
{
    [SerializeField] atributos attributes;
    [SerializeField] salud health;
    public float time = 10;  
    public ParticleSystem particlesHealth;
    private float cooldownTimer;
    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            icon.fillAmount = 1 - (cooldownTimer / cooldown); // La barra se vacía en 1 segundo
        }
    }

    public override void Trigger()
    {
        
        if (cooldownTimer <= 0)
        {
            StartCoroutine(Aplicar());
            cooldownTimer = cooldown; // Reinicia el cooldown
            icon.fillAmount = 0;
            

        }
    }

    private IEnumerator Aplicar()
    {
        // Activar las partículas al principio
        particlesHealth.Play();
        print("Regeneración activada");

        // Regenerar salud durante el tiempo de la habilidad
        for (int i = 0; i < time; i++)
        {
            // Regenerar 4 de salud por segundo
            health.currentHealth += 4;

            // Imprimir para verificar que la salud se está regenerando
            print("Salud regenerada: " + health.currentHealth);

            // Esperar 1 segundo antes de regenerar otra vez
            yield return new WaitForSeconds(1);
        }

        // Detener las partículas después de la regeneración
        particlesHealth.Stop();
        print("Regeneración finalizada");
    }
}

