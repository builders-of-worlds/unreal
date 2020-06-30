using UnityEngine;

public class Bulet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float amount = 10f;

    public void Seek(Transform _target)
    {
        this.target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Damage(target);
        Destroy(gameObject);
    }

    private void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
            e.TakeDamage(amount);
    }
}