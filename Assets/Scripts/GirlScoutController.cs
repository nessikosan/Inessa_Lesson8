using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GirlScoutController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] public float _moveSpeed;
    [SerializeField] public Animator _animator;
    [SerializeField] private int _speedMulti = 2;
 

        void Update()
    {
      
        float horizontalInput = Input.GetAxis("Horizontal");// A and D
       float verticalInput =  Input.GetAxis("Vertical");// W and S
       

        Vector3 movment = new Vector3(horizontalInput, 0, verticalInput);
        movment.Normalize();

        transform.position = Vector3.MoveTowards(transform.position,transform.position + movment,Time.deltaTime* _moveSpeed);

        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(horizontalInput,0,verticalInput));

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);

        float calculatedSpeed = Mathf.Clamp(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput), 0, 1);

       
        
        if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetTrigger("Jump");
        }

       
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            calculatedSpeed *= _speedMulti;
            _moveSpeed = Mathf.Clamp(_moveSpeed, 2, _moveSpeed * _speedMulti);
        }
        
     
         _animator.SetFloat("MovmentSpeed", calculatedSpeed);

    }

      
}
