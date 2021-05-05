using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLixo : MonoBehaviour, ILixeiro
{
    public Inutil criarOvelha(GameObject spawnObject)
    {
        return new OvelhaInutil(spawnObject);
    }
}
