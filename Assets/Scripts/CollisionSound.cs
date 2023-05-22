using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioClip collisionClip; // O som a ser reproduzido

    private AudioSource audioSource;

    private void Start()
    {
        // Obt�m a refer�ncia para o componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Se n�o houver um AudioSource no objeto, adicione um novo
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = collisionClip; // Define o som a ser reproduzido
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0.5f)
        {
            // Reproduz o som apenas se a colis�o for forte o suficiente (pode ajustar o valor 0.5f conforme necess�rio)
            audioSource.Play();
        }
    }
}
