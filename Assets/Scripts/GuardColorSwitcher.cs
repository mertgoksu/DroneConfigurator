using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardColorSwitcher : MonoBehaviour
{
    public Material[] guardMaterials; // "Guard" nesneleri i�in kullan�lacak 3 farkl� renk materyali


    private int currentColorIndex = 0; // �u anki renk materyali indeksi
    private GameObject currentGuard; // �u an ekranda g�sterilen "Guard" nesnesi

    void Start()
    {
        //ChangeColor();
    }

    void Update()
    {
    }

    public void ChangingNextGuardColourButton()
    {
        SetActiveGuard();
        // Rengi bir sonraki materyalle de�i�tir
        currentColorIndex = (currentColorIndex + 1) % guardMaterials.Length;
        ChangeColor();
    }

    public void ChangingPrevGuardColourButton()
    {
        SetActiveGuard();
        // Rengi bir �nceki materyalle de�i�tir
        currentColorIndex = (currentColorIndex - 1 + guardMaterials.Length) % guardMaterials.Length;
        ChangeColor();
    }

    void SetActiveGuard()
    {
        // "Guard" tag'ine sahip child nesneleri bul
        Transform[] guardChildren = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in guardChildren)
        {
            if (child.CompareTag("Guards") && child.gameObject.activeSelf)
            {
                currentGuard = child.gameObject;
                break;
            }
        }
    }

    void ChangeColor()
    {
        if (currentGuard == null)
        {
            Debug.Log("No active 'Guard' object found!");
            return;
        }

        Renderer guardRenderer = currentGuard.GetComponent<Renderer>();
        if (guardRenderer != null)
        {
            guardRenderer.material = guardMaterials[currentColorIndex];
        }
    }
}
