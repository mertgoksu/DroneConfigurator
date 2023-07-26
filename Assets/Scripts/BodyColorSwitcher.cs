using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColorSwitcher : MonoBehaviour
{
    public Material[] bodyMaterials; // Rengi deðiþtirilecek materyallerin listesi

    private int currentMaterialIndex = 0; // Þu anki materyalin indeksi

    void Start()
    {
        // Eðer materyal listesi boþsa, uyarý verelim ve script'i devre dýþý býrakalým
        if (bodyMaterials == null || bodyMaterials.Length == 0)
        {
            Debug.LogWarning("BodyColorSwitcher: Empty Material List!");
            enabled = false;
            return;
        }

        // Ýlk materyali uygulayalým
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
        // Bir sonraki materyali seçelim ve uygulayalým
        currentMaterialIndex++;
        if (currentMaterialIndex >= bodyMaterials.Length)
        {
            currentMaterialIndex = 0;
        }
        ApplyCurrentMaterial();
    }

    void PreviousMaterial()
    {
        // Bir önceki materyali seçelim ve uygulayalým
        currentMaterialIndex--;
        if (currentMaterialIndex < 0)
        {
            currentMaterialIndex = bodyMaterials.Length - 1;
        }
        ApplyCurrentMaterial();
    }

    public void ApplyCurrentMaterial()
    {
        // Þu anki materyali seçili olan child'a uygulayalým
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
