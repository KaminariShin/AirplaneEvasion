using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var o = Stats.Wallet();                                                 //��������� ���������� �� ������ Stats ������ Wallet
        var b = Stats.BestScore();                                              //��������� ���������� �� ������ Stats ������ BestScore
        Debug.Log("wallet " + o + " ,LastScore " + b);                          //����� ��������� ����. � ��� ��� �������� �����������
        EditorApplication.isPaused = true;                                      //����� ��� ������� ��������� ����. � ���
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       //���������� �����
    }
}
