using System;
using System.Collections.Generic;
using UnityEngine;

public static class Stats
{

    #region Характеристики Самолёта
    public static float playerSpeedRotation = 100;   //Z Rotation
    public static float playerSpeedOffset = 0.2f;     //Sensivity
    public static float playerSize = 0.3f;            //Size Multipli
    public static bool isMobile = false;
    #endregion
    #region Характеристики Чанков
    public static float chunkSpeed = 10f;            //-Z Chunk Speed or Level speed
    public const float chunkMaxSpeed = 30f;            //-Z Chunk MaxSpeed or Level speed
    public static float chuncRotateSpeed = 10f;
    private static float chunkSize;             //Size Multipli
    private static int chunkCount;              //Count Chunk one time
    #endregion
    #region Игровые данные
    private static float score = 0;                          //Score in level
    public static int bestScore;                          //Score in level
    private static int money;                          //Money for upgrade. need ?
    #endregion

    public static float ScoreCount()
    {
        return score += 1*Time.deltaTime;        
    }

    public static int BestScore()
    {
        if (bestScore < score)
        {
            bestScore = (int)score;
        }
        score = 0;
        return bestScore;
    }

    public static int Wallet()
    {
        money += Mathf.RoundToInt(score / 10);
        return money;
    }

    public static float LevelSpeed()
    {
        if(chunkSpeed < chunkMaxSpeed)
        {
            chunkSpeed += 1 * Time.deltaTime;
            return chunkSpeed;
        }
        else
        {
            return chunkMaxSpeed;
        }

    }
}
