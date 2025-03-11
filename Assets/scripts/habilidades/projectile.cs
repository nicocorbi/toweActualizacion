using UnityEngine;
using UnityEngine.UI;

public class proyectil : Ability
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Camera camera;
    [SerializeField] private disparo1 shot1;
    [SerializeField] private movementProyectile shor2;
    [SerializeField] private atributos attributes;
    

    private float cooldownTimer = 0f;

    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            icon.fillAmount = 1 - (cooldownTimer / cooldown); // La barra se vacía con el tiempo
        }
    }

    public override void Trigger()
    {
        if (cooldownTimer <= 0) // Solo se activa si el cooldown ha terminado
        {
            Instantiate(prefab, prefab.transform.position, transform.rotation);
            print(shot1.damage);

            if (attributes.timeDamage >= 20 && attributes.timeDamage < 30)
            {
                shot1.damage = 40 * attributes.damageMultiplier;
                shor2.damage = 50 * attributes.damageMultiplier;
            }
            else
            {
                shot1.damage = 40;
                shor2.damage = 50;
            }

            // Reiniciar cooldown
            cooldownTimer = cooldown;
            icon.fillAmount = 0; // La barra comienza vacía y se llenará con el tiempo
        }
    }
}
