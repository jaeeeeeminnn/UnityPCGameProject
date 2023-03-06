using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemShooter : MonoBehaviour
{
    public GameObject holdingItem;
    public Transform holdingItemPos;
    
    public GameObject throwItem;
    public Rigidbody2D throwItemRigid;
    public Transform throwItemPos;
    
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
        if(PlayerController.Instance.havingItem == true)
        {
            TryThrowItem();
        }
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
        throwItem = Instantiate(holdingItem);

        PlayerController.Instance.havingItem = false;
        PlayerController.Instance.quickSlot.RemoveItem();
        PlayerController.Instance.holdingItem.SetActive(false);
        PlayerController.Instance.quickSlot.OffSelectedImage();
        PlayerController.Instance.quickSlot.RemoveSelected();

        //throwItemRigid.bodyType = RigidbodyType2D.Dynamic;


        //throwItemRigid = throwItem.GetComponent<Rigidbody2D>();
        //throwItemPos = throwItem.GetComponent<Transform>();
        //throwItem.transform.SetParent(null);

       

        //throwItemRigid.AddForce(throwItemRigid.velocity);

        currentForce = minForce;
        p_slider.enabled = false;
        powerSlider.SetActive(false);

        //throwItemRigid.velocity = currentForce * holdingItemPos.forward;

        
    }
}
