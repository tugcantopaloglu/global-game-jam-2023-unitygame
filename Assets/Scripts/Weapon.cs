using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Weapon : Collidable
{
    //Damage struct
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    //Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    //Swing
    private float cooldown = 0f;
    private float lastSwing;

    //dotween
    private Sequence sequence;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    private void Swing()
    {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DORotate(new Vector3(0.07f, -0.05f, 10f), 0.4f, RotateMode.FastBeyond360).SetEase(Ease.Linear));
        

    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            if (coll.name == "Player")
            {
                return;
            }
            //Create a new damage object, then we'll send it to the fighter we've hit
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
