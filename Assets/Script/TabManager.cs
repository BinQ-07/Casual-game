using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    public List<GameObject> tabContents; // Daftar semua ScrollView/tab content
    public List<Button> tabButtons;
    private int activeTabIndex = -1;           // Menyimpan index tab yang sedang aktif

    public GameObject LayoutScrollView;

    public void ShowTab(int index)
    {
        if(!LayoutScrollView.activeInHierarchy)
        {
            LayoutScrollView.SetActive(true);
        }
        for (int i = 0; i < tabContents.Count; i++)
        {
            bool isActive = i == index;
            tabContents[i].SetActive(isActive);
            tabButtons[i].interactable = !isActive; // atau ubah warna
        }

        activeTabIndex = index;
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LayoutScrollView.SetActive(false);
            //menyalakan toggle interact
            for (int i = 0; i < tabButtons.Count; i++)
            {
                bool isActive = true;
                tabButtons[i].interactable = isActive;
            }

            //menutup scroll panel
            // if (activeTabIndex != -1)
            // {
            //     // Ada tab yang sedang aktif → sembunyikan semua
            //     for (int i = 0; i < tabContents.Count; i++)
            //     {
            //         tabContents[i].SetActive(false);
            //         tabButtons[i].interactable = true;
            //     }
            //     activeTabIndex = -1; // Reset status
            // }


        }
    }

}
