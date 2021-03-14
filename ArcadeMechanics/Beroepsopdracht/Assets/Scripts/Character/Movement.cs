using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace movement_Character
{
    public class Movement : MonoBehaviour
    {
     
        protected Rigidbody2D _rb2D;
        private string currentState;
        public float JumpForce = 1f;
        public float speed = 7.0f;
        Animator cAnim;

        //Animation States
        const string IdleYun = "PlayerYun_Idle";
        const string YunWalkF = "PlayerYun_WalkF";
        const string YunWalkB = "PlayerYun_WalkB";
        const string YunJump = "PlayerYun_Jump";

        // Start is called before the first frame update
        void Start()
        {
            _rb2D = GetComponent<Rigidbody2D>();
            cAnim = gameObject.GetComponent<Animator>();
            
        }

        void AnimationTransition(string newState)
        {
            if (currentState == newState) return;

            //Play the Animation
            cAnim.Play(newState);
            currentState = newState;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.A))
            {
                
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
                
                
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                AnimationTransition(YunWalkB);
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                AnimationTransition(IdleYun);
            }

            if (Input.GetKey(KeyCode.D))
            {
                
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
                

            }

        }
    }
}
 
