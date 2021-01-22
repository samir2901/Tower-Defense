using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{    
    [SerializeField] private Color hoverColor;
    [SerializeField] private Vector3 positionOffset;
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
        nodeMat.color = hoverColor;        
    }

    private void OnMouseExit()
    {
        nodeMat.color = defaultColor;
    }
}
