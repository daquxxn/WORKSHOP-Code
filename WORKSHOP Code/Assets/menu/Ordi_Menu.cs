using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ordi_Menu : MonoBehaviour {
    public void QuitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // voir dans les options l'ordre des Scènes du jeu pour que ca marche
}
}
