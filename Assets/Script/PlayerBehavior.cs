using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    public float JumpVelocity = 5f;

    private float _vInput;
    private float _hInput;
    private bool _isJumping;
    private Rigidbody _rb;

    //lompat sekali k=hanya ketika nyentuh ground
    public bool IsOnGround = true;
    public float GroundCheckRadius = 1.05f;
    public LayerMask GroundLayer;

    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool _isShooting;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        _isJumping = Input.GetKeyDown(KeyCode.Space);

        //lompat 
        IsOnGround = Physics.CheckSphere(transform.position, GroundCheckRadius, GroundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            _isJumping = true;
        }

        //shooting
        _isShooting |= Input.GetKeyDown(KeyCode.F);
    }

    void FixedUpdate()
    {
        // Gerak maju mundur
        _rb.MovePosition(transform.position + transform.forward * _vInput * Time.fixedDeltaTime);

        // Rotasi kiri kanan
        Quaternion angleRot = Quaternion.Euler(Vector3.up * _hInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        // Lompat
        if (_isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
            _isJumping = false;
        }

        //shooting
        if (_isShooting)
        {
            Vector3 spawnPos = transform.position + transform.forward * 1f;
            GameObject newBullet = Instantiate(Bullet, spawnPos, this.transform.rotation);
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * BulletSpeed;
            _isShooting = false;
        }
    }

    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(transform.position, GroundCheckRadius);
    //}
}