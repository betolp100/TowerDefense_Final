using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBluePrint Turret_01;
    public TurretBluePrint Turret_02;
    public TurretBluePrint Turret_03;

    BuildManager buildManager;

    void Start()
        {
            buildManager = BuildManager.instance;
            
        }

    public void SelectTurret_01()
        {
            buildManager.SelectTurretToBuild(Turret_01);
        }

    public void SelectTurret_02()
        {
            buildManager.SelectTurretToBuild(Turret_02);
        }

    public void SelectTurret_03()
        {
            buildManager.SelectTurretToBuild(Turret_03);
        }
}
