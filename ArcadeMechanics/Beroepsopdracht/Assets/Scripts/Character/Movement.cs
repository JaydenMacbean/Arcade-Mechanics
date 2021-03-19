using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace movement_Character
{
    public class Movement : MonoBehaviour
    {
     
        protected Rigidbody2D _rb2D;
        public float JumpForce = 1f;
        public bool IsShmoovePressed = false;
        public float speed = 7.0f;
        Animator cAnim;

       

        // Start is called before the first frame update
        void Start()
        {
            _rb2D = GetComponent<Rigidbody2D>();
            cAnim = gameObject.GetComponent<Animator>();
            
        }


        void Update()
        {
             
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            if (IsShmoovePressed == false)
            {
                cAnim.SetBool("Is_Walking_Backward", false);
                cAnim.SetBool("Is_Walking_Forward", false);
                 


            }

            if (Input.GetKey(KeyCode.A))
            {
                IsShmoovePressed = true;
                if (IsShmoovePressed == true)
                {
                    cAnim.SetBool("Is_Walking_Backward", true);
                    transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
                }
                
            } 

            if (Input.GetKey(KeyCode.D))
            {
                IsShmoovePressed = true;
                if (IsShmoovePressed == true)
                {
                    cAnim.SetBool("Is_Walking_Forward", true);
                    transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
                }
                 
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                IsShmoovePressed = false;
                cAnim.SetBool("Is_Walking_Forward", false);
            }

            else
            {
                IsShmoovePressed = false;
                cAnim.SetBool("Is_Walking_Forward", false);
            }

        }
    }
}
 
