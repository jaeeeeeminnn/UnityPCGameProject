using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemShooter : MonoBehaviour
{
    public QuickSlotController quickSlot;

    //public GameObject holdingItem;
    //public Item itemInfo;
    //public Transform holdingItemPos;
    //public Transform stageItem;

    public ItemObject throwItem;
    public Rigidbody2D throwItemRigid;
    
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
        throwItem = quickSlot.selectedItem;
        throwItemRigid = throwItem.GetComponent<Rigidbody2D>();
        //itemInfo.trigger.isTrigger = false;

        InitThrow();

        p_slider.enabled = false;
        powerSlider.SetActive(false);

        SettingThrowItem();

        throwItemRigid.velocity = currentForce * new Vector2(1, 1);
        throwItemRigid.AddForce(throwItemRigid.velocity);

        currentForce = minForce;

        throwItem.transform.SetParent(GameManager.Instance.Stages[GameManager.Instance.stageIndex].transform);
    }

    public void SettingThrowItem()
    {
        throwItem.gameObject.AddComponent<SensePlatform>();

        throwItemRigid.bodyType = RigidbodyType2D.Dynamic;

        if (SensePlatform.itemState)
        {
            throwItem.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            
        }

    }

    public void InitThrow()
    {
        PlayerController.Instance.havingItem = false;
        quickSlot.RemoveItem();
        quickSlot.OffSelectedImage();
        //quickSlot.RemoveSelected();
    }
}
