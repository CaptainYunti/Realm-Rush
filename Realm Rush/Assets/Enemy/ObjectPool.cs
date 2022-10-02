using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    [SerializeField][Range(0, 50)] int poolSize = 5;
    [SerializeField][Range(0.1f, 30f)] float secondsNewEnemy = 1f;

    GameObject[] pool;


    private void Awake()
    {
        PopulatePool();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NewEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }

    IEnumerator NewEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(secondsNewEnemy);
        }
    }

    private void EnableObjectInPool()
    {
        foreach(GameObject enemy in pool)
        {
            if(!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return;
            }
        }
    }
}
