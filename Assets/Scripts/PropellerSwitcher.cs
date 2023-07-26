using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSwitcher : MonoBehaviour
{
    private List<GameObject> wingsList = new List<GameObject>(); // "Wings" tag'ine sahip child objeleri tutacak liste
    private List<GameObject> guardsList = new List<GameObject>(); // "Guards" tag'ine sahip child objeleri tutacak liste
    private List<GameObject> backWingList = new List<GameObject>(); // "BackWings" tag'ine sahip child objeleri tutacak liste

    private int currentWingIndex = 0; // Þu anki Wing'in indeksi
    private int currentGuardIndex = 0; // Þu anki Guard'ýn indeksi
    private int currentBackWingIndex = 0; // Þu anki BackWing'in indeksi


    //private List<GameObject> wingsPNGList = new List<GameObject>(); // "BackWings" tag'ine sahip child objeleri tutacak liste
    //private List<GameObject> backWingPNGList = new List<GameObject>(); // "BackWings" tag'ine sahip child objeleri tutacak liste
    //private List<GameObject> guardPNGList = new List<GameObject>(); // "BackWings" tag'ine sahip child objeleri tutacak liste

    //private int currentWingsPNGIndex = 0; // Þu anki BackWing'in indeksi
    //private int currentBackWingsPNGIndex = 0; // Þu anki BackWing'in indeksi
    //private int currentGuardPNGIndex = 0; // Þu anki BackWing'in indeksi

    void Start()
    {
        // "Wings", "Guards" ve "BackWings" tag'ine sahip child objeleri listelere ekleyelim
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Wings"))
                wingsList.Add(child.gameObject);
            else if (child.CompareTag("Guards"))
                guardsList.Add(child.gameObject);
            else if (child.CompareTag("BackWings"))
                backWingList.Add(child.gameObject);


            //else if (child.CompareTag("WingsPNG"))
            //    wingsPNGList.Add(child.gameObject);
            //else if (child.CompareTag("BackWingsPNG"))
            //    backWingPNGList.Add(child.gameObject);
            //else if (child.CompareTag("GuardsPNG"))
            //    guardPNGList.Add(child.gameObject);

        }

        ChangeWing(currentWingIndex);
        ChangeGuard(currentGuardIndex);
        ChangeBackWing(currentBackWingIndex);



    }

    void Update()
    {

    }

    //void ChangeWingPNG(int index)
    //{
    //    for (int i = 0; i < wingsPNGList.Count; i++)
    //    {
    //        GameObject wingPNG = wingsPNGList[i];
    //        wingPNG.SetActive(i == index);
    //    }
    //}

    //void ChangeBackWingPNG(int index)
    //{
    //    for (int i = 0; i < backWingPNGList.Count; i++)
    //    {
    //        GameObject backWingPNG = backWingPNGList[i];
    //        backWingPNG.SetActive(i == index);
    //    }
    //}

    //void ChangeGuardPNG(int index)
    //{
    //    for (int i = 0; i < guardPNGList.Count; i++)
    //    {
    //        GameObject guardPNG = guardPNGList[i];
    //        guardPNG.SetActive(i == index);
    //    }
    //}


    void ChangeWing(int index)
    {
        for (int i = 0; i < wingsList.Count; i++)
        {
            GameObject wing = wingsList[i];
            wing.SetActive(i == index);
        }
    }

    void ChangeGuard(int index)
    {
        for (int i = 0; i < guardsList.Count; i++)
        {
            GameObject guard = guardsList[i];
            guard.SetActive(i == index);
        }
    }

    void ChangeBackWing(int index)
    {
        for (int i = 0; i < backWingList.Count; i++)
        {
            GameObject backWing = backWingList[i];
            backWing.SetActive(i == index);
        }
    }

    public void ToRightGuardChangerFuncButton()
    {
        currentGuardIndex++;
        if (currentGuardIndex >= guardsList.Count)
            currentGuardIndex = 0;

        //currentGuardPNGIndex++;
        //if (currentGuardPNGIndex >= guardPNGList.Count)
        //    currentGuardPNGIndex = 0;
        //ChangeGuardPNG(currentGuardPNGIndex);

        ChangeGuard(currentGuardIndex);
        
    }

    public void ToLeftGuardChangerFuncButton()
    {
        currentGuardIndex--;
        if (currentGuardIndex < 0)
            currentGuardIndex = guardsList.Count - 1;

        //currentGuardPNGIndex--;
        //if (currentGuardPNGIndex < 0)
        //    currentGuardPNGIndex = guardPNGList.Count - 1;
        //ChangeGuardPNG(currentGuardPNGIndex);


        ChangeGuard(currentGuardIndex);
    
    }


    public void ToRightWingChangerFuncButton()
    {
        currentWingIndex++;
        if (currentWingIndex >= wingsList.Count)
            currentWingIndex = 0;

        //currentWingsPNGIndex++;
        //if (currentWingsPNGIndex >= wingsPNGList.Count)
        //    currentWingsPNGIndex = 0;
        //ChangeWingPNG(currentWingsPNGIndex);

        ChangeWing(currentWingIndex);
       
    }

    public void ToLeftWingChangerFuncButton()
    {
        currentWingIndex--;
        if (currentWingIndex < 0)
            currentWingIndex = wingsList.Count - 1;

        //currentWingsPNGIndex--;
        //if(currentWingsPNGIndex < 0)
        //    currentWingsPNGIndex = wingsPNGList.Count - 1;
        //ChangeWingPNG(currentWingsPNGIndex);

        ChangeWing(currentWingIndex);

    }

    public void ToRightBackWingChangerFuncButton()
    {
        currentBackWingIndex++;
        if (currentBackWingIndex >= backWingList.Count)
            currentBackWingIndex = 0;

        //currentBackWingsPNGIndex++;
        //if (currentBackWingsPNGIndex >= backWingPNGList.Count)
        //    currentBackWingsPNGIndex = 0;
        //ChangeBackWingPNG(currentBackWingsPNGIndex);

        ChangeBackWing(currentBackWingIndex);

    }

    public void ToLeftBackPropellerChangerFuncButton()
    {
        currentBackWingIndex--;
        if (currentBackWingIndex < 0)
            currentBackWingIndex = backWingList.Count - 1;

        //currentBackWingsPNGIndex--;
        //if (currentBackWingsPNGIndex < 0)
        //    currentBackWingsPNGIndex = backWingPNGList.Count - 1;
        //ChangeBackWingPNG(currentBackWingsPNGIndex);

        ChangeBackWing(currentBackWingIndex);

    }

    
}
