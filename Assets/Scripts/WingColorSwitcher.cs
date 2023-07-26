using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingColorSwitcher : MonoBehaviour
{
    public List<Material> wingMaterials = new List<Material>(); // Wing materyallerini tutacak liste

    private List<Transform> activeWings = new List<Transform>(); // Aktif olan Wings çocuklarýný tutacak liste
    private int currentWingMaterialIndex = 0; // Þu anki Wing materyalinin indeksi

    void Start()
    {
        //ChangeWingMaterial(currentWingMaterialIndex);
    }

    void FindActiveWing()
    {
        // "Drone" tag'ine sahip ana nesnenin altýndaki "Wings" tag'ine sahip aktif olan çocuklarý listeye ekleyelim
        foreach (Transform child in transform)
        {
            if ( (child.CompareTag("Wings")||child.CompareTag("BackWings")) && child.gameObject.activeSelf )
                activeWings.Add(child);
        }
    }

    public void ToNextWingMaterial()
    {
        FindActiveWing();
        currentWingMaterialIndex++;
        if (currentWingMaterialIndex >= wingMaterials.Count)
            currentWingMaterialIndex = 0;

        ChangeWingMaterial(currentWingMaterialIndex);
    }

    public void ToPreviousWingMaterial()
    {
        FindActiveWing();
        currentWingMaterialIndex--;
        if (currentWingMaterialIndex < 0)
            currentWingMaterialIndex = wingMaterials.Count - 1;

        ChangeWingMaterial(currentWingMaterialIndex);
    }

    void ChangeWingMaterial(int index)
    {
        if (index < 0 || index >= wingMaterials.Count)
            return;

        Material targetMaterial = wingMaterials[index];

        foreach (Transform wing in activeWings)
        {
            Renderer wingRenderer = wing.GetComponent<Renderer>();
            if (wingRenderer != null)
                wingRenderer.material = targetMaterial;
        }
    }
}