using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die ()
    {
        Zombies zombiesScript = GetComponent<Zombies>();
        Rigidbody rb = GetComponent<Rigidbody>(); // Obtém a referência para o componente Rigidbody
        animator.SetTrigger("Morrer");
       
        if (zombiesScript != null)
        {
            zombiesScript.enabled = false; 
        }
        Destroy(gameObject, 3f); // Destruir o objeto após 3 segundos
        

        if (rb != null)
        {
            rb.useGravity = false; // Desativa a gravidade do Rigidbody
        }
    }
}
