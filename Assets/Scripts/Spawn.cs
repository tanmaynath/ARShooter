using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {


    public GameObject enemyPrefab;
    private Vector3 center = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 pos;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
	// Use this for initialization
	void Start () {
        if (GameObject.FindWithTag("GameStage").activeSelf)
        {
            StartCoroutine(SpawnEnemy());
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(startWait);
        
        for (int i = 0; i < enemyCount;i++)
        {
            pos = center + new Vector3(Random.Range(-1.8f,2.4f), Random.Range(0.2f, 1.7f), Random.Range(-2.0f, 1.8f));
            Instantiate(enemyPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);
        }
    }



}
