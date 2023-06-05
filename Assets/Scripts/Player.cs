using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float velocidadeAndar = 5;
    public float velocidadeRodar = 0.1f;
    CharacterController _characterController;
    private float inputAndar;
    private float inputRodar;

    Animator _animator;

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource correrSoundEffect;

    Vector3 velocity;
    bool isGrounded;




    public bool hasWeapon = false; // Defina como true quando o jogador pegar uma arma
    private Animator animator;
    private Rigidbody rb;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        // hasWeapon = true; //teste com arma - funciona!
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(X, 0.0f, Z);

        animator.SetFloat("VelocidadeAndar", movement.magnitude);
        animator.SetFloat("VelocidadeSalto", rb.velocity.y);

        animator.SetBool("Arma", hasWeapon);



        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) //quando o boneco cai
        {
            velocity.y = -2f;
            correrSoundEffect.Play();
        }

        inputAndar = Input.GetAxis("Vertical"); //andar para frente e para trás
        inputRodar = Input.GetAxis("Horizontal");   //rodar para esquerda e direita
        //_animator.SetFloat("velocidade", inputAndar);

        Vector3 move = transform.right * X + transform.forward * Z;

        controller.Move(move * speed * Time.deltaTime);
        Vector3 novaPosicao = transform.forward * velocidadeAndar * inputAndar;
        novaPosicao.y = Physics.gravity.y;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpSoundEffect.Play();
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        _characterController.Move(novaPosicao * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        _characterController.transform.Rotate(_characterController.transform.up * velocidadeRodar * inputRodar);

        controller.Move(velocity * Time.deltaTime);




        if (movement.magnitude > 0.1f)
        {
            if (movement.magnitude > 0.5f)
            {
                // O personagem está correndo
                animator.SetBool("Caminhar", false);
                animator.SetBool("Correr", true);
                rb.AddForce(movement.normalized * speed);
            }
            else
            {
                // O personagem está caminhando
                animator.SetBool("Caminhar", true);
                animator.SetBool("Correr", false);
                rb.AddForce(movement.normalized * speed);
            }
            //Vector3 inputDir = orientation.forward * verticalInput 
            // O personagem está se movendo, então atualize sua rotação
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }
        else
        {
            // O personagem não está se movendo
            animator.SetBool("Caminhar", false);
            animator.SetBool("Correr", false);
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            animator.SetBool("Saltar", true);
            isJumping = true;
        }
        else if (Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            animator.SetBool("Saltar", false);
            isJumping = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Morte")
        {
            SceneManager.LoadScene("GameOver");
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