using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    IEnumerator SpawnFruit()
    {
        while (true)
        {
            var go = Instantiate(fruitPrefab[Random.Range(0, fruitPrefab.Length)]);

            var tempBody = go.GetComponent<Rigidbody>();
            tempBody.velocity = new Vector3(0f, 8f, .8f);
            tempBody.angularVelocity = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f,5f));
            tempBody.useGravity = true;

            Vector3 pos = transform.position;
            pos.x += Random.Range(-1f, 1f);
            go.transform.position = pos;
            
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
