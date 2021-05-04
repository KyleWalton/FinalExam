using UnityEngine;
using UnityEngine.UI;

public class DataAccessor : MonoBehaviour
{
    //Allows you to access the Data Instance for Game and End scenes.
    public Text playerLives;

    public Text playTime;

    public Text playerName;

    public Text score;



    // Update is called once per frame
    void Update()
    {
        playerName.text = "Currently playing: " + Data.Instance.playerName;
        playerLives.text = "" + Data.Instance.playerLives;
        playTime.text = "" + Data.Instance.playTime;
        score.text = "" + Data.Instance.score;
    }
}
