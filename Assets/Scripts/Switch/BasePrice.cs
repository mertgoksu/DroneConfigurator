using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePrice : MonoBehaviour
{
    private List<int> dataList = new List<int>();

    public void AddDataToList(int data)
    {
        dataList.Add(data);
    }
}
