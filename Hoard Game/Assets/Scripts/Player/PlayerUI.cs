using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _promptText;
    [SerializeField] private TextMeshProUGUI _pistolAmmo;
    [SerializeField] private TextMeshProUGUI _SMGAmmo;
    [SerializeField] private TextMeshProUGUI _rifleAmmo;

    public void UpdatePromptText(string promptMessage)
    {
        _promptText.text = promptMessage;
    }

    public void UpdatePistolAmmo(int value)
    {
        _pistolAmmo.text = value.ToString();
    }

    public void UpdateSMGAmmo(int value) 
    {
        _SMGAmmo.text = value.ToString();
    }

    public void UpdateRifleAmmo(int value) 
    { 
        _rifleAmmo.text = value.ToString();
    }
}
