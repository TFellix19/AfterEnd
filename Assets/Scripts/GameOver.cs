using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameOver : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Referência ao componente VideoPlayer
    public Canvas gameOverCanvas; // Referência ao canvas de Game Over

    private void Start()
    {
        // Desativa o canvas de Game Over no início
        gameOverCanvas.gameObject.SetActive(false);

        // Adiciona um listener ao evento loopPointReached do VideoPlayer
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(UnityEngine.Video.VideoPlayer vp)
    {
        // Quando o vídeo terminar, ativa o canvas de Game Over
        gameOverCanvas.gameObject.SetActive(true);

        // Pausa o vídeo para evitar que continue reproduzindo em segundo plano
        videoPlayer.Pause();
    }
}
