using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateWrapper : MonoBehaviour
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
                _animator.SetTrigger("Sides");
                break;
            case 2:
                _animator.SetTrigger("Mess");
                break;
            case 3:
                _animator.SetTrigger("Botton");
                break;
        }
    }
}
