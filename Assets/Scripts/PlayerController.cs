using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            return instance;
        }
    }

    public Vector3 deathPosition;
    public int deathCount = 0;
    public GameManager gameManager;
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D holdingItemRigid;
    Rigidbody2D rigid;
    
    SpriteRenderer spriteRenderer;
    Animator anim;
    CapsuleCollider2D capsuleCollider;
    
    public QuickSlotController quickSlot;
    public Transform holdPos;
    public bool havingItem;

    private void Awake()
    {
        if (instance == null)
            instance = this; 

        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }

        //Stop Speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //Direction Sprite
        if(Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //Animation
        if(Mathf.Abs(rigid.velocity.x) < 0.3)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }

        // Portal Ctrl
        if (Input.GetKeyDown(KeyCode.UpArrow) && PortalManager.currentPortal != null)
        {
            if (DataManager.Instance.data.isUnlock[PortalManager.currentPortal.portalCode] == true)
            {
                UIController.Instance.Fade("settingMap");
            }

            else
            {
                Debug.Log("스테이지 진입 불가");
            }
            //UIController.Instance.Fade("settingMap");
        }

    }

    private void FixedUpdate()
    {
        //Move Speed
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Max Speed
        if(rigid.velocity.x > maxSpeed) //Right Max Speed
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed*(-1)) //Left Max Speed
        {
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);
        }

        //Landing Platform
        if(rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform", "Item"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 3f)
                {
                    anim.SetBool("isJumping", false);
                }

            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            OnDie();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Portal")
        {
            Debug.Log("포탈 부딪힘");
        }
        else if(collision.gameObject.tag == "Finish")
        {
            //Next Stage
            if (quickSlot.SearchItem(0) == true)
            {
                gameManager.ClearStage();
                Debug.Log("Stage Clear");
            }
            else
            {
                Debug.Log("클리어 실패!");
                UIController.Instance.NoticeRequried();
            }

        }

        else if(collision.gameObject.tag == "Item")
        {
            Debug.Log("Item 획득");
        }
    }

    public void OnDie()
    {
        if (GameManager.isLobby == true)
        {
            deathPosition = this.transform.position;
        }

        quickSlot.RemoveSelected();
        quickSlot.OffSelectedImage();
        //Sprite Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        //Sprite Flip Y
        spriteRenderer.flipY = true;
        //Collider Disable
        capsuleCollider.enabled = false;
        //Die Effect Jump
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        UIController.Instance.Fade("dead"); //Fade 코루틴 호출

        quickSlot.RemoveAllItem();

        DataManager.Instance.data.deathCount++;
        DataManager.Instance.SaveGameData();

        this.enabled = false; //플레이어가 사망 시 키입력으로 움직일 수 없게 함
        Debug.Log("죽었습니다!");

        //되돌리기 테스트
        //Stage1ObController.Instance.GoBackOriginalPosition();

    }

    public void PlayerReplaced()
    {
        this.enabled = true;
        //holdingItem.SetActive(true);
        spriteRenderer.flipY = false;
        capsuleCollider.enabled = true;
        spriteRenderer.color = new Color(1, 1, 1, 1);
        //this.transform.position = Vector3.zero;
        GameManager.Instance.DiePlayerReplace();
    }

    public void VelocityZero()
    {
        rigid.velocity = Vector2.zero;
    }
}
