using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingColorSwitcher : ColorSwitcher
{
    public ModelSwitch modelSwitch;
    public List<GameObject> wingListD0, wingListD1, wingListD2;
    private List<List<GameObject>> wingLists = new List<List<GameObject>>();

    void Start()
    {
        wingLists = new List<List<GameObject>>
{
            wingListD0,
            wingListD1,
            wingListD2
};
        modelSwitch = GameObject.Find("ModelManager").GetComponent<ModelSwitch>();
       
    }

    private void Update()
    {

        activeDroneIndex = modelSwitch.currentDroneIndex;

    }
    // Drone materyallerini deðiþtirecek olan düðme için çaðýrýlacak metot
    public override void ChangeMaterial()
    {
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
        SetActiveMaterial(currentMaterialIndex);

    }

    // Aktif dronenun materyalini deðiþtirecek olan metot
    public override void SetActiveMaterial(int materialIndex)
    {
        List<GameObject> wing = wingLists[activeDroneIndex];
        if (activeDroneIndex >= 0 && activeDroneIndex <= wing.Count)
        {

            for (int i = 0; i < wing.Count; i++)
            {
                Renderer renderer = wing[i].GetComponent<Renderer>();
                renderer.material = materials[materialIndex];
            }


        }
    }
}