using GunSpace;
using UnityEngine;

public class Turret : Gun
{
    [Header("Turret Setup")] 
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] protected GameObject _bulletPrefab;
    
    private float _fireCountdown = 0;

    public override void Update()
    {
        if (_target == null)
            return;

        base.Update();
        
        if (_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1 / _fireRate;
        }

        _fireCountdown -= Time.deltaTime;
    }

    protected override void Shoot()
    {
        //Debug.Log("SHOOT");
        for (int i = 0; i < base._firePoints.Length; i++)
        {
            var bulletGO = Instantiate(_bulletPrefab, _firePoints[i].position, _firePoints[i].rotation);
            
            var bullet = bulletGO.GetComponent<Bullet>();

            bullet?.Seek(_target);
        }
    }
}
