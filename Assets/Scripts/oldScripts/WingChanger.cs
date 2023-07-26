using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WingChanger : MonoBehaviour
{
    public GameObject[] wingObjects; // Wings prefablerinin listesi
    public GameObject[] guardObjects; // Guards prefablerinin listesi

    private int currentWingIndex = 0; // �u anki Wing'in indeksi
    private int currentGuardIndex = 0; // �u anki Guard'�n indeksi

    private GameObject currentWing; // �u anki Wing nesnesi
    private GameObject currentGuard; // �u anki Guard nesnesi

    void Start()
    {
        ChangeWing();
        ChangeGuard();
    }

    void Update()
    {
        // K tu�una bas�ld���nda Wing de�i�imini tetikle
        if (Input.GetKeyDown(KeyCode.K))
        {
            ChangeWing();
        }

        // L tu�una bas�ld���nda Guard de�i�imini tetikle
        if (Input.GetKeyDown(KeyCode.L))
        {
            ChangeGuard();
        }
    }

    void ChangeWing()
    {
        // E�er mevcut Wing varsa kapat
        if (currentWing != null)
        {
            currentWing.SetActive(false);
        }

        // Bir sonraki Wing'in indeksini ayarla
        currentWingIndex++;
        if (currentWingIndex >= wingObjects.Length)
            currentWingIndex = 0;

        // Yeni Wing'i aktif hale getir
        currentWing = Instantiate(wingObjects[currentWingIndex], transform.position, Quaternion.identity);
        currentWing.transform.SetParent(transform);
        currentWing.transform.localPosition = Vector3.zero;
        currentWing.SetActive(true);
    }

    void ChangeGuard()
    {
        // E�er mevcut Guard varsa kapat
        if (currentGuard != null)
        {
            currentGuard.SetActive(false);
        }

        // Bir sonraki Guard'�n indeksini ayarla
        currentGuardIndex++;
        if (currentGuardIndex >= guardObjects.Length)
            currentGuardIndex = 0;

        // Yeni Guard'� aktif hale getir
        currentGuard = Instantiate(guardObjects[currentGuardIndex], transform.position, Quaternion.identity);
        currentGuard.transform.SetParent(transform);
        currentGuard.transform.localPosition = Vector3.zero;
        currentGuard.SetActive(true);
    }
}
