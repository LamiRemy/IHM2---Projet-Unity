using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour {

    private int gameDifficulty; // Difficulté (1 = Facile, 2 = Normale, 3 = Hardcore)

    void Start()
    {
        print("OK");
        gameDifficulty = 2; // 2 = Difficulté normale
    }

    public void setDifficulty(int difficulty)
    {
        gameDifficulty = difficulty;
        Debug.Log("Game Difficulty set to " + gameDifficulty);
    }

    public int getGameDifficulty()
    {
        return gameDifficulty;
    }
}
