using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace movement_Character
{
    public class Movement : MonoBehaviour
    {
        bool Is_Walking_Backward;
        bool Is_Walking_Forward;
        bool Is_Jumping;
        protected Rigidbody2D _rb2D;
        public float JumpForce = 1f;
        public float speed = 7.0f;
        Animator cAnim;
        // Start is called before the first frame update
        void Start()
        {
            _rb2D = GetComponent<Rigidbody2D>();
            cAnim = gameObject.GetComponent<Animator>();
            Is_Walking_Backward = false;
            Is_Walking_Forward = false;
            Is_Jumping = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                Is_Walking_Backward = true;
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
                if(Is_Walking_Backward == true)
                {
                    cAnim.SetBool("Is_Walking_Backward", true);
                }
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                Is_Walking_Backward = false;
                cAnim.SetBool("Is_Walking_Backward", false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                Is_Walking_Forward = true;
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
                if(Is_Walking_Forward == true)
                {
                    cAnim.SetBool("Is_Walking_Forward", true);
                }
            }

            if(Input.GetKeyUp(KeyCode.D))
            {
                Is_Walking_Forward = false;
                cAnim.SetBool("Is_Walking_Forward", false);
            }

            if (Input.GetKeyDown(KeyCode.I) && Mathf.Abs(_rb2D.velocity.y) < 0.001f)
            {
                Is_Jumping = true;
                _rb2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                if(Is_Jumping == true)
                {
                    cAnim.SetBool("Is_Jumping", true);
                }
            }

            if (Input.GetKeyUp(KeyCode.I))
            {
                Is_Jumping = false;
                cAnim.SetBool("Is_Jumping", false);
            }
        }
    }
}
 
