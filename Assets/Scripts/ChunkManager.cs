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
        Destroy(other.transform.parent.gameObject);                                                     //”ничтожение чанка дошедшего до кра€
        Load();                                                                                         //«агрузка нового чанка и смещение масива на -1
        Spawn(maxChunk, range);
    }

    private void PreLoad()                                                                              //ѕредзагрузка первых чанков
    {
        for (int i = 0; i < chunkArray.Length; i++)
        {
            currentChunk = Random.Range(1, 4);                                                          //¬ыбор варианта чанка дл€ загрузки в пулл
            chunkArray[i] = Resources.Load<GameObject>("Chunks/" + currentChunk);                       //«агрузка выбраного варианта в масив чанков
        }
    }

    private void Load()
    {
        for (int i = 0; i <= chunkArray.Length; i++)
        {
            if (i == chunkArray.Length - 1)
            {
                currentChunk = Random.Range(1, 4);                                                      //¬ыбор варианта чанка дл€ загрузки в пулл
                chunkArray[i] = Resources.Load<GameObject>("Chunks/" + currentChunk);                   //«агрузка выбраного варианта в масив чанков
                break;
            }
            chunkArray[i] = chunkArray[i + 1];
        }
    }

    private void Spawn(int value, int range)                                                            //—павн чанков на расто€ние равному константе расто€ни€ между чанками * n количества чанков
    {
            Instantiate(chunkArray[value], new Vector3(0, 0, range * value), Quaternion.identity);
    }

    private void StartSpawn(int value, int range)                                                       //—павн чанков на расто€ние равному константе расто€ни€ между чанками * на номер чанка
    {
            Instantiate(chunkArray[value], new Vector3(0, 0, range), Quaternion.identity);
    }
}
