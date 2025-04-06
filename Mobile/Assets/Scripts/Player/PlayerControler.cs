using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : Singleton<PlayerControler>
{


    [SerializeField] private float initialMovementSpeed=4;
    [SerializeField] float dashSpeed;
    [SerializeField] float timeDash;
    [SerializeField] float dashCD;
    [SerializeField] TrailRenderer myTrailRenderer;
    [SerializeField] private Transform weaponCollider;
    [SerializeField] public DialogueManager dialogueManager;



    private bool FacingLeft{get {return facingLeft;}  }

    private PlayerControls playerControls;
    private Rigidbody2D rb;
    private Vector2 Movement;
    private float moveSpeed;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    private KnockBack knockBack;
    public bool facingLeft=false;
    private bool isDash;
    public IInteractable Interactable { get; set; }
    private IEnumerator freezeRoutine;
    protected override void Awake() {
        base.Awake();
        playerControls=new PlayerControls();
        rb=GetComponent<Rigidbody2D>();
        myAnimator=GetComponent<Animator>();
        mySpriteRenderer=GetComponent<SpriteRenderer>();
        knockBack=GetComponent<KnockBack>();
        
        
    }
    
    private void Start() {
        NormalState();
        UI.Instance.playerControler=this;
        playerControls.Combat.Dash.performed+=_=>Dash();
        ActiveInventory.Instance.EquipStartWeapon();
        GetDialogueManager(DialogueManager.Instance);
        AudioManager.Instance.ChangeMusic(SceneManager.GetActiveScene().buildIndex);
        
        
    }
    

    private void Update()
    {
        PlayerInput();
        
    }
    public void PlayerInteract(){
        if (!dialogueManager.IsOpen)
        {
            //Interactable?.Interact(this);
            Interactable?.Interact();
        }
    }
    private void OnEnable() {
        playerControls.Enable();
    }
    private void OnDisable() {
        playerControls.Disable();
    }

    private void FixedUpdate() {
        Move();
        FlipPlayer();
    }
    void PlayerInput(){
        Movement=playerControls.Movement.Move.ReadValue<Vector2>();
        Movement.x=UI.Instance.MoveJoystick.Horizontal;
        Movement.y=UI.Instance.MoveJoystick.Vertical;
        myAnimator.SetFloat("MoveX",Movement.x);
        myAnimator.SetFloat("MoveY",Movement.y);
    }

    private void Move(){
        if(knockBack.GettingKockBack||PlayerHealth.Instance.IsDeath||dialogueManager.IsOpen) {return;}


        rb.MovePosition(rb.position+Movement*Time.fixedDeltaTime*moveSpeed);
        
    }

    private void FlipPlayer(){
        // Vector2 positionMose=Input.mousePosition;
        // Vector3 positionWorld=Camera.main.WorldToScreenPoint(transform.position);
        Vector2 positionMose=UI.Instance.AttackJoystick.Direction;
        if(positionMose.x<0&&facingLeft==false){
            mySpriteRenderer.flipX=true;
            facingLeft=true;
        }
        else if(positionMose.x>0&&facingLeft==true){
            mySpriteRenderer.flipX=false;
            facingLeft=false;
        }
        // if(positionMose.x<positionWorld.x){
        //     mySpriteRenderer.flipX=true;
        //     facingLeft=true;
        // }
        // else{
        //     mySpriteRenderer.flipX=false;
        //     facingLeft=false;
        // }

    }

    public void Dash(){
        if(SettingMenu.Instance.GetIsOpenSetting()) return;
        if(PlayerHealth.Instance.IsDeath) return;
        if(!isDash&&Stamina.Instance.CurrentStamina>0){
            isDash=true;
            Stamina.Instance.UseStamina();
            moveSpeed*=dashSpeed;
            myTrailRenderer.emitting=true;
            StartCoroutine(DashRoutine());

        }
    }
    private IEnumerator DashRoutine(){
        yield return new WaitForSeconds(timeDash);
        moveSpeed/=dashSpeed;
        myTrailRenderer.emitting=false;
        yield return new WaitForSeconds(dashCD);
        isDash=false;
    }
    public Transform GetWeaponCollider(){
        return weaponCollider;
    }
    public void GetDialogueManager(DialogueManager dialogueManager){
        this.dialogueManager=dialogueManager;
    }
    public void Freeze(float timeFreeze,float rate){
        if(freezeRoutine!=null){
            StopCoroutine(freezeRoutine);
            NormalState();
        }
        freezeRoutine=FreezeAttackRoutine(timeFreeze,rate);
        StartCoroutine(freezeRoutine);
    }
    IEnumerator FreezeAttackRoutine(float timeFreeze,float rate){
        mySpriteRenderer.color=Color.blue;
        float moveAttacked=initialMovementSpeed-(rate/100)*initialMovementSpeed;
        moveSpeed=moveAttacked;
        yield return new WaitForSeconds(timeFreeze);
        mySpriteRenderer.color=Color.white;
        moveSpeed=initialMovementSpeed;

    }
    private void NormalState(){
        mySpriteRenderer.color=Color.white;
        moveSpeed=initialMovementSpeed;
    }

}
