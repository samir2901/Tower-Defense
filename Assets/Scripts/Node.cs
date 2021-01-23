using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{    
    [SerializeField] private Color hoverColor;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private GameObject turretPlacingParticleFX;
    [HideInInspector]
    public GameObject turret;
    private Material nodeMat;
    private Color defaultColor;
    private BuildManager buildManager;
    private void Start()
    {
        nodeMat = GetComponent<Renderer>().material;
        defaultColor = nodeMat.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.canBuild)
        {
            return;
        }        
        if (turret!=null)
        {
            Debug.Log("NO PLACE FOR A TURRET");
            return;
        }
        GameObject particleFX = Instantiate(turretPlacingParticleFX, transform.position + positionOffset, Quaternion.identity);
        Destroy(particleFX, 5);
        buildManager.buildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.canBuild)
        {
            return;
        }
        if (buildManager.hasMoney)
        {
            nodeMat.color = hoverColor;
        }
        else
        {
            nodeMat.color = Color.red;
        }
        
    }

    private void OnMouseExit()
    {
        nodeMat.color = defaultColor;
    }
}
