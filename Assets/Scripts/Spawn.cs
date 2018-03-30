using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {


    Object[] Paths;
    Object[] enemyPrefabs;
    private Vector3 center = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 pos;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    GameObject pathSpawned;
    GameObject enemySpawned;
    //Transform Cam;            //to set enemies to lookAt/face player

    FollowPath followPath;

    //Dictionary<Object, int> pathDict = new Dictionary<Object, int>();

    int pathIndex, enemyIndex;  //index of the path to select

	// Use this for initialization
	void Start () {
        if (GameObject.FindWithTag("GameStage").activeSelf)
        {
            StartCoroutine(SpawnEnemy());
        }

        enemyPrefabs = Resources.LoadAll("Prefabs/Enemies", typeof(Rigidbody));
        Paths = Resources.LoadAll("Prefabs/AllPaths", typeof(SetPath));

	}
	
	// Update is called once per frame
	void Update () {
        if(pathSpawned != null)
        {
            Debug.Log("is not null");
        }
	}

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(startWait);
        
        for (int i = 0; i < Paths.Length;i++)
        {
            pos = center + new Vector3(Random.Range(-1.8f,2.4f), Random.Range(0.2f, 1.7f), Random.Range(-2.0f, 1.8f));
            Object pathS = SelectPath();

            pathSpawned = Instantiate(pathS, Vector3.zero, Quaternion.identity) as GameObject;

            //enemySpawned = Instantiate(SelectEnemy(), pos, Quaternion.identity) as GameObject;
            //Debug.Log("path selected: " + pathSpawned.name);
            
            //followPath = enemySpawned.GetComponent<FollowPath>();
            //followPath.path = pathSpawned.GetComponent<SetPath>();
            yield return new WaitForSeconds(spawnWait);
        }
    }

    //Object SelectEnemy()
    //{
    //    enemyIndex = (int)Random.value;
    //    Debug.Log("index : " + enemyIndex);
    //    if (GameObject.FindWithTag(enemyPrefabs[enemyIndex].name))
    //    {
    //        SelectEnemy();
    //    }
    //    return enemyPrefabs[enemyIndex];
    //    //create array to check if that enemy is already taken
    //    // Select a random number 'n' from Range(0, Length of array -1)
    //    //if n already in array, pick another number
    //    //else pick enemeyPrefabs[n] to spawn. Use this object in SpawnEnemy
    //    // add n to an array.

    //}


    Object SelectPath()
    {

        pathIndex = Random.Range(0, Paths.Length);
        Debug.Log("Path index: " + pathIndex);
        if(GameObject.FindWithTag(Paths[pathIndex].name))
        {
            SelectPath();
        }
        return Paths[pathIndex];

    }

}
