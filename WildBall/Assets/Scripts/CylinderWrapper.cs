using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderWrapper : MonoBehaviour
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
                _animator.SetTrigger("Rotation");
                break;
            case 2:
                _animator.SetTrigger("Jump");
                break;
            case 3:
                _animator.SetTrigger("Wall");
                break;
        }
    }
}
