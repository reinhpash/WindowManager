using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;

    int playerLevel = 0;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        if (PlayerPrefs.HasKey("Level"))
        {
            playerLevel = PlayerPrefs.GetInt("Level");
        }
        else
        {
            playerLevel = 0;
            PlayerPrefs.SetInt("Level", 0);
        }
        SpawnLevel();
    }

    public void SpawnLevel()
    {
        var lvl = levels[playerLevel];
        Instantiate(lvl);
    }

    public void NextLevel()
    {
        int value = playerLevel += 1;
        if (value == levels.Length)
        {
            SceneManager.LoadScene("EndScene");
        }
        else
        {
            PlayerPrefs.SetInt("Level", value);

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        int value = playerLevel += 1;
        if (value == levels.Length)
        {
            SceneManager.LoadScene("End");
        }
        else
        {
            PlayerPrefs.SetInt("Level", value);
        }

        Application.Quit();
    }
}