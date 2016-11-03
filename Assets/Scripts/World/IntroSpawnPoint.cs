using System.Collections;
using UnityEngine;

public class IntroSpawnPoint : SpawnPoint {

    public void OnEnable()
    {
        spawnEnemy();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        //TODO random
        yield return new WaitForSeconds(Random.Range(1f, 2f));

        spawnEnemy();

        StartCoroutine(SpawnEnemies());
    }

    private void spawnEnemy()
    {
        //TODO not very good design. In parent it's handled by spawn manager.
        GameObject enemy = Instantiate(Enemy, transform.position, transform.rotation) as GameObject;
        enemy.transform.parent = transform.parent;

        enemy.GetComponent<EnemyEventListener>().enabled = false;

        enemy.GetComponent<EnemyMovement>().Speed = 4;
    }

}
