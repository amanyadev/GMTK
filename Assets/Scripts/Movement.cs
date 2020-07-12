using UnityEngine;

/// <summary>
///  Currently working by adding offset to the Input.. giving it jittery movement.
/// </summary>
public class Movement : MonoBehaviour
{

    Rigidbody2D rb2d;
    Vector2 velocity;

    [SerializeField] Animator _animator;

    //[SerializeField][Range (0, 1f)] float _drunkMovement;

    float drunkOffset;
    [Header("Tweak these for drunk state movement")]
    [SerializeField] [Range(0, 100)] float _noOfShots;

    [Space(20)]

    [SerializeField] float _moveSpeed;
    public float verticalSpeed;

    public float drunkSpeed;

    [Space(20)]
    public float minDrunkForce;
    public float maxDrunkForce;
    public float drunkForce;

    [SerializeField] private float drunkTimer;
    [SerializeField] private float minDrunk;
    [SerializeField] private float maxDrunk;

    [SerializeField] private float waitTime;
    private float privateWaitTime;

    private int drunkDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        drunkDir = Random.Range(-1, 1);
        //privateDrunkTimer = drunkTimer;
        privateWaitTime = waitTime;
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
            if (drunkTimer > 0)
            {
                drunkTimer -= Time.deltaTime;
                transform.Translate(new Vector3(drunkSpeed * Time.deltaTime * drunkDir, 0f, 0f));
            }
            if (drunkTimer <= 0)
            {
                //waitTime -= Time.deltaTime;
                drunkDir = Random.value < 0.5 ? -1 : 1;
                drunkTimer = Random.Range(minDrunk, maxDrunk);
            }
        }

        if (waitTime <= 0)
        {
            drunkDir = Random.value < 0.5 ? -1 : 1;
            waitTime = privateWaitTime;
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            drunkForce = Random.Range(minDrunkForce, maxDrunkForce);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            float axis = Input.GetAxis("Horizontal");

            //transform.Translate(new Vector3(drunkSpeed * -1 * Time.deltaTime, 0f, 0f));
            transform.Translate(new Vector3(axis * (_moveSpeed + drunkForce) * Time.deltaTime, 0f, 0f));
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, verticalSpeed * Time.deltaTime);

        /*float i;
        velocity = rb2d.velocity;
        //if drunk give offset.. else dont.
        drunkOffset = GameManager.instance.drunk ? (Random.Range (-_noOfShots, _noOfShots) / 100f) : 0;

        i = Input.GetAxis ("Horizontal") + drunkOffset;

        if (i != 0)
        {
            velocity.x = i * _moveSpeed;
            //      anim.SetBool ("moving", true);//set anim
        }
        else
        { //Stop Immediately.
            //  anim.SetBool ("moving", false);//anim
            velocity.x = 0f;
        }

        rb2d.velocity = velocity;*/
    }

    void DrunkShake()
    {

    }
}