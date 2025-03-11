using UnityEngine;
using UnityEngine.UI;
public abstract class Ability : MonoBehaviour
{

    [SerializeField] protected string abilityName;
    [SerializeField] protected Image icon;
    [SerializeField] protected float cooldown;
    // Start is called before the first frame update
    public abstract void Trigger();
}
