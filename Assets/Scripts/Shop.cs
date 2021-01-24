using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("Turret Blueprints")]
    [SerializeField]
    private TurretBlueprint standardTurret;
    [SerializeField]
    private TurretBlueprint turretWithPanel;
    [SerializeField]
    private TurretBlueprint missileLauncher;
    [SerializeField]
    private TurretBlueprint laserTurret;

    [Header("Shop Prices")]
    [SerializeField]
    private TextMeshProUGUI standardTurretCostText;
    [SerializeField]
    private TextMeshProUGUI panelTurretCostText;
    [SerializeField]
    private TextMeshProUGUI missileLauncherCostText;
    [SerializeField]
    private TextMeshProUGUI laserTurretCostText;

    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
        SetCost(standardTurretCostText, standardTurret);
        SetCost(panelTurretCostText, turretWithPanel);
        SetCost(missileLauncherCostText, missileLauncher);
        SetCost(laserTurretCostText, laserTurret);
    }
    public void GetStandardTurret()
    {
        //Debug.Log("Standard Turret Selected");
        buildManager.setTurretToBuild(standardTurret);
    }

    public void GetPanelTurret()
    {
        //Debug.Log("Panel Turret Selected");
        buildManager.setTurretToBuild(turretWithPanel);
    }

    public void GetMissleTurret()
    {
        //Debug.Log("Missle Turret Selected");
        buildManager.setTurretToBuild(missileLauncher);
    }

    public void GetLaserTurret()
    {
        //Debug.Log("Laser Turret Selected");
        buildManager.setTurretToBuild(laserTurret);
    }

    void SetCost(TextMeshProUGUI textMesh, TurretBlueprint turret)
    {
        textMesh.text = "$" + turret.cost.ToString();
    }
}
