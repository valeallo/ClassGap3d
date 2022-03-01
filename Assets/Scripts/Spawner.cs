using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnInterval(2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        Vector2 point = Random.insideUnitCircle * Random.Range(0f, 10f);
        Instantiate(prefab, transform.position + new Vector3(point.x, transform.position.y, point.y), Quaternion.identity);
    }
    IEnumerator SpawnInterval(int i)
    {
        while (true)
        {
            yield return new WaitForSeconds(i);
            Spawn();
        }
    }
}
