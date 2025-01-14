using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameType
{
    Moves,
    Time
}


[System.Serializable]
public class EndGameRequirements
{
    public GameType gameType;
    public int counterValue;
}
public class EndGameManager : MonoBehaviour
{

    public GameObject movesLabel;
    public GameObject timeLabel;
    public GameObject youwinPanel;
    public GameObject tryAgainPanel;
    public Text counter;
    public EndGameRequirements requirements;
    private Board board;
    public int currentCounterValue;
    private float timerSeconds;
    void Start()
    {
        board = FindObjectOfType<Board>();
        SetGameType();
        SetupGame();
        
    }

    void SetGameType()
    {
        if (board.level < board.world.levels.Length)
        {

            if (board.world != null)
            {
                if (board.world.levels[board.level] != null)
                {
                    requirements = board.world.levels[board.level].endGameRequirements;
                }
            }
        }
    }
    void SetupGame()
    {

        currentCounterValue = requirements.counterValue;
        if(requirements.gameType== GameType.Moves)
        {
            movesLabel.SetActive(true);
            timeLabel.SetActive(false);
        }
        else
        {
            timerSeconds = 1;
            movesLabel.SetActive(false);
            timeLabel.SetActive(true);
        }
        counter.text = "" + currentCounterValue;

    }
    public void DecreaseCounterValue()
    {
        if (board.currentState != GameState.pause)
        {
            currentCounterValue--;
            counter.text = "" + currentCounterValue;

            if (currentCounterValue <= 0)
            {
                LoseGame();
            }
        }
    }
    public void WinGame()
    {
        youwinPanel.SetActive(true);
        board.currentState = GameState.win;
        currentCounterValue = 0;
        counter.text = "" + currentCounterValue;
        FadePanelContoller fade = FindObjectOfType<FadePanelContoller>();
        fade.GameOver();

    }
    public void LoseGame()
    {

        tryAgainPanel.SetActive(true);
        board.currentState = GameState.lose;
        Debug.Log("kaybetin");
        currentCounterValue = 0;
        counter.text = "" + currentCounterValue;
        FadePanelContoller fade = FindObjectOfType<FadePanelContoller>();
        fade.GameOver();

    }
    void Update()
    {
        if(requirements.gameType == GameType.Time && currentCounterValue >0 ) 
        {
            timerSeconds -= Time.deltaTime;
            if(timerSeconds <= 0)
            {
                DecreaseCounterValue();
                timerSeconds = 1;
            }
        }
        
    }
}
