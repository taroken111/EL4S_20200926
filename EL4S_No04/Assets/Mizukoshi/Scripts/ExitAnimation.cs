using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizukoshi {
    public class ExitAnimation : MonoBehaviour
    {

        private Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            AnimatorStateInfo currentAnimatorState = animator.GetCurrentAnimatorStateInfo(0);
            if (currentAnimatorState.normalizedTime >= 1.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
