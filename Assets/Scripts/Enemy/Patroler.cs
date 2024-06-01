using UnityEngine;

public class Patroler : MonoBehaviour
{
    public float speed;
    public int posOfPatrol;
    public Transform point;
    bool movingRight;

    bool chill = false;
    bool angry = false;
    bool toBact = false;
    public bool isBoss = false;

    public Transform player;
    public float stoppingDistance;

    public Animator animatok;

    [SerializeField] private AudioSource attackEnemyAudio;


    void Start()
    {
        animatok = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < posOfPatrol && !angry)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            toBact = false;
            chill = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            toBact = true;
            angry = false;
        }   
        if (chill) Chill();
        else if (angry) Angry();
        else if (toBact) ToBack();
    }
    void Chill()
    {
        if (transform.position.x > point.position.x + posOfPatrol) movingRight = false;
        else if (transform.position.x < point.position.x - posOfPatrol) movingRight = true;
        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    void Angry()
    {
        attackEnemyAudio.Play();
        if (player.position.x > transform.position.x) transform.eulerAngles = new Vector3(0, 180, 0);
        else if (player.position.x < transform.position.x) transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (isBoss) speed = 2;
        else speed = 4;
    }
    void ToBack() => transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);

}
