using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameOver : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Refer�ncia ao componente VideoPlayer
    public Canvas gameOverCanvas; // Refer�ncia ao canvas de Game Over

    private void Start()
    {
        // Desativa o canvas de Game Over no in�cio
        gameOverCanvas.gameObject.SetActive(false);

        // Adiciona um listener ao evento loopPointReached do VideoPlayer
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(UnityEngine.Video.VideoPlayer vp)
    {
        // Quando o v�deo terminar, ativa o canvas de Game Over
        gameOverCanvas.gameObject.SetActive(true);

        // Pausa o v�deo para evitar que continue reproduzindo em segundo plano
        videoPlayer.Pause();
    }
}
