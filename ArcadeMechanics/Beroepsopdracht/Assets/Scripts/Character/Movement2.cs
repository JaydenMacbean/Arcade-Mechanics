using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace movement_Character2
{
    public class Movement2 : MonoBehaviour
    {
        bool Is_Walking_Backward;
        bool Is_Walking_Forward;
        public float characterSpeed = 10.0f;
        public bool IsShmoovePressed = false;
        protected Rigidbody2D _rb2D;
        protected Vector2 Shmoovin;
        public Animator cAnim;

        //Animation States
        const string IdleYun = "PlayerYun_Idle";

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

            }

            else
            {
                IsShmoovePressed = false;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
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
            Shmoovement();
        }
    }
    
}
 
