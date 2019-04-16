using UnityEngine;
using GunSpace;

public class Artillery : Turret
{
    [Range(10, 50)] 
    [SerializeField] private float _minRange = 20f;

    [SerializeField] private bool _draw = false;

    protected override void SelectTarget()
    {
        if(shortestDistance >= _minRange)
            _target = nearEnemy.transform;
    }

    protected override void OnDrawGizmosSelected()
    {
        if (_draw)
        {
            base.OnDrawGizmosSelected();

            Gizmos.color = new Color(0, 1, 0, 0.2f);
            Gizmos.DrawSphere(transform.position, _minRange);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _minRange);
        }

    }
}
