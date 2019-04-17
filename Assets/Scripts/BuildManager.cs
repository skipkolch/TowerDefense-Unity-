using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
   [HideInInspector] public static BuildManager instance;

   private GunBlueprint _gunToBuild;

   public GunBlueprint GetGunToBuild => _gunToBuild;

   private void Awake()
   {
       instance = this;
   }

    public void SelectGunToBuild(GunBlueprint gun)
    {
        _gunToBuild = gun;
    }


    public void DestroyBuild(GameObject _gun)
    {
        PlayerStats.Money += (_gunToBuild.cost / 2);
        Destroy(_gun);
    }
    
    public void BuildGunOn(Node node)
    {
        if (PlayerStats.Money < _gunToBuild.cost)
        {
            Debug.LogWarning("Not enough money!");
            return;
        }

        PlayerStats.Money -= _gunToBuild.cost;
        var turret = Instantiate(_gunToBuild.prefab, node.GetBuildPosition(), Quaternion.Euler(0,-90,0));
        node._gun = turret;
        
        
        Debug.LogWarning("Gun build!. Money : " + PlayerStats.Money);
    }
    
    public bool CanBuild { get { return _gunToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= _gunToBuild.cost; } }
}
