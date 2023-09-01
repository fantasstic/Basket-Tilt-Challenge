using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrilliantSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPositions; 
    [SerializeField] private GameObject _diamondPrefab;   

    private int currentSpawnIndex = 0; 

    private void Start()
    {
        SpawnDiamond();
    }

    private void SpawnDiamond()
    {
        if (currentSpawnIndex < _spawnPositions.Length)
        {
            GameObject diamond = Instantiate(_diamondPrefab, _spawnPositions[currentSpawnIndex].position, Quaternion.identity);
            diamond.transform.SetParent(transform); 
            currentSpawnIndex++;
        }
    }

    public void DiamondPickedUp()
    {
        StartCoroutine(WaitAndSpawn());
    }

    private IEnumerator WaitAndSpawn()
    {
        yield return new WaitForSeconds(0.2f); 
        SpawnDiamond();
    }
}
