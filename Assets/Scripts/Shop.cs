using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GunBlueprint[] _guns; 
    
    private BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.instance;
    }


    public void PurchaseTurret()
    {
        _buildManager.SelectGunToBuild(_guns[0]);
    }
    
    public void PurchaseArtillery()
    {
        _buildManager.SelectGunToBuild(_guns[1]);
    }
    
    public void PurchaseLaser()
    {
        _buildManager.SelectGunToBuild(_guns[2]);
    }
}
