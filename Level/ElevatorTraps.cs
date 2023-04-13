using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTraps : MonoBehaviour
{
    [Header("Настройка ловушек")]
    [Tooltip("Точки выстрелов")]
    [SerializeField] private Transform[] firePoints;
    [Tooltip("Префаб снаряда")]
    [SerializeField] private GameObject bullet;

    private bool startFire;
    private int timeFire;

    private void Awake()
    {
        timeFire = Random.Range(1,2);
    }


    private void Update()
    {
        if (Elevator.start && !startFire)
        {
            StartCoroutine(fire(timeFire));
        }
    }

    IEnumerator fire(int time)
    {
        startFire = true;

        while (startFire)
        {
            foreach (var fire in firePoints)
            {
                yield return new WaitForSeconds(time);
                Instantiate(bullet, fire);
            }

        }
    }

}
