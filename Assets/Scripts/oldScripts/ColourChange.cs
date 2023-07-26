using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColourChange : MonoBehaviour
{
    public Material[] colorMaterials; // Renk materyallerini tutan dizi

    private int currentColorIndex1 = 0; // Body'nin renk materyalinin indeksi
    private int currentColorIndex2 = 0; // Wings'in renk materyalinin indeksi
    private int currentColorIndex3 = 0; // Guard'�n renk materyalinin indeksi

    private GameObject currentModel; // �u anki model nesnesi

    void Start()
    {
        ModelChanger modelChanger = GetComponent<ModelChanger>(); // ModelChanger scriptini al
        modelChanger.OnModelChange.AddListener(UpdateModel); // Model de�i�ikli�i olay�na UpdateModel metodu ekle
        currentModel = modelChanger.GetCurrentModel(); // �u anki modeli al
        SetColorMaterialWithTag(currentModel, "Body", currentColorIndex1);
        SetColorMaterialWithTag(currentModel, "Wings", currentColorIndex2);
        SetColorMaterialWithTag(currentModel, "Guard", currentColorIndex3);
    }

    void UpdateModel(GameObject newModel)
    {
        currentModel = newModel; // Model de�i�ti�inde �u anki modeli g�ncelle
    }

    void Update()
    {
        // C tu�una bas�ld���nda renk de�i�imini tetikle (Body)
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentColorIndex1++;
            if (currentColorIndex1 >= colorMaterials.Length)
                currentColorIndex1 = 0;

            SetColorMaterialWithTag(currentModel, "Body", currentColorIndex1);
        }

        // V tu�una bas�ld���nda renk de�i�imini tetikle (Wings)
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentColorIndex2++;
            if (currentColorIndex2 >= colorMaterials.Length)
                currentColorIndex2 = 0;

            SetColorMaterialWithTag(currentModel, "Wings", currentColorIndex2);
        }

        // Space tu�una bas�ld���nda renk de�i�imini tetikle (Guard)
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
//    public GameObject[] wingObjects; // Kanatlar� tutan dizi

//    private int currentModelIndex = 0; // �u anki modelin indeksi
//    private int currentColorIndex1 = 0; // 1. child'�n renk materyalinin indeksi
//    private int currentColorIndex2 = 0; // 2. child'�n renk materyalinin indeksi
//    private int currentWingIndex = 0; // �u anki kanat�n indeksi

//    private GameObject currentModel; // �u anki model nesnesi
//    private GameObject currentWing; // �u anki kanat nesnesi

//    void Start()
//    {
//        // �lk modeli ve renk materyalini ayarla
//        currentModel = Instantiate(droneModels[currentModelIndex], transform.position, Quaternion.identity);
//        currentModel.transform.localScale = new Vector3(7f, 7f, 7f);
//        SetColorMaterial(currentModel, 0, currentColorIndex1);
//        SetColorMaterial(currentModel, 1, currentColorIndex2);

//        // �lk kanad� olu�tur ve pozisyonunu ayarla
//        currentWing = Instantiate(wingObjects[currentWingIndex], transform.position, Quaternion.identity);
//        currentWing.transform.parent = currentModel.transform;
//        currentWing.transform.localPosition = Vector3.zero;
//    }

//    void Update()
//    {
//        // Space tu�una bas�ld���nda renk de�i�imini tetikle (2. child)
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            currentColorIndex2++;
//            if (currentColorIndex2 >= colorMaterials.Length)
//                currentColorIndex2 = 0;

//            SetColorMaterial(currentModel, 1, currentColorIndex2);
//        }

//        // X tu�una bas�ld���nda model de�i�imini tetikle
//        if (Input.GetKeyDown(KeyCode.X))
//        {
//            // Yeni bir modeli olu�turmadan �nce mevcut modeli ve kanad� yok et
//            Destroy(currentModel);
//            Destroy(currentWing);

//            // Bir sonraki modelin indeksini ayarla
//            currentModelIndex++;
//            if (currentModelIndex >= droneModels.Length)
//                currentModelIndex = 0;

//            // Yeni modeli olu�tur ve renk materyalini ayarla (ilk child)
//            currentModel = Instantiate(droneModels[currentModelIndex], transform.position, Quaternion.identity);
//            currentModel.transform.localScale = new Vector3(7f, 7f, 7f);
//            SetColorMaterial(currentModel, 0, currentColorIndex1);
//            SetColorMaterial(currentModel, 1, currentColorIndex2);

//            // Yeni kanad� olu�tur ve pozisyonunu ayarla
//            currentWing = Instantiate(wingObjects[currentWingIndex], transform.position, Quaternion.identity);
//            currentWing.transform.parent = currentModel.transform;
//            currentWing.transform.localPosition = Vector3.zero;
//        }

//        // K tu�una bas�ld���nda kanat de�i�imini tetikle
//        if (Input.GetKeyDown(KeyCode.K))
//        {
//            // Yeni bir kanad� olu�turmadan �nce mevcut kanad� yok et
//            Destroy(currentWing);

//            // Bir sonraki kanad�n indeksini ayarla
//            currentWingIndex++;
//            if (currentWingIndex >= wingObjects.Length)
//                currentWingIndex = 0;

//            // Yeni kanad� olu�tur ve pozisyonunu ayarla
//            currentWing = Instantiate(wingObjects[currentWingIndex], transform.position, Quaternion.identity);
//            currentWing.transform.parent = currentModel.transform;
//            currentWing.transform.localPosition = Vector3.zero;
//        }

//        // C tu�una bas�ld���nda renk de�i�imini tetikle (1. child)
//        if (Input.GetKeyDown(KeyCode.C))
//        {
//            currentColorIndex1++;
//            if (currentColorIndex1 >= colorMaterials.Length)
//                currentColorIndex1 = 0;

//            SetColorMaterial(currentModel, 0, currentColorIndex1);
//        }
//    }

//    // Drone modelinin belirli bir child'�na renk materyalini uygula
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