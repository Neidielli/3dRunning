using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Update()
    {

    }
    public void StartGame()
    {
        // Carrega a cena 1
        SceneManager.LoadSceneAsync(1);
    }

    // Tela de Fim de Jogo
    public void EndGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    // Quita do Game
    public void ExitGame()
    {
        Application.Quit();
    }

    public void WinGame()
    {
        SceneManager.LoadSceneAsync(3);
    }


}