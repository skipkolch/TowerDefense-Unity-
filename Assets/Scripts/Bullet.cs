using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float _speed = 70f;
    [SerializeField] private GameObject _impactEffect;
    [SerializeField] private int _damage;
      
    
    protected Transform _target;
    private float _distanceThisFrame;
    private Vector3 _direction;

    private GameObject _currentEffect;
    [SerializeField] private float _explosionRadius;

    public void Seek(Transform target)
    {
        _target = target;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_target == null)
            Destroy(gameObject);
        else     
            PursuesTarget();

    }

    protected virtual void PursuesTarget()
    {                   
        _direction = _target.position - transform.position;
        _distanceThisFrame = _speed * Time.deltaTime;
                    
        if (_direction.magnitude <= _distanceThisFrame)
        {
            HitTarget();
            return;
        }
        
        transform.Translate(_direction.normalized * _distanceThisFrame, Space.World);
    }
    
    protected void HitTarget()
    {
        //Debug.Log("HIT TARGET!");

        InstanceEffect();

        if (_explosionRadius > 0f)
        {
            Explode();
        }
        else Damage(_target);
        
        Destroy(gameObject);
        
    }

    private void Explode()
    {
        var colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach (var collider in colliders)
        {
            if(collider.CompareTag("Enemy"))
                Damage(collider.transform);
        }
    }
    
    private void Damage(Transform enemyGo)
    {
        var emeny = enemyGo.GetComponent<Enemy>();
        
        emeny?.TakeDamage(_damage);
    }


    protected void InstanceEffect()
    {
        _currentEffect = Instantiate(_impactEffect, transform.position, transform.rotation);
        Destroy(_currentEffect, 2f);
    }

}

