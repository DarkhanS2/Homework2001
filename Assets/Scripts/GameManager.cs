using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject[] cubes; 
    void Start()
    {
        cubes = GameObject.FindGameObjectsWithTag("Cube");
        QuickSort(cubes, 0, cubes.Length - 1);
        VisualizeSortedArray();
    }

    void QuickSort(GameObject[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);
            QuickSort(arr, left, pivot - 1);
            QuickSort(arr, pivot + 1, right);
        }
    }

    int Partition(GameObject[] arr, int left, int right)
    {
        GameObject pivot = arr[right];
        float pivotValue = pivot.transform.position.y;
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (arr[j].transform.position.y < pivotValue)
            {
                i++;
                GameObject temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        GameObject tempPivot = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = tempPivot;

        return i + 1;
    }
    void VisualizeSortedArray()
    {
        float startPositionX = 0f; 
        float gap = 6f;
        float fixedPositionZ = 0f;

        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.position = new Vector3(startPositionX + i * gap, cubes[i].transform.position.y, fixedPositionZ);
        }
    }
}