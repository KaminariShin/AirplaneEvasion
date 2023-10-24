using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI textScore;

    void Update()
    {
        score = (int)Stats.ScoreCount();            //Получение информации из класса Stats метода ScoreCount(подсчёта игровых очков) и приведение его к типу значения int(целочисленому значению)        
        textScore.text = score.ToString();          //Конверт score(счёта) в string(текст) и вывод на экран во время игры
    }
}
