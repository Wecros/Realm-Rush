using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // start a coroutine
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    private IEnumerator RepeatedlySpawnEnemies() {
        while (true) {  // forever
            print("Spawning");
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
