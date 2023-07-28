using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WingSwitch : ObjectSwitcher
{
    public ModelSwitch modelSwitch;
    [SerializeField]
    private List<GameObject> wingsListD0, wingsListD1, wingsListD2;
    private List<List<GameObject>> wingsLists = new List<List<GameObject>>();


    public int droneCurrentIndex;
    private void Start()
    {
        wingsLists = new List<List<GameObject>>
{
    wingsListD0,
    wingsListD1,
    wingsListD2
};
        modelSwitch = GameObject.Find("ModelManager").GetComponent<ModelSwitch>();
        currentIndex = 0;
        ChangeObject(currentIndex);
    }
    private void Update()
    {
       
        droneCurrentIndex = modelSwitch.currentDroneIndex;
    }
    public override void ChangeObject(int index)
    {
        List<GameObject> wingsList = wingsLists[droneCurrentIndex];

        for (int i = 0; i < wingsList.Count; i++)
        {
            GameObject wing = wingsList[i];
            wing.SetActive(i == index);
        }
    }

    public override void ToRightChangerFuncButton()
    {
        List<GameObject> wingsList = wingsLists[droneCurrentIndex];
        currentIndex++;
        if (currentIndex >= wingsList.Count)
        {
            currentIndex = 0;
        }
        ChangeObject(currentIndex);
    }

    public override void ToLeftChangerFuncButton()
    {
        List<GameObject> wingsList = wingsLists[droneCurrentIndex];
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = wingsList.Count-1;
        }
        ChangeObject(currentIndex);
    }
}
