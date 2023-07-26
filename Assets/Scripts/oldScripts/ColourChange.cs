using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColourChange : MonoBehaviour
{
    public Material[] colorMaterials; // Renk materyallerini tutan dizi

    private int currentColorIndex1 = 0; // Body'nin renk materyalinin indeksi
    private int currentColorIndex2 = 0; // Wings'in renk materyalinin indeksi
    private int currentColorIndex3 = 0; // Guard'ýn renk materyalinin indeksi

    private GameObject currentModel; // Þu anki model nesnesi

    void Start()
    {
        ModelChanger modelChanger = GetComponent<ModelChanger>(); // ModelChanger scriptini al
        modelChanger.OnModelChange.AddListener(UpdateModel); // Model deðiþikliði olayýna UpdateModel metodu ekle
        currentModel = modelChanger.GetCurrentModel(); // Þu anki modeli al
        SetColorMaterialWithTag(currentModel, "Body", currentColorIndex1);
        SetColorMaterialWithTag(currentModel, "Wings", currentColorIndex2);
        SetColorMaterialWithTag(currentModel, "Guard", currentColorIndex3);
    }

    void UpdateModel(GameObject newModel)
    {
        currentModel = newModel; // Model deðiþtiðinde þu anki modeli güncelle
    }

    void Update()
    {
        // C tuþuna basýldýðýnda renk deðiþimini tetikle (Body)
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentColorIndex1++;
            if (currentColorIndex1 >= colorMaterials.Length)
                currentColorIndex1 = 0;

            SetColorMaterialWithTag(currentModel, "Body", currentColorIndex1);
        }

        // V tuþuna basýldýðýnda renk deðiþimini tetikle (Wings)
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentColorIndex2++;
            if (currentColorIndex2 >= colorMaterials.Length)
                currentColorIndex2 = 0;

            SetColorMaterialWithTag(currentModel, "Wings", currentColorIndex2);
        }

        // Space tuþuna basýldýðýnda renk deðiþimini tetikle (Guard)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentColorIndex3++;
            if (currentColorIndex3 >= colorMaterials.Length)
                currentColorIndex3 = 0;

            SetColorMaterialWithTag(currentModel, "Guards", currentColorIndex3);
        }
    }

    // Modelin belirli bir Tag'a sahip nesnelerin renk materyalini uygula
    void SetColorMaterialWithTag(GameObject model, string tag, int colorIndex)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null && colorIndex < colorMaterials.Length)
                renderer.material = colorMaterials[colorIndex];
        }
    }
}



//public class ColourChange : MonoBehaviour
//{
//    public GameObject[] droneModels; // Drone modellerini tutan dizi
//    public Material[] colorMaterials; // Renk materyallerini tutan dizi
//    public GameObject[] wingObjects; // Kanatlarý tutan dizi

//    private int currentModelIndex = 0; // Þu anki modelin indeksi
//    private int currentColorIndex1 = 0; // 1. child'ýn renk materyalinin indeksi
//    private int currentColorIndex2 = 0; // 2. child'ýn renk materyalinin indeksi
//    private int currentWingIndex = 0; // Þu anki kanatýn indeksi

//    private GameObject currentModel; // Þu anki model nesnesi
//    private GameObject currentWing; // Þu anki kanat nesnesi

//    void Start()
//    {
//        // Ýlk modeli ve renk materyalini ayarla
//        currentModel = Instantiate(droneModels[currentModelIndex], transform.position, Quaternion.identity);
//        currentModel.transform.localScale = new Vector3(7f, 7f, 7f);
//        SetColorMaterial(currentModel, 0, currentColorIndex1);
//        SetColorMaterial(currentModel, 1, currentColorIndex2);

//        // Ýlk kanadý oluþtur ve pozisyonunu ayarla
//        currentWing = Instantiate(wingObjects[currentWingIndex], transform.position, Quaternion.identity);
//        currentWing.transform.parent = currentModel.transform;
//        currentWing.transform.localPosition = Vector3.zero;
//    }

//    void Update()
//    {
//        // Space tuþuna basýldýðýnda renk deðiþimini tetikle (2. child)
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            currentColorIndex2++;
//            if (currentColorIndex2 >= colorMaterials.Length)
//                currentColorIndex2 = 0;

//            SetColorMaterial(currentModel, 1, currentColorIndex2);
//        }

//        // X tuþuna basýldýðýnda model deðiþimini tetikle
//        if (Input.GetKeyDown(KeyCode.X))
//        {
//            // Yeni bir modeli oluþturmadan önce mevcut modeli ve kanadý yok et
//            Destroy(currentModel);
//            Destroy(currentWing);

//            // Bir sonraki modelin indeksini ayarla
//            currentModelIndex++;
//            if (currentModelIndex >= droneModels.Length)
//                currentModelIndex = 0;

//            // Yeni modeli oluþtur ve renk materyalini ayarla (ilk child)
//            currentModel = Instantiate(droneModels[currentModelIndex], transform.position, Quaternion.identity);
//            currentModel.transform.localScale = new Vector3(7f, 7f, 7f);
//            SetColorMaterial(currentModel, 0, currentColorIndex1);
//            SetColorMaterial(currentModel, 1, currentColorIndex2);

//            // Yeni kanadý oluþtur ve pozisyonunu ayarla
//            currentWing = Instantiate(wingObjects[currentWingIndex], transform.position, Quaternion.identity);
//            currentWing.transform.parent = currentModel.transform;
//            currentWing.transform.localPosition = Vector3.zero;
//        }

//        // K tuþuna basýldýðýnda kanat deðiþimini tetikle
//        if (Input.GetKeyDown(KeyCode.K))
//        {
//            // Yeni bir kanadý oluþturmadan önce mevcut kanadý yok et
//            Destroy(currentWing);

//            // Bir sonraki kanadýn indeksini ayarla
//            currentWingIndex++;
//            if (currentWingIndex >= wingObjects.Length)
//                currentWingIndex = 0;

//            // Yeni kanadý oluþtur ve pozisyonunu ayarla
//            currentWing = Instantiate(wingObjects[currentWingIndex], transform.position, Quaternion.identity);
//            currentWing.transform.parent = currentModel.transform;
//            currentWing.transform.localPosition = Vector3.zero;
//        }

//        // C tuþuna basýldýðýnda renk deðiþimini tetikle (1. child)
//        if (Input.GetKeyDown(KeyCode.C))
//        {
//            currentColorIndex1++;
//            if (currentColorIndex1 >= colorMaterials.Length)
//                currentColorIndex1 = 0;

//            SetColorMaterial(currentModel, 0, currentColorIndex1);
//        }
//    }

//    // Drone modelinin belirli bir child'ýna renk materyalini uygula
//    void SetColorMaterial(GameObject model, int childIndex, int colorIndex)
//    {
//        if (childIndex >= 0 && childIndex < model.transform.childCount)
//        {
//            Transform child = model.transform.GetChild(childIndex);
//            Renderer renderer = child.GetComponent<Renderer>();
//            if (renderer != null && colorIndex < colorMaterials.Length)
//                renderer.material = colorMaterials[colorIndex];
//        }
//    }
//}