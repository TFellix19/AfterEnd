using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{
    public GameObject player;
    public float detectionRange = 5f;
    public float distanceToAttack = 0.5f; // Distância para iniciar o ataque
    private Animator animator;
    private bool isAttacking = false;

    public float speed = 2f; // Velocidade de movimento do zumbi
    public float rotationSpeed = 2f; // Velocidade de rotação do zumbi

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= detectionRange)
        {
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

            // Faz o zumbi olhar para o player
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

            if(distanceToPlayer <= distanceToAttack) // Altera de 0.5f para distanceToAttack
            {
                isAttacking = true;
                animator.SetBool("Atacar", true);
                animator.SetBool("Correr", false);
            }
            else
            {
                isAttacking = false;
                animator.SetBool("Atacar", false);
                animator.SetBool("Correr", true);
                transform.position += directionToPlayer * speed * Time.deltaTime;
            }
        }
        else
        {
            isAttacking = false;
            animator.SetBool("Correr", false);
            animator.SetBool("Atacar", false);
        }
    }

    public void Die()
    {
        animator.SetTrigger("Morrer");
    }
}
