using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
    
{
  [SerializeField] public Animator _animator;
  [SerializeField] private TMP_Text _speed;
    public Slider _slider;
    
    public void SliderUpdate(Slider slider)
    {
        _animator.SetFloat("MovmentSpeed", slider.value);

        _speed.text = slider.value.ToString("0.0");
      

    }




    void Update()
    {
        
    }
}
