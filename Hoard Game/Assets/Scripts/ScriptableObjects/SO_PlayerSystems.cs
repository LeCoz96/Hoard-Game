using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SO_PlayerSystems
{   
    public static bool _isReloading = false;
    public static bool GetIsReloading() { return _isReloading; }
    public static void ToggleReloading() { _isReloading = !_isReloading; }
    public static void CancelReload() { _isReloading = false; }
}
