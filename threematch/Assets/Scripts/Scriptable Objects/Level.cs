using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "World" , menuName = "Level")]
public class Level : ScriptableObject
{
    [Header ("Board Dimensions")]
    public int width;
    public int height;

    [Header("Starting Tiles")]
    public TileType[] boardLayout;

    [Header("Available Dots")]
    public GameObject[] dots;

    [Header("Score Goals")]
    public int[] scoreGoals;

    [Header ("End Game Rquirements")]
    public EndGameRequirements endGameRequirements;
    public BlankGoal[] levelGoals;
}
