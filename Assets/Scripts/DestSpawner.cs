using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestSpawner : MonoBehaviour
{

    public float moveSpeed;
    private int dir = 1;
    public GameObject[] _destructibles;
    public bool _spawnDestructibles = true;
    public float _destructibleSpawnRate = 5f;

    void Start()
    {
        if (_destructibles != null)
        {
            StartCoroutine(SpawnDestructibles());
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

    IEnumerator SpawnDestructibles()
    {
        while (_spawnDestructibles)
        {
            int id = Random.Range(0, _destructibles.Length);
            Instantiate(_destructibles[id], transform.position, Quaternion.identity);
            print("desro");

            yield return new WaitForSeconds(_destructibleSpawnRate);
        }
    }

}