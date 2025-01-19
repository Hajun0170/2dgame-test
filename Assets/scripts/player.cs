using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class player : MonoBehaviour
{
   
    public float speed = 5f;
    private  Rigidbody2D rb;
    private Vector2 movement;   // 이동 방향 벡터
    void Start()
    {
        // Rigidbody 컴포넌트
        rb = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        // 방향 벡터 계산    
        movement = new Vector2(h, v);

        //방향 벡터의 대각선 속도를 일치 시킴
        if (movement.magnitude > 1f)
            movement.Normalize();

   /*
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            rb.rotation = angle; // Rigidbody2D의 회전 설정
        }
   */
    }

    void FixedUpdate()
    {
        // Rigidbody2D를 사용한 이동 처리
        rb.linearVelocity = movement * speed;
    }
}
