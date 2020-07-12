using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float moveSpeed;
    private int dir = 1;
    public GameObject[] _food;
    public bool _spawnFood = true;
    public float _foodSpawnRate = 5f;
    public GameObject[] _destructibles;
    public bool _spawnDestructibles = true;
    public float _destructibleSpawnRate = 5f;

    void Start()
    {
        if(_food != null)
        {
            StartCoroutine(SpawnFood());
            print("food");
        }
        if(_destructibles != null)
        {
            StartCoroutine(SpawnDestructibles());
            print("destruct");
        }
        
    }

    void Update()
    {
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime * dir, 0f, 0f));
    }

    private void OnTriggerEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            dir *= -1;
        }
    }

    IEnumerator SpawnFood()
    {
        while (_spawnFood)
        {
            int id = Random.Range(0, _food.Length);
            Instantiate(_food[id], transform.position, Quaternion.identity);
            print("foodro");

            yield return new WaitForSeconds(_foodSpawnRate);
        }
    }

    IEnumerator SpawnDestructibles()
    {
        while(_spawnDestructibles)
        {
            int id = Random.Range(0, _destructibles.Length);
            Instantiate(_destructibles[id], transform.position, Quaternion.identity);
            print("desro");

            yield return new WaitForSeconds(_destructibleSpawnRate);
        }
    }

}
