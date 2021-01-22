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
        Debug.Log("Standard Turret Selected");
        buildManager.setTurretToBuild(standardTurret);
    }

    public void GetPanelTurret()
    {
        Debug.Log("Panel Turret Selected");
        buildManager.setTurretToBuild(turretWithPanel);
    }

    public void GetMissleTurret()
    {
        Debug.Log("Panel Turret Selected");
        buildManager.setTurretToBuild(missileLauncher);
    }
}
