using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public float moveSpeed;
    private int dir = 1;
    public GameObject[] _food;
    public bool _spawnFood = true;
    public float _foodSpawnRate = 5f;


    void Start()
    {
        if(_food != null)
        {
            StartCoroutine(SpawnFood());
        }
    }

    void Update()
    {
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime * dir, 0f, 0f));
    }

    private void OnTriggerEnter2D(Collider2D other)
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

}
