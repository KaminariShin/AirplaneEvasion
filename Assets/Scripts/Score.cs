using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI textScore;

    void Update()
    {
        score = (int)Stats.ScoreCount();            //��������� ���������� �� ������ Stats ������ ScoreCount(�������� ������� �����) � ���������� ��� � ���� �������� int(������������� ��������)        
        textScore.text = score.ToString();          //������� score(�����) � string(�����) � ����� �� ����� �� ����� ����
    }
}
