using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenus : MonoBehaviour
{
    public GameObject _weaponsPanel;

    public void OpenWeaponPanel()
    {
        _weaponsPanel.SetActive(true);
    }

    public void CloseWeaponPanel()
    {
        _weaponsPanel.SetActive(false);
    }
}
