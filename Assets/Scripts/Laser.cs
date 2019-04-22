using System.Collections;
using System.Collections.Generic;
using GunSpace;
using UnityEngine;

public class Laser : Gun
{
   [Header("Laser Setup")] [SerializeField]
   private LineRenderer _lineRenderer;
   [SerializeField] private ParticleSystem _impactEffect;
   [SerializeField] private Light _impactLight;
   [SerializeField] private int damageOverTime = 30;
   [SerializeField] private float _slowPercent = .5f;

   
   public override void Update()
   {
      if (_target == null)
      {
         if (_lineRenderer.enabled)
         {
            _impactLight.enabled = false;
            _lineRenderer.enabled = false;
            _impactEffect.Stop();
         }          
         return;
      }

      base.Update();

      Shoot();
   }
   


   protected override void Shoot()
   {
      
      _enemy.TakeDamage(damageOverTime * Time.deltaTime);
      _enemy.Slow(_slowPercent);
      
      if (!_lineRenderer.enabled)
      {
         _impactLight.enabled = true;
         _lineRenderer.enabled = true;
         _impactEffect.Play();
      } 
      
      var position = _target.position;
      
      _lineRenderer.SetPosition(0, _firePoints[0].position);  
      _lineRenderer.SetPosition(1,position);

      var dir = _firePoints[0].position - position;

      _impactEffect.transform.position = position + dir.normalized;  
      _impactEffect.transform.rotation = Quaternion.LookRotation(dir);

      
   }
}
