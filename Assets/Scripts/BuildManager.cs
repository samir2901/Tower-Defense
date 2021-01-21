using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public int totalAmountPresent = 100;

    private void Awake()
    {
        Debug.Log("Amount Present" + totalAmountPresent);
        if (instance!=null)
        {
            Debug.LogError("More than one Build Manager in scene");
        }
        instance = this;
    }
    
    private GameObject turretToBuild;    
    public GameObject getTurretToBuild()
    {        
        return turretToBuild;
    }
    public void setTurretToBuild(GameObject turret)
    {        
        turretToBuild = turret;
    }

    
}
