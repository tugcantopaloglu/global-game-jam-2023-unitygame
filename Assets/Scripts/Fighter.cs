using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    //Public fields
    public int hitpoint = 10;
    public int maxHitpoint = 19;
    public float pushRecoverySpeed = 0.2f;

    //Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //Push
    protected Vector3 pushDirection;

    //Particle Effect
    [SerializeField] GameObject bloodFx;

    //All fighters can ReceiveDamage / Die
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {

            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 20, Color.red, transform.position, Vector3.zero, 0.6f);
            if (hitpoint <= 0)
            {
                Bleed();
                hitpoint = 0;
                Death();
            }
        }
    }

    private void Bleed()
    {
        GameObject blood = Instantiate(bloodFx, transform.position, Quaternion.identity);
        blood.GetComponent<ParticleSystem>().Play();
    }

    protected virtual void Death() { }
}
