using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ModelChanger : MonoBehaviour
{
    public GameObject[] droneModels; // Drone modellerini tutan dizi

    private int currentModelIndex = 0; // �u anki modelin indeksi

    private GameObject currentModel; // �u anki model nesnesi

    public UnityEvent<GameObject> OnModelChange; // Model de�i�ti�inde tetiklenecek olay

    public WingChanger wingChanger;

    void Start()
    {
        //wingChanger.RemoveObjectWithTag();
        // �lk modeli ayarla
        currentModel = Instantiate(droneModels[currentModelIndex], transform.position, Quaternion.identity);
        currentModel.transform.localScale = new Vector3(7f, 7f, 7f);
        OnModelChange.Invoke(currentModel); // Model de�i�ikli�i olay�n� tetikle
        ModelInstantiater();

    }

    void Update()
    {
        ModelInstantiaterWithInput();
    }

    public void ModelInstantiaterWithInput()
    {
        // X tu�una bas�ld���nda model de�i�imini tetikle
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Yeni bir modeli olu�turmadan �nce mevcut modeli yok et
            Destroy(currentModel);

            // Bir sonraki modelin indeksini ayarla
            currentModelIndex++;
            if (currentModelIndex >= droneModels.Length)
                currentModelIndex = 0;

            // Yeni modeli olu�tur
            currentModel = Instantiate(droneModels[currentModelIndex], transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
            currentModel.transform.localScale = new Vector3(7f, 7f, 7f);
            OnModelChange.Invoke(currentModel); // Model de�i�ikli�i olay�n� tetikle


        }
    }

    public void ModelInstantiater()
    {
        Destroy(currentModel);

        // Bir sonraki modelin indeksini ayarla
        currentModelIndex++;
        if (currentModelIndex >= droneModels.Length)
            currentModelIndex = 0;

        // Yeni modeli olu�tur
        currentModel = Instantiate(droneModels[currentModelIndex], transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
        currentModel.transform.localScale = new Vector3(7f, 7f, 7f);
        OnModelChange.Invoke(currentModel); // Model de�i�ikli�i olay�n� tetikle


    }

    public GameObject GetCurrentModel()
    {
        return currentModel;
    }

    public void RemoveObjectWithTag()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Gears");

        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }

}