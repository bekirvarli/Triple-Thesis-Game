using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelButton : MonoBehaviour
{
    [Header ("Active Stuff")]
    public bool isActive;
    public Sprite activeSprite;
    public Sprite lockedSprite;
    private Image buttonImage;
    private Button myButton;
    private int starsActive;


    [Header ("Level UI")]
    public Image[] stars;
    public Text levelText;
    public int level;
    public GameObject confirmpanel;
    


    private GameData gameData;
    void Start()
    {
      
        gameData = FindObjectOfType<GameData>();
        buttonImage = GetComponent<Image>();
        myButton = GetComponent<Button>();
        LoadData();
        ActivateStars();
        ShowLevel();
        DecideSprite();
    }
    void LoadData()
    {
        if(gameData != null)
        {
            if (gameData.saveData.isActive[level-1])
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
            starsActive = gameData.saveData.stars[level-1];
        }

    }

    void ActivateStars()
    {
        for (int i = 0; i < starsActive; i++)
        {
            stars[i].enabled = true;
        }
    }

    void DecideSprite()
    {
        if(isActive)
        {
            buttonImage.sprite = activeSprite;
            myButton.enabled = true;
            levelText.enabled = true;
        }
        else
        {
            buttonImage.sprite = lockedSprite;
            myButton.enabled = false;
            levelText.enabled = false;
        }
    }

    void ShowLevel()
    {
        levelText.text = "" + level;
    }

    void Update()
    {

    }

    void ConfirmPanel(int level)
    {
        confirmpanel.GetComponent<ConfirmPanel>().level = level;
        confirmpanel.SetActive(true);
    }
}