using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb; 
    private AudioSource audioSource;
    public GameObject vida;
    private Animator myAnimation;
    private bool isDead = false; 
    private bool respawning = false;
    [SerializeField] private float jumpPower;
    private bool grounded;
    private bool canDoubleJump;
    [SerializeField] private float velocidadeAndar;
    private int playerLives = 3;
    [SerializeField] private List<GameObject> lifeImages;
    private Vector3 startPosition;
    private Vector3 deathPosition;
    private enum PlayerState { Normal, Dying, Dead, Respawning }
    private PlayerState playerState = PlayerState.Normal;
    private Renderer myRenderer;
    [SerializeField] private AudioClip somSalto;
    [SerializeField] private AudioClip somColisao;
    [SerializeField] private AudioClip morreInimigo;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    float gravity = -9.81f;


    void Start()
    {
        myAnimation = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        grounded = true;
        canDoubleJump = false;
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
        myRenderer = GetComponent<Renderer>();
        velocity = playerRb.velocity;
    }


    void FixedUpdate()
    {
        if (isDead) return;

        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        HandleMovement(horizontal, vertical);

        velocity.y += gravity * Time.deltaTime;

        playerRb.MovePosition(transform.position + velocity * Time.deltaTime);
    }


    private void HandleMovement(float horizontal, float vertical)
    {
        if (playerState != PlayerState.Normal) return;

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        playerRb.velocity = new Vector3(horizontal * velocidadeAndar, playerRb.velocity.y, vertical * velocidadeAndar);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpPower * -2f * gravity);
            myAnimation.SetFloat("VelocidadeSalto", velocity.y);
        }
        {
            if (grounded)
            {
                playerRb.AddForce(Vector3.up * jumpPower);
                audioSource.PlayOneShot(somSalto);
                canDoubleJump = false;
                grounded = false;

                myAnimation.SetFloat("VelocidadeSalto", playerRb.velocity.y);
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);
                    playerRb.AddForce(Vector3.up * jumpPower / 1.75f);
                }
            }
        }

        myAnimation.SetFloat("VelocidadeAndar", Mathf.Sqrt(horizontal * horizontal + vertical * vertical));

        myAnimation.SetBool("Caminhar", playerRb.velocity.magnitude > 0.1f);
        myAnimation.SetBool("Correr", playerRb.velocity.magnitude > 0.5f);

        // Controla a orientação do personagem em 3D
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "plataforma")
        {
            grounded = true;
            canDoubleJump = false;
        }


        if (collision.gameObject.tag == "inimigo" || collision.gameObject.tag == "passaro")
        {
            if (!isDead)
            {
                LoseLife();
            }
        }
    }


    private void LoseLife()
    {
        if (respawning) return; 

        playerLives--; 

        if (playerLives >= 0)
        {
            deathPosition = transform.position; 
            audioSource.PlayOneShot(morreInimigo); 
            playerState = PlayerState.Respawning; 
            myAnimation.SetTrigger("Morrer"); 

            GameObject lostLifeInstance = Instantiate(vida, new Vector3(lifeImages[playerLives].transform.position.x, lifeImages[playerLives].transform.position.y, 0f), Quaternion.identity);
            lostLifeInstance.transform.SetParent(lifeImages[playerLives].transform.parent);

            Destroy(lifeImages[playerLives]);
            lifeImages.RemoveAt(playerLives);

            StartCoroutine(Respawn(0.4f));
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }


    private IEnumerator Respawn(float delay)
    {
                yield return new WaitForSeconds(delay); 
        myAnimation.ResetTrigger("Morrer"); 

        myAnimation.SetTrigger("Idle"); 

        playerState = PlayerState.Normal;
    }


    private IEnumerator ReappearAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        myAnimation.SetTrigger("Idle");
        playerState = PlayerState.Normal;
    }


}
