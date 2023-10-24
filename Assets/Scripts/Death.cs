using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var o = Stats.Wallet();                                                 //Получение информации из класса Stats метода Wallet
        var b = Stats.BestScore();                                              //Получение информации из класса Stats метода BestScore
        Debug.Log("wallet " + o + " ,LastScore " + b);                          //Вывод полученой инфы. в лог для проверки коректности
        EditorApplication.isPaused = true;                                      //Пауза для осмотра выведеной инфы. в лог
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       //Перезапуск сцены
    }
}
