using UnityEngine;

public class Movement : MonoBehaviour {
    Vector3 _movedirection;
    [SerializeField] float _speed = 5f;
    [SerializeField] float _gravity = -19.2f;
    [SerializeField] Animator anim;
    CharacterController _controller;

    void Start () {
        _controller = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update () {
        float x = Input.GetAxis ("Horizontal");
        float y = Input.GetAxis ("Vertical");

        anim.SetFloat ("Forward", y);
        anim.SetFloat ("Turn", x);

        if (_controller.isGrounded) {
            _movedirection = new Vector3 (x, 0, y) * _speed;
        }

        _movedirection.y += _gravity * Time.deltaTime;

        _controller.Move (_movedirection * Time.deltaTime);
    }
}