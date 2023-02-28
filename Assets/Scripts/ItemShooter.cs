using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemShooter : MonoBehaviour
{
    public Rigidbody2D item;

    public GameObject powerSlider;
    public Slider p_slider;

    private float minForce = 0f;
    private float maxForce = 10f;
    private float chargingTime = 5f;

    private float currentForce;
    private float chargeSpeed;
    //private bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        p_slider = powerSlider.GetComponent<Slider>();
        chargeSpeed = (maxForce - minForce) / chargingTime;
        //p_slider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.Instance.havingItem == true)
        {
            TryThrowItem();
        }
    }

    private void OnEnable()
    {
        currentForce = minForce;
        p_slider.value = minForce;
        //shoot = false;
    }

    public void TryThrowItem()
    {
        p_slider.value = minForce;

        if(currentForce >= maxForce)
        {
            currentForce = maxForce;
            Throw();
        }
        else if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            powerSlider.SetActive(true);
            p_slider.enabled = true;
            currentForce = minForce;
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            //powerSlider.SetActive(true);
            //p_slider.enabled = true;
            currentForce = currentForce + chargingTime * Time.deltaTime;
            p_slider.value = currentForce;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Throw();
            
        }
    }

    public void Throw()
    {
        currentForce = minForce;
        p_slider.enabled = false;
        powerSlider.SetActive(false);
    }
}
