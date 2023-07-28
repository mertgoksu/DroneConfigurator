using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class CostSetter : MonoBehaviour
{
    public ModelSwitch modelSwitch;
    public int costPropeller = 0; // Ba�lang��ta maliyeti 0 olarak ayarla
    public int costBackPropeller = 0; // Ba�lang��ta maliyeti 0 olarak ayarla
    public int costGuard = 0; // Ba�lang��ta maliyeti 0 olarak ayarla
    public int costColour = 0; // Ba�lang��ta maliyeti 0 olarak ayarla

    public GameObject[] wingList, backWingList, guardList;


    public TextMeshProUGUI costText;
    public int activeDroneIndex;

    // Start is called before the first frame update
    void Start()
    {
        modelSwitch = GameObject.Find("ModelManager").GetComponent<ModelSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        activeDroneIndex = modelSwitch.currentDroneIndex;
        DisplayDroneCost();

    }

    public void DisplayDroneCost()
    {
        // CostSetter script'indeki DroneCostCalc() fonksiyonunu �a��rarak maliyeti al�n
        int droneCost = DroneCostCalc();

        // TextMeshPro ile ekrana maliyeti yazd�r
        costText.text = "$ " + droneCost.ToString();
    }

    public int DroneCostCalc()
    {

        foreach (GameObject item in wingList)
        {
            if (item.activeInHierarchy)
            {
                Price price = item.GetComponent<Price>();
                costPropeller = price.price;
            }
        }
        foreach (GameObject item in guardList)
        {
            if (item.activeInHierarchy)
            {
                Price price = item.GetComponent<Price>();
                costGuard = price.price;
            }
        }
        if (activeDroneIndex == 0)
        {
            foreach (GameObject item in backWingList)
            {
                if (item.activeInHierarchy)
                {
                    Price price = item.GetComponent<Price>();
                    costBackPropeller = price.price;
                }

            }
        }
        else
        {
            costBackPropeller = 0;
        }


        #region
        //GameObject propeller2Top = GameObject.Find("propeller2Top");
        //GameObject propeller3Top = GameObject.Find("propeller3Top");
        //GameObject propeller3TopModded = GameObject.Find("propeller3TopModded");
        //GameObject propeller4Top = GameObject.Find("propeller4Top");

        //GameObject propeller2Back = GameObject.Find("propeller2Back");
        //GameObject propeller3Back = GameObject.Find("propeller3Back");
        //GameObject propeller4Back = GameObject.Find("propeller4Back");

        //GameObject guard1 = GameObject.Find("guard1");
        //GameObject guard2 = GameObject.Find("guard2");
        //GameObject guard3 = GameObject.Find("guard3");

        ////Top Propellers cost
        //if (propeller2Top != null && propeller2Top.activeSelf == true)
        //{
        //    costPropeller = 5;
        //}
        //else if (propeller3Top != null && propeller3Top.activeSelf == true)
        //{
        //    costPropeller = 6;
        //}
        //else if (propeller3TopModded != null && propeller3TopModded.activeSelf == true)
        //{
        //    costPropeller = 7;
        //}
        //else if (propeller4Top != null && propeller4Top.activeSelf == true)
        //{
        //    costPropeller = 8;
        //}
        //else
        //{
        //    Debug.Log("No propeller is active!");
        //}

        ////Back Propeller Cost
        //if (propeller2Back != null && propeller2Back.activeSelf == true)
        //{
        //    costBackPropeller = 6;
        //}
        //else if (propeller3Back != null && propeller3Back.activeSelf == true)
        //{
        //    costBackPropeller = 7;
        //}
        //else if (propeller4Back != null && propeller4Back.activeSelf == true)
        //{
        //    costBackPropeller = 8;
        //}
        //else
        //{
        //    costBackPropeller = 0;
        //}


        ////Guards Costs
        //if (guard1 != null && guard1.activeSelf == true)
        //{
        //    costGuard = 10;
        //}
        //else if (guard2 != null && guard2.activeSelf == true)
        //{
        //    costGuard = 11;
        //}
        //else if (guard3 != null && guard3.activeSelf == true)
        //{
        //    costGuard = 12;
        //}
        //else
        //{
        //    Debug.Log("No guard is active!");
        //}
        #endregion


        int totalCost = costPropeller + costBackPropeller + costGuard;


        return totalCost;
    }


}