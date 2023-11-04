using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign the enemy prefab in the Inspector
    public int xAxis;
    public int zAxis;
    public int enemyCount;

    public GameObject playerController; // Assign the player controller object in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 2)
        {
            xAxis = Mathf.FloorToInt(Random.Range(400f, 420f));
            zAxis = Mathf.FloorToInt(Random.Range(33f, 44f));
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(xAxis, 0.7043388f, zAxis), Quaternion.identity);

            // Set the target GameObject on the new enemy.
            newEnemy.GetComponent<EnemyAI>().target = playerController;

            yield return new WaitForSeconds(4.5f);
            enemyCount++;
        }
    }
}

