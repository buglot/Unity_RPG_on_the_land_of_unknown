using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : BossATKBase
{
    // Start is called before the first frame update
    [SerializeField] GameObject target;
    [SerializeField] private Animator nomalAnime;
    [SerializeField] private Animator Myanime;
    [SerializeField] private Transform parent;
    public float timer;
    public float time;
    public float speed = 20f;
    public float timekillanimation;
    [SerializeField] Transform player;
    [SerializeField] Vector3 range;
    bool canPlay = false;
    bool canRandom = false;
    bool canMoveTarget = false;
    void Start()
    {
        player = GameObject.FindAnyObjectByType<Player>().gameObject.transform;
    }
    Vector3 go;
    int count = 0;
    bool followPlayer = false;
    bool downtarget = false;
    bool onetime = true;
    [SerializeField] bool twotime = false;
    bool threetime = true;
    void Update()
    {
        if (canPlay)
        {


            if (onetime)
            {
                nomalAnime.SetTrigger("spl");
                onetime = false;
            }
            if (nomalAnime.GetCurrentAnimatorStateInfo(0).normalizedTime >= timekillanimation && twotime)
            {
                Debug.Log("animetion");
                target.SetActive(true);
                canRandom = true;
                target.transform.position = new Vector3(4, 4, 0) + player.transform.position;
            }
            if (canRandom)
            {
                Debug.Log("Ramdom new");
                go = getLocationForMoveRandom() + player.transform.position;
                canRandom = false;
                canMoveTarget = true;
            }
            if (canMoveTarget)
            {
                Vector3 direction = (go - target.transform.position).normalized;
                target.transform.position += direction * speed * Time.deltaTime;
                float same = Vector3.Distance(target.transform.position, go);
                if (same <= 0.01f)
                {
                    canMoveTarget = false;
                    canRandom = true;
                    count++;
                    if (count == 3)
                    {
                        followPlayer = true;
                        canRandom = false;
                    }
                }
            }
            if (followPlayer)
            {
                Vector3 direction = player.transform.position - target.transform.position;
                target.transform.position += direction * speed * Time.deltaTime;
                float same = Vector3.Distance(target.transform.position, player.transform.position);
                if (same <= 2f)
                {

                    if (count == 3)
                    {
                        speed *= 2;
                        Myanime.SetBool("play", true);
                        count++; //for play i onetime animation;
                        Debug.Log("playnow");
                    }
                    timer += Time.deltaTime;

                    if (time < timer)
                    {
                        followPlayer = false;
                        downtarget = true;
                        timer = 0;
                    }
                }
            }
            if (downtarget)
            {
                timer += Time.deltaTime;

                if (time - 1 < timer)
                {
                    parent.transform.position = target.transform.position + new Vector3(0, 2, 0);
                    Debug.Log("setposition");
                    if (threetime)
                    {
                        nomalAnime.SetTrigger("downl");
                        threetime = false;
                    }

                    if (nomalAnime.GetCurrentAnimatorStateInfo(0).normalizedTime >= timekillanimation)
                    {
                        Clear();
                        Debug.Log("end");
                    }
                }

            }


        }

    }
    public Vector3 getLocationForMoveRandom()
    {
        Vector3 playernow = player.transform.position;
        Vector3 v = new Vector3(Random.Range(-range.x, range.x), Random.Range(-range.y, range.y), 0);
        v += playernow;
        return v;
    }
    public override void play()
    {
        canPlay = true;
        END = false;
    }

    public override void Clear()
    {
        target.SetActive(false);
        canPlay = false;
        downtarget = false;
        onetime = true;
        twotime = true;
        threetime = true;
        count = 0;
        END = true;
        speed /= 2;
    }

    public override void Cancel()
    {
        parent.transform.position = player.transform.position + new Vector3(3, 3, 0);
        nomalAnime.Play("downl");
        Clear();
    }
}