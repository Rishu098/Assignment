using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesSpawn : MonoBehaviour
{
    public GameObject theEnemies;
    public int xPos;
    public int zPos;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("enemyDrop");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator enemyDrop()
    {
        while (enemyCount < 10)
        {
            xPos = Random.Range(400, -400);
            zPos = Random.Range(400, -400);
            Instantiate(theEnemies, new Vector3(xPos, 3f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(10f);
            enemyCount += 1;
        }

    }
}
