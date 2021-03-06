using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public Vector3 positionOffset;    
    
    private void Awake()
    {        
        if (instance!=null)
        {
            Debug.LogError("More than one Build Manager in scene");
        }
        instance = this;
    }
    
    private TurretBlueprint turretToBuild;    
    
    public bool canBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }


    public bool hasMoney
    {
        get
        {
            return PlayerStats.money >= turretToBuild.cost;
        }
    }

    public void buildTurretOn(Node node)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("NOT ENOUGH MONEY");
            return;
        }        
        PlayerStats.money -= turretToBuild.cost;        
        //Debug.Log(turretToBuild.turretPrefab.name + " : " + PlayerStats.money);
        GameObject turret = Instantiate(turretToBuild.turretPrefab, node.transform.position + positionOffset, Quaternion.identity);
        node.turret = turret;
    }

    public void setTurretToBuild(TurretBlueprint turret)
    {        
        turretToBuild = turret;
    }

    
}
