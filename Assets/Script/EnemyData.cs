using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "ScriptableObject/ScoreData", order = 1)]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private int highScore;

    public int HighScore { get => highScore; set => highScore = value; }
}
