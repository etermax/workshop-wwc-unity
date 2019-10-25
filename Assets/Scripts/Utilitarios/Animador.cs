using UnityEngine;

namespace Utils
{
    public class Animador
    {
        private readonly Animator _animator;

        public Animador(Animator animator)
        {
            _animator = animator;
        }

        public void Saltar()
        {
            _animator.SetTrigger("jump");
        }

        public void Aturdir()
        {
            _animator.SetTrigger("stun");
        }
    }
}