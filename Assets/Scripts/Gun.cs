using UnityEngine;
using UnityEngine.Serialization;

namespace GunSpace
{
    public abstract class Gun : MonoBehaviour
    {
        [FormerlySerializedAs("_range")]
        [Header("Gun Setup")]
        [Range(5, 50)] 
        [SerializeField] private float _maxRange = 15f;
        [SerializeField] private string _enemyTag = "Enemy";
        [SerializeField] private float _speedRotation;
        [SerializeField] protected Transform[] _firePoints;


        private GameObject[] enemies;
        protected float shortestDistance;
        protected GameObject nearEnemy;
        protected  Transform _target;
        protected Enemy _enemy;
       

        private void Start()
        {
            InvokeRepeating(nameof(SearchTarget), 0f, 0.5f);
        }

        private void SearchTarget()
        {
            enemies = GameManager.instance.GetEnemiesOnMap;
            
            if(enemies == null)
                return;
            
            shortestDistance = Mathf.Infinity;
            nearEnemy = null;

            foreach (var enemy in enemies)
            {
                if (enemy != null)
                {
                    var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                    
                    if (!(distanceToEnemy < shortestDistance)) continue;

                    shortestDistance = distanceToEnemy;
                    nearEnemy = enemy;
                }
                else continue;      
            }

            if (nearEnemy != null && shortestDistance <= _maxRange)
                SelectTarget();
            else _target = null;


        }

        protected virtual void SelectTarget()
        {
            _target = nearEnemy.transform;
            _enemy = nearEnemy.GetComponent<Enemy>();
        }

        
        public virtual void Update()
        {
            var dir = _target.position - transform.position;
            var lookRotation = Quaternion.LookRotation(dir);

            var rotation = Quaternion.Lerp(transform.rotation, lookRotation, _speedRotation * Time.deltaTime)
                .eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        protected virtual void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1, 0, 0, 0.2f);
            Gizmos.DrawSphere(transform.position, _maxRange);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _maxRange);
        }
        
        protected abstract void Shoot();
    }

}