using UnityEngine;

public class SphereWrapper : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void CallNextRandomAnimation()
    {
        int randomIndex = Random.Range(1, 4);

        switch (randomIndex)
        {
            case 1:
                _animator.SetTrigger("Circle");
                break;
            case 2:
                _animator.SetTrigger("Jump");
                break;
            case 3:
                _animator.SetTrigger("Growth");
                break;
        }
    }
}
