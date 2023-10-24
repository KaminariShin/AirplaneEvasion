using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField]
    private int maxChunk; 
    [SerializeField]
    private int range;
    [SerializeField]
    private GameObject[] chunkArray;
    private int currentChunk;
    public static bool localRotate = false;

    void Start()
    {
        PreLoad();
        for (int i = 0; i < maxChunk; i++)
        {
            StartSpawn(i ,range*(i+1));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.transform.parent.gameObject);                                                     //����������� ����� ��������� �� ����
        Load();                                                                                         //�������� ������ ����� � �������� ������ �� -1
        Spawn(maxChunk, range);
    }

    private void PreLoad()                                                                              //������������ ������ ������
    {
        for (int i = 0; i < chunkArray.Length; i++)
        {
            currentChunk = Random.Range(1, 4);                                                          //����� �������� ����� ��� �������� � ����
            chunkArray[i] = Resources.Load<GameObject>("Chunks/" + currentChunk);                       //�������� ��������� �������� � ����� ������
        }
    }

    private void Load()
    {
        for (int i = 0; i <= chunkArray.Length; i++)
        {
            if (i == chunkArray.Length - 1)
            {
                currentChunk = Random.Range(1, 4);                                                      //����� �������� ����� ��� �������� � ����
                chunkArray[i] = Resources.Load<GameObject>("Chunks/" + currentChunk);                   //�������� ��������� �������� � ����� ������
                break;
            }
            chunkArray[i] = chunkArray[i + 1];
        }
    }

    private void Spawn(int value, int range)                                                            //����� ������ �� ��������� ������� ��������� ��������� ����� ������� * n ���������� ������
    {
            Instantiate(chunkArray[value], new Vector3(0, 0, range * value), Quaternion.identity);
    }

    private void StartSpawn(int value, int range)                                                       //����� ������ �� ��������� ������� ��������� ��������� ����� ������� * �� ����� �����
    {
            Instantiate(chunkArray[value], new Vector3(0, 0, range), Quaternion.identity);
    }
}
