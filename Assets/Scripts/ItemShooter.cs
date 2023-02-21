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

    private void OnEnable()
    {
        currentForce = minForce;
        p_slider.value = minForce;
    }

    public void TryThrowItem()
    {
        p_slider.value = minForce;

        if(currentForce >= maxForce)
        {
            currentForce = maxForce;
        }
        else if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            currentForce = minForce;
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            powerSlider.SetActive(true);
            currentForce = currentForce + chargingTime * Time.deltaTime;
            Debug.Log(currentForce);
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
        powerSlider.SetActive(false);
    }
}
