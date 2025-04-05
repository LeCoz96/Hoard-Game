using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponManagerPanelManager : MonoBehaviour
{
    [Header("Weapon SO")]
    [SerializeField] private SO_Weapon _pistol;
    [SerializeField] private SO_Weapon _SMG;
    [SerializeField] private SO_Weapon _rifle;
    [SerializeField] private SO_Weapon _shotgun;
    [SerializeField] private SO_Weapon _rgp;

    [Header("Weapon UI")]
    [SerializeField] private TextMeshProUGUI _pistolAmmo;
    [SerializeField] private TextMeshProUGUI _SMGAmmo;
    [SerializeField] private TextMeshProUGUI _rifleAmmo;
    [SerializeField] private TextMeshProUGUI _shotgunAmmo;
    [SerializeField] private TextMeshProUGUI _rpgAmmo;

    void Update()
    {
        UpdatePanelPistolAmmo(_pistol.GetTotalAmmo());
        UpdatePanelSMGAmmo(_SMG.GetTotalAmmo());
        UpdatePanelRifleAmmo(_rifle.GetTotalAmmo());
        UpdatePanelShotgunAmmo(_shotgun.GetTotalAmmo());
        UpdatePanelRPGAmmo(_rgp.GetTotalAmmo());
    }

    private void UpdatePanelPistolAmmo(int value) { _pistolAmmo.text = value.ToString(); }
    private void UpdatePanelSMGAmmo(int value) { _SMGAmmo.text = value.ToString(); }
    private void UpdatePanelRifleAmmo(int value) { _rifleAmmo.text = value.ToString(); }
    private void UpdatePanelShotgunAmmo(int value) { _shotgunAmmo.text = value.ToString(); }
    private void UpdatePanelRPGAmmo(int value) { _rpgAmmo.text = value.ToString(); }
}
