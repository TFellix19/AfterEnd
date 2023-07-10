using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float velocidadeAndar = 2;
    public float velocidadeAndarDevagar = 1;
    public float velocidadeCorrer = 7;
    public float velocidadeRodar = 0.1f;
    CharacterController _characterController;
    private float inputAndar;
    private float inputRodar;

    Animator _animator;

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 8f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource correrSoundEffect;
    [SerializeField] private AudioSource andarSoundEffect;

    Vector3 velocity;
    bool isGrounded;

    

    private Animator animator;
    private Rigidbody rb;

    private bool isJumping = false;
    private bool isRunning = false;
    private bool isWalkingSlowly = false; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
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


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) //quando o boneco cai
        {
            velocity.y = -2f;
            if (movement.magnitude > 0.1f)
            {
                correrSoundEffect.Play();
            }
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (isRunning)
            {
                isRunning = false;
                correrSoundEffect.Stop();
            }

            if (movement.magnitude > 0.1f)
            {
                if (!isWalkingSlowly)
                {
                    isWalkingSlowly = true;
                    animator.SetBool("Caminhar", true);
                    animator.SetBool("Correr", false);
                }

                rb.AddForce(movement.normalized * velocidadeAndarDevagar);
            }
            else
            {
                if (isWalkingSlowly)
                {
                    isWalkingSlowly = false;
                    animator.SetBool("Caminhar", false);
                }
            }
        }
        else
        {
            // não pressionada
            if (isWalkingSlowly)
            {
                isWalkingSlowly = false;
                animator.SetBool("Caminhar", false);
            }

            if (movement.magnitude > 0.1f)
            {
                if (!isRunning)
                {
                    isRunning = true;
                    correrSoundEffect.Play();
                }
                if (!andarSoundEffect.isPlaying)
                {
                    andarSoundEffect.Play();
                }

                if (movement.magnitude > 0.5f)
                {
                    // correr
                    animator.SetBool("Caminhar", false);
                    animator.SetBool("Correr", true);
                    rb.AddForce(movement.normalized * velocidadeCorrer);
                }
                else
                {
                    // caminhar
                    animator.SetBool("Caminhar", true);
                    animator.SetBool("Correr", false);
                    rb.AddForce(movement.normalized * velocidadeAndar);
                }
            }
            else
            {
                if (isRunning)
                {
                    isRunning = false;
                    correrSoundEffect.Stop();
                }
                if (andarSoundEffect.isPlaying)
                {
                    andarSoundEffect.Stop();
                }

                // parar de andar
                animator.SetBool("Caminhar", false);
                animator.SetBool("Correr", false);
            }
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

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Morte"))
        {
            animator.SetTrigger("Morrer");
            Invoke("LoadGameOverScene", 3f);
        }
    }

    void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

}
