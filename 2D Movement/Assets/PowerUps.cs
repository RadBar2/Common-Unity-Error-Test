using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 13 objektai buvo nepriskirti
public class PowerUps : MonoBehaviour
{
    public GameObject[] powerups;
    void Start()
    {
        StartCoroutine(SpawnPowerup()); // 18 Coroutine
    }

    IEnumerator SpawnPowerup()
    {
        yield return new WaitForSeconds(2);

        if (powerups.Length > 0) // 16 infinite loop
        {
            int randomIndex = Random.Range(0, powerups.Length); // 17 index out of bounds 
            Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
            Instantiate(powerups[randomIndex], spawnPosition, Quaternion.identity);
        }
    }
}
