using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // De�i�kenler
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f;

    private Rigidbody rb;
    private Vector2 moveInput;

    // YEN�: Animator referans�n� tutacak de�i�ken
    private Animator animator;

    // Oyun ba�lad���nda bir kere �al���r
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // YEN�: Player objesinin alt�ndaki (child) Animator component'ini bul ve ata.
        // GetComponentInChildren kullan�yoruz ��nk� Animator, script'in oldu�u obje'de de�il, onun alt�ndaki Astronaut modelinde.
        animator = GetComponentInChildren<Animator>();
    }

    // Her frame (kare) g�ncellenir.
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        // YEN�: Animator'un isWalking parametresini g�ncelle.
        // E�er hareket girdisi varsa (vekt�r�n b�y�kl��� 0'dan b�y�kse) true, yoksa false g�nder.
        if (moveInput.magnitude > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    // Fizik hesaplamalar� i�in belirli ve sabit aral�klarla �al���r.
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);

        // Hareketi normalize edip h�zla �arparak �apraz gidi�lerde h�zlanmay� �nleyebiliriz.
        // Bu daha p�r�zs�z bir hareket sa�lar.
        rb.velocity = movement.normalized * moveSpeed;
    }
}