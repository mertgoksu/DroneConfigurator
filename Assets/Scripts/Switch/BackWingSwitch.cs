using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWingSwitch : ObjectSwitcher
{
    public ModelSwitch modelSwitch;
    [SerializeField]
    private List<GameObject> backWingList;
    public int currentIndexDrone;
    void Start()
    {
        modelSwitch = GameObject.Find("ModelManager").GetComponent<ModelSwitch>();
        currentIndex = 0;
        ChangeObject(currentIndex);
    }
    private void Update()
    {
        currentIndexDrone = modelSwitch.currentDroneIndex;
    }

    public override void ChangeObject(int index)
    {
        for (int i = 0; i < backWingList.Count; i++)
        {
            GameObject backWing = backWingList[i];
            backWing.SetActive(i == index);
        }
    }

    public override void ToRightChangerFuncButton()
    {
        if (currentIndexDrone == 0)
        {
            currentIndex++;
            if (currentIndex >= backWingList.Count)
                currentIndex = 0;
            ChangeObject(currentIndex);
        }


    }

    public override void ToLeftChangerFuncButton()
    {
        if (currentIndexDrone == 0)
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = backWingList.Count - 1;
            ChangeObject(currentIndex);
        }
    }
}
