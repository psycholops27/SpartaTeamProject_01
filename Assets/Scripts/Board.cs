using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject Card;
    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9};
        arr = arr.OrderBy(x => Random.Range(0f, 10f)). ToArray();

        for (int i = 0; i < 20; i++)
        {
            GameObject go = Instantiate(Card, this.transform);
            
            float x = (i % 5) * 3.0f - 6.0f; 
            float y = (i / 5) * 2.0f - 3.5f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i]);
        }

        GameManager.instance.CardCount = arr.Length; // arr.Length는 배열의 길이
    }
}
