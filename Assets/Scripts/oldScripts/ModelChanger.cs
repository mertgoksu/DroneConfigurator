using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ModelChanger : MonoBehaviour
{
    public GameObject[] droneModels; // Drone modellerini tutan dizi

    private int currentModelIndex = 0; // Þu anki modelin indeksi

    private GameObject currentModel; // Þu anki model nesnesi

    public UnityEvent<GameObject> OnModelChange; // Model deðiþtiðinde tetiklenecek olay

    public WingChanger wingChanger;

    void Start()
    {
        //wingChanger.RemoveObjectWithTag();
        // Ýlk modeli ayarla
        currentModel = Instantiate(droneModels[currentModelIndex], transform.position, Quaternion.identity);
        currentModel.transform.localScale = new Vector3(7f, 7f, 7f);
        OnModelChange.Invoke(currentModel); // Model deðiþikliði olayýný tetikle
        ModelInstantiater();

    }

    void Update()
    {
        ModelInstantiaterWithInput();
    }

    public void ModelInstantiaterWithInput()
    {
        // X tuþuna basýldýðýnda model deðiþimini tetikle
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Yeni bir modeli oluþturmadan önce mevcut modeli yok et
            Destroy(currentModel);

            // Bir sonraki modelin indeksini ayarla
            currentModelIndex++;
            if (currentModelIndex >= droneModels.Length)
                currentModelIndex = 0;

            // Yeni modeli oluþtur
            currentModel = Instantiate(droneModels[currentModelIndex], transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
            currentModel.transform.localScale = new Vector3(7f, 7f, 7f);
            OnModelChange.Invoke(currentModel); // Model deðiþikliði olayýný tetikle


        }
    }

    public void ModelInstantiater()
    {
        Destroy(currentModel);

        // Bir sonraki modelin indeksini ayarla
        currentModelIndex++;
        if (currentModelIndex >= droneModels.Length)
            currentModelIndex = 0;

        // Yeni modeli oluþtur
        currentModel = Instantiate(droneModels[currentModelIndex], transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
        currentModel.transform.localScale = new Vector3(7f, 7f, 7f);
        OnModelChange.Invoke(currentModel); // Model deðiþikliði olayýný tetikle


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