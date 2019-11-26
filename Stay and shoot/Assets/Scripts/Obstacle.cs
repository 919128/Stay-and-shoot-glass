using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{

    public abstract void OnHitByBullet();
    
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            AddEffectOnBulletDeath(collision.gameObject.GetComponent<Bullet>());
            OnHitByBullet();
            
            Destroy(collision.gameObject);
          
        }
       
    }
    public virtual void AddEffectOnBulletDeath(Bullet bullet)
    {

    }
}
