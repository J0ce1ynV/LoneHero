using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpStrength = 10f;
    private float speed = 2f;
    private Animator animator;

    // arah player
    private float facing_direction = 1f;

    // untuk power up buah
    public Tilemap fruit_tilemap;
    public float grow_amount = 0.5f;
    public float duration = 3f;
    private Vector3 original_scale;
    private bool is_growing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameManager.Instance.GameManagerCheck();
        original_scale = transform.localScale;
    }

    private void PlayWalkAnimation()
    {
        animator.SetTrigger("goWalk");
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // GERAK
        var x = horizontalInput * speed * Time.deltaTime;
        transform.Translate(new Vector3(x, 0f, 0f));

        if (horizontalInput != 0) PlayWalkAnimation();

        // FLIP ARAH
        if (horizontalInput > 0) facing_direction = 1f;
        else if (horizontalInput < 0) facing_direction = -1f;

        ApplyScale();

        // LOMPAT
        var mth = Mathf.Abs(rb.linearVelocity.y) < 0.001f;

        if (Input.GetKeyDown(KeyCode.Space) && mth)
        {
            rb.AddForce(new Vector2(0f, jumpStrength), ForceMode2D.Impulse);
        }

        // CEK BUAH
        Vector3Int cell_pos = fruit_tilemap.WorldToCell(transform.position);

        if (fruit_tilemap.HasTile(cell_pos))
        {
            fruit_tilemap.SetTile(cell_pos, null);

            if (!is_growing)
            {
                StartCoroutine(grow_temporary());
            }
        }
    }

    void ApplyScale()
    {
        float current_size = is_growing ? (original_scale.x + grow_amount) : original_scale.x;

        transform.localScale = new Vector3(
            facing_direction * current_size,
            is_growing ? (original_scale.y + grow_amount) : original_scale.y,
            original_scale.z
        );
    }

    IEnumerator grow_temporary()
    {
        is_growing = true;

        ApplyScale();

        yield return new WaitForSeconds(duration);

        is_growing = false;

        ApplyScale();
    }
}




/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpStrength = 10f;
    private float speed = 2f;
    private Animator animator;

    //untuk power up buah
    public Tilemap fruit_tilemap;
    public float grow_amount = 0.5f;
    public float duration = 3f;
    private Vector3 original_scale;
    private bool is_growing = false;

    //public PlayerPositionHandler pph;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameManager.Instance.GameManagerCheck();
        original_scale = transform.localScale;
    }

    private void PlayWalkAnimation()
    {
        animator.SetTrigger("goWalk");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        var x = horizontalInput * speed * Time.deltaTime;
        var xyz = new Vector3(x, 0f, 0f);
        transform.Translate(xyz);

        if (horizontalInput != 0) PlayWalkAnimation();

        var mth = Mathf.Abs(rb.linearVelocity.y) < 0.001f;

        if (Input.GetKeyDown(KeyCode.Space) && mth)
        {
            var y = new Vector2(0f, jumpStrength);
            rb.AddForce(y, ForceMode2D.Impulse);
        }

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(
                Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(
                -Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }

        //untuk buah
        Vector3Int cell_pos = fruit_tilemap.WorldToCell(transform.position);

        if (fruit_tilemap.HasTile(cell_pos))
        {
            fruit_tilemap.SetTile(cell_pos, null);

            if (!is_growing)
            {
                StartCoroutine(grow_temporary());
            }
        }
    }

    IEnumerator grow_temporary()
    {
        is_growing = true;

        // Perbesar player
        transform.localScale = original_scale + new Vector3(grow_amount, grow_amount, 0f);

        // Tunggu 3 detik
        yield return new WaitForSeconds(duration);

        // Kembali ke ukuran awal
        transform.localScale = original_scale;

        is_growing = false;
    }
}
*/