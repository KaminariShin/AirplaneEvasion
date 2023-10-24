using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunksMovement : MonoBehaviour
{
    void Update()
    {
        transform.position += -Vector3.forward * Stats.LevelSpeed() * Time.deltaTime;
        if (ChunkManager.localRotate == true)
        {

        }
    }
}
