using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private int maxEnemies = 5;
    private List<GameObject> _enemies = new List<GameObject>();

    void Start()
    {

    }

    void Update()
    {
        if(_enemies.Count < maxEnemies)
        {
            var enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = new Vector3(Random.Range(-25,25), 2f, Random.Range(-25,25));
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
            Register(enemy);
        }
    }

    public void RemoveChild(GameObject gameObject)
    {
        _enemies.Remove(gameObject);
    }

    private void Register(GameObject enemy)
    {
        enemy.GetComponent<ReactiveTarget>().Register(this);
        _enemies.Add(enemy);
    }
}
