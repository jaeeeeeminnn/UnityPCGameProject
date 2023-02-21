using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemShooter : MonoBehaviour
{
    public Rigidbody2D item;

    public GameObject powerSlider;
    public Slider p_slider;

    public float minForce = 10f;
    public float maxForce = 20f;
    public float chargingTime = 5f;

    private float currentForce;
    private float chargeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        p_slider = powerSlider.GetComponent<Slider>();
        chargeSpeed = (maxForce - minForce) / chargingTime;
    }

    // Update is called once per frame
    void Update()
    {
        TryThrowItem();
    }

    public void TryThrowItem()
    {
        p_slider.value = minForce;

        if(Input.GetKey(KeyCode.LeftControl))
        {
            powerSlider.SetActive(true);
            currentForce = currentForce + chargingTime * Time.deltaTime;
            p_slider.value = currentForce;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Throw();
            powerSlider.SetActive(false);
        }
    }

    public void Throw()
    {
        p_slider.value = minForce;
    }
}
