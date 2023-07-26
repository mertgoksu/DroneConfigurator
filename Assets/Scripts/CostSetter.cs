using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class CostSetter : MonoBehaviour
{
    public int costPropeller = 0; // Baþlangýçta maliyeti 0 olarak ayarla
    public int costBackPropeller = 0; // Baþlangýçta maliyeti 0 olarak ayarla
    public int costGuard = 0; // Baþlangýçta maliyeti 0 olarak ayarla
    public int costColour = 0; // Baþlangýçta maliyeti 0 olarak ayarla

    public TextMeshProUGUI costText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayDroneCost();
    }

    public void DisplayDroneCost()
    {
        // CostSetter script'indeki DroneCostCalc() fonksiyonunu çaðýrarak maliyeti alýn
        int droneCost = DroneCostCalc();

        // TextMeshPro ile ekrana maliyeti yazdýr
        costText.text = "$ " + droneCost.ToString();
    }

    public int DroneCostCalc()
    {

        GameObject propeller2Top = GameObject.Find("propeller2Top");
        GameObject propeller3Top = GameObject.Find("propeller3Top");
        GameObject propeller3TopModded = GameObject.Find("propeller3TopModded");
        GameObject propeller4Top = GameObject.Find("propeller4Top");

        GameObject propeller2Back = GameObject.Find("propeller2Back");
        GameObject propeller3Back = GameObject.Find("propeller3Back");
        GameObject propeller4Back = GameObject.Find("propeller4Back");

        GameObject guard1 = GameObject.Find("guard1");
        GameObject guard2 = GameObject.Find("guard2");
        GameObject guard3 = GameObject.Find("guard3");

        //Top Propellers cost
        if (propeller2Top != null && propeller2Top.activeSelf == true)
        {
            costPropeller = 5;
        }
        else if (propeller3Top != null && propeller3Top.activeSelf == true)
        {
            costPropeller = 6;
        }
        else if (propeller3TopModded != null && propeller3TopModded.activeSelf == true)
        {
            costPropeller = 7;
        }
        else if (propeller4Top != null && propeller4Top.activeSelf == true)
        {
            costPropeller = 8;
        }
        else
        {
            Debug.Log("No propeller is active!");
        }

        //Back Propeller Cost
        if (propeller2Back != null && propeller2Back.activeSelf == true)
        {
            costBackPropeller = 6;
        }
        else if (propeller3Back != null && propeller3Back.activeSelf == true)
        {
            costBackPropeller = 7;
        }
        else if (propeller4Back != null && propeller4Back.activeSelf == true)
        {
            costBackPropeller = 8;
        }
        else
        {
            costBackPropeller = 0;
        }


        //Guards Costs
        if (guard1 != null && guard1.activeSelf == true)
        {
            costGuard = 10;
        }
        else if (guard2 != null && guard2.activeSelf == true)
        {
            costGuard = 11;
        }
        else if (guard3 != null && guard3.activeSelf == true)
        {
            costGuard = 12;
        }
        else
        {
            Debug.Log("No guard is active!");
        }

        int totalCost = costPropeller + costBackPropeller + costGuard;


        return totalCost;
    }


}