using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace movement_Character2
{
    public class P1Controller : MonoBehaviour
    {

        public GameObject Yun;

        //Creating my movement variables

        bool Is_Walking_Backward;
        bool Is_Walking_Forward;
        public float characterSpeed = 10.0f;
        public bool IsShmoovePressed = false;
        protected Rigidbody2D _rb2D;
        protected Vector2 Shmoovin;
        public Animator cAnim;

        //Creating my attack variables

        public bool IsAttacking;
        public Transform AttackBox;
        public float KickRange = 0.5f;
        public LayerMask P2Layer;
        P2Damage KillP2 = new P2Damage();

        //-----------------------------------------------------------------------------------------------------------------//









        //Movement Function


        public void Shmoovement()
        {
            if (IsShmoovePressed == false)
            {
                cAnim.SetBool("Is_Walking_Backward", false);
                cAnim.SetBool("Is_Walking_Forward", false);
                _rb2D.velocity = new Vector2(0, 0);


            }

            if (Input.GetKey(KeyCode.A))
            {
                IsShmoovePressed = true;
                if (IsShmoovePressed == true)
                {
                    cAnim.SetBool("Is_Walking_Backward", true);
                    _rb2D.velocity = new Vector2(-characterSpeed, 0);
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                IsShmoovePressed = true;
                if (IsShmoovePressed == true)
                {
                    cAnim.SetBool("Is_Walking_Forward", true);
                    _rb2D.velocity = new Vector2(characterSpeed, 0);
                }

            }

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                IsShmoovePressed = false;
                _rb2D.velocity = new Vector2(0, 0);
                cAnim.SetTrigger("PlayerYun_Idle");

            }

            else
            {
                IsShmoovePressed = false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------//









        // Attack Function


        public void KickTime()
        {

            if(Input.GetKey(KeyCode.T))
            {
                IsAttacking = true;
                 
            }
             
            if (Input.GetKeyUp(KeyCode.T))
            {
                IsAttacking = false;
            }

            else
            {
                cAnim.SetBool("Is_Attacking", false);
            }
            
        }









        // Start is called before the first frame update
        void Start()
        {
            IsAttacking = false;
            Yun = GameObject.Find("PlayerYun");
            _rb2D = GetComponent<Rigidbody2D>();
            cAnim = gameObject.GetComponent<Animator>();

            
                
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("Yun's walking forward :D");
            }

            if(Input.GetKey(KeyCode.D))
            {
                Debug.Log("Yun's walking backwards :D");
            }


        }

        void FixedUpdate()
        {
            if (IsAttacking == false)
            {
                Shmoovement();
            }

            if (IsAttacking == true)
            {
                cAnim.SetBool("Is_Attacking", true);
                KillP2.Takedamage(25);
                if (P2Damage.currentHealth == 0)
                {
                    KillP2.Death(0);
                }
            }

            
             
        }
    }
    
}
 
