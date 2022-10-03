using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerCost = 50;
    [SerializeField][Range(0,12)] float buildTime = 3f;

    static int cost = 50;
    public static int Cost { get { return cost; } }

    private void Start()
    {
        cost = towerCost;
        DeactivateTower();
        StartCoroutine(Build());
    }

    public bool CreateTower(Tower tower, Vector3 position)
    {


        Bank bank = FindObjectOfType<Bank>();

        if(bank == null)
        {
            return false;
        }

        if(bank.CurrentBalance >= towerCost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(towerCost);
            return true;
        }

        return false;

    }

    IEnumerator Build()
    {
        float time = buildTime / 3;

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(time);
            foreach (Transform grandchild in transform)
            {
                grandchild.gameObject.SetActive(true);
            }

        }

    }

    void DeactivateTower()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach(Transform grandchild in transform)
            {
                grandchild.gameObject.SetActive(false);
            }
        }
    }
}
