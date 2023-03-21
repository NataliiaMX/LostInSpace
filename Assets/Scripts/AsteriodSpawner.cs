using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteriodPrefabs;
    [SerializeField] private float timeBetweenAsteriodSpawns;
    [SerializeField] private Vector2 forceRange;
    private Camera mainCamera;
    private float timer;

    private void Start() 
    {
        mainCamera = Camera.main;
    }

    private void Update() 
    {
        ReduceTimerValue();
    }

    private void ReduceTimerValue()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            SpawnAsteriod();
            timer += timeBetweenAsteriodSpawns;
        }
    }

    private void SpawnAsteriod()
    {
        int spawnSide = UnityEngine.Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch(spawnSide)
        {
            case 0: //left side of viewport
            spawnPoint.x = 0;
            spawnPoint.y = UnityEngine.Random.value;
            direction = new Vector2 (1f, UnityEngine.Random.Range(-1f, 1f));
            break;

            case 1: //right side of viewport
            spawnPoint.x = 1;
            spawnPoint.y = UnityEngine.Random.value;
            direction = new Vector2 (-1f, UnityEngine.Random.Range(-1f, 1f));
            break;

            case 2: //bottom side of viewport
            spawnPoint.x = UnityEngine.Random.value;
            spawnPoint.y = 0;
            direction = new Vector2(UnityEngine.Random.Range(-1f, 1f), 1f);
            break;

            case 3: //top side of viewport
            spawnPoint.x = UnityEngine.Random.value;
            spawnPoint.y = 1;
            direction = new Vector2(UnityEngine.Random.Range(-1f, 1f), -1f);
            break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        GameObject selectedAsteriod = asteriodPrefabs[UnityEngine.Random.Range(0, asteriodPrefabs.Length)];
        Quaternion asteriodSpin = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0f, 360f));

        GameObject asteriodInstance =  Instantiate(selectedAsteriod, worldSpawnPoint, asteriodSpin);
        Rigidbody rb = asteriodInstance.GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * forceRange;

        StartCoroutine(DestroyInstance(asteriodInstance));
    }

    IEnumerator DestroyInstance(GameObject instance)
    {
        yield return new WaitForSeconds(3f);
        Destroy(instance);
    }
}
