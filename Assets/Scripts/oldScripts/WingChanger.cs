using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WingChanger : MonoBehaviour
{
    public GameObject[] wingObjects; // Wings prefablerinin listesi
    public GameObject[] guardObjects; // Guards prefablerinin listesi

    private int currentWingIndex = 0; // Þu anki Wing'in indeksi
    private int currentGuardIndex = 0; // Þu anki Guard'ýn indeksi

    private GameObject currentWing; // Þu anki Wing nesnesi
    private GameObject currentGuard; // Þu anki Guard nesnesi

    void Start()
    {
        ChangeWing();
        ChangeGuard();
    }

    void Update()
    {
        // K tuþuna basýldýðýnda Wing deðiþimini tetikle
        if (Input.GetKeyDown(KeyCode.K))
        {
            ChangeWing();
        }

        // L tuþuna basýldýðýnda Guard deðiþimini tetikle
        if (Input.GetKeyDown(KeyCode.L))
        {
            ChangeGuard();
        }
    }

    void ChangeWing()
    {
        // Eðer mevcut Wing varsa kapat
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
        // Eðer mevcut Guard varsa kapat
        if (currentGuard != null)
        {
            currentGuard.SetActive(false);
        }

        // Bir sonraki Guard'ýn indeksini ayarla
        currentGuardIndex++;
        if (currentGuardIndex >= guardObjects.Length)
            currentGuardIndex = 0;

        // Yeni Guard'ý aktif hale getir
        currentGuard = Instantiate(guardObjects[currentGuardIndex], transform.position, Quaternion.identity);
        currentGuard.transform.SetParent(transform);
        currentGuard.transform.localPosition = Vector3.zero;
        currentGuard.SetActive(true);
    }
}
