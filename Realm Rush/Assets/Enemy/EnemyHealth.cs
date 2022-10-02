using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitPints = 5;

    [Tooltip("Adds amount to maxHitPoint when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitPoints = 0;

    Enemy enemy;



    void OnEnable()
    {
        currentHitPoints = maxHitPints;
    }

    // Start is called before the first frame update
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHitPoints--;

        if (currentHitPoints < 1)
        {
            gameObject.SetActive(false);
            maxHitPints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
