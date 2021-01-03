using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retourmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        // voir dans les options l'ordre des Scènes du jeu pour que ca marche
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
