using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float runSpeed = 7f;
    public float jumpForce = 2f;
    public bool hasWeapon = false; // Defina como true quando o jogador pegar uma arma
    private Animator animator;
    private Rigidbody rb;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        // hasWeapon = true; //teste com arma - funciona!
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        animator.SetFloat("VelocidadeAndar", movement.magnitude);
        animator.SetFloat("VelocidadeSalto", rb.velocity.y);

        animator.SetBool("Arma", hasWeapon);

        if (movement.magnitude > 0.1f)
        {
            if (movement.magnitude > 0.5f)
            {
                // O personagem está correndo
                animator.SetBool("Caminhar", false);
                animator.SetBool("Correr", true);
                rb.AddForce(movement * runSpeed);
            }
            else
            {
                // O personagem está caminhando
                animator.SetBool("Caminhar", true);
                animator.SetBool("Correr", false);
                rb.AddForce(movement * speed);
            }

            // O personagem está se movendo, então atualize sua rotação
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }
        else
        {
            // O personagem não está se movendo
            animator.SetBool("Caminhar", false);
            animator.SetBool("Correr", false);
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            animator.SetBool("Saltar", true);
            isJumping = true;
        }
        else if (Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            animator.SetBool("Saltar", false);
            isJumping = false;
        }
    }

    void Die()
    {
        animator.SetTrigger("Morrer");
        // Implemente aqui o que acontece quando o personagem morre
    }

    void GetWeapon() // Chame este método quando o personagem pegar uma arma
    {
        hasWeapon = true;
    }

    void LoseWeapon() // Chame este método quando o personagem perder a arma
    {
        hasWeapon = false;
    }
}
