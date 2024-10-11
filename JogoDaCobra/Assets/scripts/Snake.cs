using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField]
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] List<Transform> corpoDaCobra;
    [SerializeField] Transform coropo;

    // Lista para armazenar os segmentos da cobra

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Inicializa a lista com o transform da própria cobra (cabeça)
        corpoDaCobra = new List<Transform>();
        corpoDaCobra.Add(transform);
    }

    void Update()
    {
        // Lógica de movimento
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Não permite mover em diagonal
        if (horizontal != 0)
            vertical = 0;

        moveDirection = new Vector2(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        Move();
        for (int i = corpoDaCobra.Count - 1; i > 0; i--)
        {
            corpoDaCobra[i].position = corpoDaCobra[i - 1].position;
        }

    }
    private void Move()
    {
        // Armazena a posição atual da cabeça antes de mover
        Vector3 previousPosition = transform.position;

        // Move a cobra
        Vector3 newPosition = (speed * Time.fixedDeltaTime * moveDirection.normalized) + rb.position;
        rb.MovePosition(newPosition);
    }



        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            GameManager.instance.OnFoodCollected();
            Grow();
            Destroy(collision.gameObject);

        }
        void Grow()
        {
            Transform novoCorpo = Instantiate(coropo, corpoDaCobra[corpoDaCobra.Count - 1].position, Quaternion.identity);
            corpoDaCobra.Add(novoCorpo);
        }
    }
}
    
        

    

