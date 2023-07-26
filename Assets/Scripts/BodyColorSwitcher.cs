using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColorSwitcher : MonoBehaviour
{
    public Material[] bodyMaterials; // Rengi de�i�tirilecek materyallerin listesi

    private int currentMaterialIndex = 0; // �u anki materyalin indeksi

    void Start()
    {
        // E�er materyal listesi bo�sa, uyar� verelim ve script'i devre d��� b�rakal�m
        if (bodyMaterials == null || bodyMaterials.Length == 0)
        {
            Debug.LogWarning("BodyColorSwitcher: Empty Material List!");
            enabled = false;
            return;
        }

        // �lk materyali uygulayal�m
        ApplyCurrentMaterial();
    }

    void Update()
    {

    }

    public void NextBodyColorButton()
    {
        NextMaterial();
    }
    
    public void PrevBodyColorButton()
    {
        PreviousMaterial();
    }

    void NextMaterial()
    {
        // Bir sonraki materyali se�elim ve uygulayal�m
        currentMaterialIndex++;
        if (currentMaterialIndex >= bodyMaterials.Length)
        {
            currentMaterialIndex = 0;
        }
        ApplyCurrentMaterial();
    }

    void PreviousMaterial()
    {
        // Bir �nceki materyali se�elim ve uygulayal�m
        currentMaterialIndex--;
        if (currentMaterialIndex < 0)
        {
            currentMaterialIndex = bodyMaterials.Length - 1;
        }
        ApplyCurrentMaterial();
    }

    public void ApplyCurrentMaterial()
    {
        // �u anki materyali se�ili olan child'a uygulayal�m
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        if (renderers.Length > 0 && currentMaterialIndex < bodyMaterials.Length)
        {
            Material newMaterial = bodyMaterials[currentMaterialIndex];
            foreach (Renderer renderer in renderers)
            {
                renderer.material = newMaterial;
            }
        }
    }
}
