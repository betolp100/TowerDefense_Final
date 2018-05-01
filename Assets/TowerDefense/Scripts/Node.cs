using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    private Color startColor;
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Renderer rend;
    public bool notEnoughMoneyForThatTorret = false;

    public Vector3 positionOffset;
    BuildManager buildManager;

    [Header("OPTIONAL")] public GameObject turret;

  

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;

    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    //public bool canSelect { get { return turretToBuild != null; } }

    void OnMouseDown()
    {
        //If we dont have a turret
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!buildManager.CanBuild) return;

        if (turret != null)
        {
            Debug.Log("Can't build there.");
            return;
        }
        //If we want to have a turret in the spot
        buildManager.BuildTurretOn(this);
    }
        void OnMouseEnter()
        {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

        void OnMouseExit()
        {
            rend.material.color = startColor;
        }

    }