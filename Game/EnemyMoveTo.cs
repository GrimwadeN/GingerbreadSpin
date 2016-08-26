using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyMoveTo : MonoBehaviour {


    public enum EEnemyState
    {
        OUT_OF_VIEW,
        MOVE_IN_VIEW,
        IN_VIEW,
        ATTACKING,
        MOVE_OUT_VIEW
    }

    public EEnemyState state = EEnemyState.OUT_OF_VIEW;

    public Vector3 inViewOffset = new Vector3();

    private float lerpTime = 0;
    private Vector3 startPos;
    private Vector3 targetPos;
    private bool willAttack = false;
    private float attackCooldown = 0.0f;
    private float timer = 1;

    public int chanceToAttackOutOf10 = 5;
    public float MaxAttackWaitTime = 5.0f;
    public float MinAttackWaitTime = 1.0f;
    public float timeForEnemyToStartAttack = 5;


    bool clicked;

    PlayerLives lives;


    // Use this for initialization
    void Start () {
        targetPos = transform.position;
        startPos = transform.position;
        lives = GameObject.FindWithTag("GingerbreadMan").GetComponent<PlayerLives>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject == this.gameObject)
                {
                    clicked = true;
                }
            }
        }

        // temp state change
        //--------------------------------------------
        timer += Time.deltaTime;
        if((int)timer % timeForEnemyToStartAttack == 0)
        {
            if (state == EEnemyState.OUT_OF_VIEW)
            {
                Debug.Log("Out of View");
                ChangeState(EEnemyState.MOVE_IN_VIEW);
            }
        }

        if ( Input.GetKeyDown(KeyCode.Space))
        {
            if (state == EEnemyState.OUT_OF_VIEW) ChangeState(EEnemyState.MOVE_IN_VIEW);
            if (state == EEnemyState.IN_VIEW) ChangeState(EEnemyState.MOVE_OUT_VIEW);
        }
        //--------------------------------------------


        if ( state == EEnemyState.OUT_OF_VIEW )
        {
            // nothing to do
        }
        else if( state == EEnemyState.MOVE_IN_VIEW || state == EEnemyState.MOVE_OUT_VIEW )
        {
            lerpTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, targetPos, lerpTime);

            if( lerpTime > 1.0f )
            {
                lerpTime = 0.0f;
                if (state == EEnemyState.MOVE_IN_VIEW) ChangeState(EEnemyState.IN_VIEW);
                if (state == EEnemyState.MOVE_IN_VIEW && clicked == true)
                {
                    ChangeState(EEnemyState.MOVE_OUT_VIEW);
                    clicked = false;
                }
                if (state == EEnemyState.MOVE_OUT_VIEW) ChangeState(EEnemyState.OUT_OF_VIEW);
            }
        }
        else if( state == EEnemyState.IN_VIEW )
        {
            if(clicked == true)
            {
                ChangeState(EEnemyState.MOVE_OUT_VIEW);
                clicked = false;
            }
            attackCooldown -= Time.deltaTime;
            if( attackCooldown <= 0 )
            {
                if (willAttack) ChangeState(EEnemyState.ATTACKING);
                else ChangeState(EEnemyState.MOVE_OUT_VIEW);
            }
        }
        else if( state == EEnemyState.ATTACKING )
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0.0f)
            {          
                lives.playerLives -= 1;
                GameObject.FindWithTag("PieInFace").GetComponent<Image>().enabled = true;
                ChangeState(EEnemyState.MOVE_OUT_VIEW);
                StartCoroutine(PieFace(3));
            }
            
        }
	}

    void ChangeState(EEnemyState newState )
    {
        if (newState == EEnemyState.OUT_OF_VIEW)
        {
            // nothing to do
        }
        else if (newState == EEnemyState.MOVE_IN_VIEW)
        {
            startPos = transform.position;
            targetPos = transform.position + inViewOffset;
        }
        else if (newState == EEnemyState.IN_VIEW)
        {
            // calculate if we should attack or not
            willAttack = Random.Range(0, 10) > chanceToAttackOutOf10;
            attackCooldown = Random.Range(MinAttackWaitTime, MaxAttackWaitTime);

        }
        else if (newState == EEnemyState.ATTACKING)
        {
            // nothing to do
            attackCooldown = Random.Range(MinAttackWaitTime, MaxAttackWaitTime);
        }
        else if (newState == EEnemyState.MOVE_OUT_VIEW)
        {
            startPos = transform.position;
            targetPos = transform.position - inViewOffset;
        }

        state = newState;
    }

    IEnumerator PieFace(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject.FindWithTag("PieInFace").GetComponent<Image>().enabled = false;
    }
    
}

