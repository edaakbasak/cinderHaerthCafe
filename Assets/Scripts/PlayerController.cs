using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Deðiþkenler
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f;

    private Rigidbody rb;
    private Vector2 moveInput;

    // YENÝ: Animator referansýný tutacak deðiþken
    private Animator animator;

    // Oyun baþladýðýnda bir kere çalýþýr
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // YENÝ: Player objesinin altýndaki (child) Animator component'ini bul ve ata.
        // GetComponentInChildren kullanýyoruz çünkü Animator, script'in olduðu obje'de deðil, onun altýndaki Astronaut modelinde.
        animator = GetComponentInChildren<Animator>();
    }

    // Her frame (kare) güncellenir.
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        // YENÝ: Animator'un isWalking parametresini güncelle.
        // Eðer hareket girdisi varsa (vektörün büyüklüðü 0'dan büyükse) true, yoksa false gönder.
        if (moveInput.magnitude > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    // Fizik hesaplamalarý için belirli ve sabit aralýklarla çalýþýr.
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);

        // Hareketi normalize edip hýzla çarparak çapraz gidiþlerde hýzlanmayý önleyebiliriz.
        // Bu daha pürüzsüz bir hareket saðlar.
        rb.velocity = movement.normalized * moveSpeed;
    }
}