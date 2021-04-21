using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using movement_Character2;

public class P2Attack : MonoBehaviour
{

    static public Transform AttackBox;
    static public float KickRange = 0.5f;
    static public LayerMask P1Layer;
    static Movement2 Shmoov = new Movement2();
    static P2Damage KillP1 = new P2Damage();



    // Start is called before the first frame update
    static void Start()
    {

    }

    // FixedUpdate is called every fixed framerate frame
    private static void FixedUpdate()
    {
        Shmoov.Shmoovement();

        Shmoov.cAnim.SetTrigger("PlayerYun_Attack");
        Collider2D[] Kickbox = Physics2D.OverlapCircleAll(AttackBox.position, KickRange, P1Layer);

        foreach (Collider2D P1 in Kickbox)
        {
            KillP1.Takedamage(25);
            if (P2Damage.currentHealth == 0)
            {
                KillP1.Death(0);
            }
        }

    }
}
