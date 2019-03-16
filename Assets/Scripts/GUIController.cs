using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour {

    // Donnée pour la gestion de l'affichage des pièces
    public Text coinText;

    // Donée pour la gestion du menu Pause
    public GameObject pauseMenu;
    public CanvasGroup pauseButton;
    public Text levelText;
    private int levelNumber;

    // Donnée pour la gestion de la fin de jeu
    public GameObject endGamePanel;
    public GameObject gameOverColor;
    public GameObject winColor;
    public Text endGameUIText;
    public string currentLevel;
    public string nextLevel;
    public GameObject nextLevelButton;


    // ---------------------------------------------------------------------------

    public void Start()
    {
        switch (currentLevel) // Pour l'affichage du numéro du niveau
        {
            case "Level1":
                levelNumber = 1;
                break;
            case "Level2":
                levelNumber = 2;
                break;
            case "Level3":
                levelNumber = 3;
                break;
        }

        levelText.text = ("You are playing level " + levelNumber + "."); // Mise a jour du niveau
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Echap !");
            pauseGame();
        }

    }

    // Gestion de l'affichage des pièces
    public void actualizeCoinView(int coinNumber)
    {
        coinText.text = coinNumber.ToString(); // Actualisation du compteur
    }


    // Menu Pause
    public void pauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0; // Met l'échelle de temps à 0
            pauseMenu.gameObject.SetActive(true);
            pauseButton.alpha = 0; // Met le canvas en transparent (on peut cliquer sur l'emplacement du bouton pour enlever la pause alors qu'il est masqué)
        }

        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseMenu.gameObject.SetActive(false);
            pauseButton.alpha = 1;
        }

    }

    // Gestion de la fin du jeu
    public void endGame(bool isGameOver) // Menu de fin de jeu
    {
        pauseButton.gameObject.SetActive(false);
        endGamePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        if (isGameOver)
        {
            gameOverColor.SetActive(true);
            endGameUIText.text = "You died !";
        }
        else
        {
            winColor.SetActive(true);
            nextLevelButton.gameObject.SetActive(true); 
            endGameUIText.text = "You win !";
        }

        // Nb. La victoire et la défaite sont gérées dans le script PlayerHeart.cs

    }

    public void loadLevel(string levelName)
    {
        SceneManager.UnloadSceneAsync(currentLevel);
        SceneManager.LoadSceneAsync(levelName);
    }

    public void loadNextLevel()
    {
        loadLevel(nextLevel);
    }


    public void restartGame() // Restart
    {
        SceneManager.UnloadSceneAsync(currentLevel);
        SceneManager.LoadSceneAsync(currentLevel);
    }


    public void quitGame() // Quit
    {
        Application.Quit();
    }

}
