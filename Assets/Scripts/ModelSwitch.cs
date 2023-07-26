using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelSwitch : MonoBehaviour
{
    public List<GameObject> drones = new List<GameObject>(); // Farkl� drone'lar� tutan liste
    private int currentDroneIndex = 0; // �u anki drone'un indeksi

    public List<GameObject> drone2PropButtonsList = new List<GameObject>(); // drone2PropButtons GameObject'lerini tutan liste


    void Start()
    {
        SwitchToDrone(currentDroneIndex); // Ba�lang��ta ilk droneu aktif hale getir
    }

    void Update()
    {
        
    }

    // Butonlara ba�lanacak fonksiyonlar
    public void NextDrone()
    {
        currentDroneIndex++; // Bir sonraki drone'a ge�mek i�in indeksi art�r
        if (currentDroneIndex >= drones.Count)
            currentDroneIndex = 0; // E�er son dronea gelindiyse ilk dronea d�n

        SwitchToDrone(currentDroneIndex);
    }

    public void PreviousDrone()
    {
        currentDroneIndex--; // Bir �nceki drone'a ge�mek i�in indeksi azalt
        if (currentDroneIndex < 0)
            currentDroneIndex = drones.Count - 1; // E�er ilk drone'da geriye gidilmeye �al���l�rsa son drone'a ge�

        SwitchToDrone(currentDroneIndex);
    }

    public void SwitchToDrone(int index)
    {
        if (index >= 0 && index < drones.Count)
        {
            DeactivateCurrentDroneComponents(); // �u anki drone'un components'lar�n� deaktif hale getir

            // T�m drone'lar� deaktif hale getir
            foreach (GameObject drone in drones)
            {
                drone.SetActive(false);
            }

            // Yeni drone'u aktif hale getir
            drones[index].SetActive(true);
            ActivateCurrentDroneComponents();
        }
    }

    void ActivateCurrentDroneComponents()
    {
        // �u anki drone'u aktif hale getir ve gerekli scriptleri etkinle�tir
        PropellerSwitcher propellerSwitcher = drones[currentDroneIndex].GetComponent<PropellerSwitcher>();
        if (propellerSwitcher)
            propellerSwitcher.enabled = true;

    }

    void DeactivateCurrentDroneComponents()
    {
        // �u anki drone'u deaktif hale getir ve gerekli scriptleri devre d��� b�rak
        PropellerSwitcher propellerSwitcher = drones[currentDroneIndex].GetComponent<PropellerSwitcher>();
        if (propellerSwitcher)
            propellerSwitcher.enabled = false;

        // Di�er scriptleri de buraya ekleyebilirsiniz
    }
}
