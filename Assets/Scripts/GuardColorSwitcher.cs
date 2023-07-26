using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardColorSwitcher : MonoBehaviour
{
    public Material[] guardMaterials; // "Guard" nesneleri için kullanýlacak 3 farklý renk materyali


    private int currentColorIndex = 0; // Þu anki renk materyali indeksi
    private GameObject currentGuard; // Þu an ekranda gösterilen "Guard" nesnesi

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
        // Rengi bir sonraki materyalle deðiþtir
        currentColorIndex = (currentColorIndex + 1) % guardMaterials.Length;
        ChangeColor();
    }

    public void ChangingPrevGuardColourButton()
    {
        SetActiveGuard();
        // Rengi bir önceki materyalle deðiþtir
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
