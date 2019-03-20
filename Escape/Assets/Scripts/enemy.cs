using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public GameObject player;
    public Transform lineofsight;
    Animator anim;
   /* public AudioClip chase;
    public AudioSource chaseSource;
    public AudioClip ambiance;
    public AudioSource ambianceSource;*/

    private NavMeshAgent nav;
    public string state = "idle";
    private bool alive = true;
    private float wait = 0f;
   // private bool highAlert = false;
    private float alert = 50f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        nav.speed = 10.0f;
       // chaseSource.clip = chase;
      //  ambianceSource.clip = ambiance;
    }

    /*public void checkSight()
    {
        if (alive == true)
        {
            print("checking sight");
            RaycastHit rayHit;
            if (Physics.Linecast(lineofsight.position, player.transform.position, out rayHit))
            {
                //print("SUCCES");
                print("hit " + rayHit.collider.gameObject.name);
                if (rayHit.collider.gameObject.name == "player")
                {
                    print("SET TO CHASE");
                    if (state != "kill")
                    {
                        state = "chase";
                        nav.speed = 12.0f;
                    }
                }
            }
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        if(alive == true)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 30f)
            {
                state = "chase";
            }
            if(state == "idle")
            {
                if (anim.GetBool("walking") == true)
                {
                    anim.SetBool("walking", false);
                }
                //print("Idle");
                //pick random walk destination
                Vector3 randomPos = Random.insideUnitSphere * alert;
                NavMeshHit navHit;
                NavMesh.SamplePosition(transform.position + randomPos, out navHit, 50f, NavMesh.AllAreas);
                //go near the player
               /* if (highAlert)
                {
                    NavMesh.SamplePosition(player.transform.position + randomPos, out navHit, 50f, NavMesh.AllAreas);
                    alert += 10f;
                    if(alert > 50f)
                    {
                        highAlert = false;
                        nav.speed = 10.0f;
                    }
                }*/
                nav.SetDestination(navHit.position);
                state = "walk";
            }
            if(state == "walk")
            {
                if (anim.GetBool("walking") == false)
                {
                    anim.SetBool("walking", true);
                }
                //print("walking");
                if(nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
                {
                    state = "search";
                    wait = 2f;
                }
            }
            if(state == "search")
            {
                if (anim.GetBool("walking") == true)
                {
                    anim.SetBool("walking", false);
                }
                //print("Searching");
                if (wait >= 0f)
                {
                    wait -= Time.deltaTime;
                    transform.Rotate(0f, 60f * Time.deltaTime, 0f);
                }
                else
                {
                    state = "idle";
                }
            }
            if(state == "chase")
            {
               // chaseSource.Play();
                if (anim.GetBool("walking") == false)
                {
                    anim.SetBool("walking", true);
                }
                //print("Chasing");
                nav.destination = player.transform.position;
                //lose sight of the player
                distance = Vector3.Distance(transform.position, player.transform.position);
                if(distance > 50f)
                {
                    state = "search";
                }
            }
            /*else
            {
                ambianceSource.Play();
            }*/
           /* if(state == "hunt")
            {
                if(anim.GetBool("walking") == false)
                {
                    anim.SetBool("walking", true);
                }
                //print("Hunting");
                if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
                {
                    state = "search";
                    wait = 2f;
                    highAlert = true;
                    alert = 10f;
                    checkSight();
                }
            }*/
        }
        //nav.SetDestination(player.transform.position);
    }

}
