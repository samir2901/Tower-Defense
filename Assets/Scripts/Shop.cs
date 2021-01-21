using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    TurretBlueprint standardTurret;
    [SerializeField]
    TurretBlueprint turretWithPanel;
    [SerializeField]
    TurretBlueprint missileLauncher;

    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void GetStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.setTurretToBuild(standardTurret.turretPrefab);
    }

    public void GetPanelTurret()
    {
        Debug.Log("Panel Turret Purchased");
        buildManager.setTurretToBuild(turretWithPanel.turretPrefab);
    }

    public void GetMissleTurret()
    {
        Debug.Log("Panel Turret Purchased");
        buildManager.setTurretToBuild(missileLauncher.turretPrefab);
    }
}
