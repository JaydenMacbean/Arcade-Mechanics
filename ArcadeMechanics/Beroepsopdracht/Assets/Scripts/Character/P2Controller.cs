using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace movement_Character2
{
    public class P2Controller : MonoBehaviour
    {
        public GameObject Hugo;

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
        public float SlapRange = 0.5f;
        public LayerMask P1Layer;
        Damage KillP1 = new Damage();

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

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                IsShmoovePressed = true;
                if (IsShmoovePressed == true)
                {
                    cAnim.SetBool("Is_Walking_Backward", true);
                    _rb2D.velocity = new Vector2(-characterSpeed, 0);
                }
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                IsShmoovePressed = true;
                if (IsShmoovePressed == true)
                {
                    cAnim.SetBool("Is_Walking_Forward", true);
                    _rb2D.velocity = new Vector2(characterSpeed, 0);
                }

            }

            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                IsShmoovePressed = false;
                _rb2D.velocity = new Vector2(0, 0);
                cAnim.SetTrigger("PlayerHugo_Idle");

            }

            else
            {
                IsShmoovePressed = false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------//









        // Attack Function


        public void SlapTime()
        {

            if (Input.GetKey(KeyCode.Numlock))
            {
                IsAttacking = true;
                cAnim.SetBool("Is_Attacking", true);
                KillP1.Takedamage(25);
                if (P2Damage.currentHealth == 0)
                {
                    KillP1.Death(0);
                }
            }

            if (Input.GetKeyUp(KeyCode.Numlock))
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
            Hugo = GameObject.Find("PlayerHugo");
            _rb2D = GetComponent<Rigidbody2D>();
            cAnim = gameObject.GetComponent<Animator>();


        }

        void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("Hugo's walking forward :D");
            }

            if(Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("Hugo's walking backwards :D");
            }

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (IsAttacking == false)
            {
                Shmoovement();
            }

            if (IsAttacking == true)
            {
                cAnim.SetBool("Is_Attacking", true);
                KillP1.Takedamage(25);
                if (Damage.currentHealth == 0)
                {
                    KillP1.Death(0);
                }
            }
        }
    }
}
