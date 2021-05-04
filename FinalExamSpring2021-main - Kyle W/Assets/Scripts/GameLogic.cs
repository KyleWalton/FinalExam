using UnityEngine.SceneManagement;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private bool gameHasEnded = false;

    public void EndGame()
    {
        if (Data.Instance.playerLives == 0 || Data.Instance.playTime == 0)
        {
            gameHasEnded = true;
            Debug.Log("End Game");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void AddScore()
    {
        Data.Instance.score++;
    }

    public void MinusScore()
    {
        Data.Instance.score--;
    }

    public void AddLives()
    {
        Data.Instance.playerLives++;
    }

    public void MinusLives()
    {
        Data.Instance.playerLives--;
    }

    public void ForceEndGame()
    {
            gameHasEnded = true;
            Debug.Log("End Game");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        AddScore();
        MinusScore();
        AddLives();
        MinusLives();
        EndGame();
    }
}
