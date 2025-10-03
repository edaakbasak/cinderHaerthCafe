using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // De�i�kenler
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f; // Karakterin hareket h�z�. Inspector'dan de�i�tirilebilir.

    private Rigidbody rb; // Karakterin fiziksel bedeni (Rigidbody component'i)
    private Vector2 moveInput; // Kullan�c�n�n klavye girdisini (WASD) tutacak de�i�ken

    // Oyun ba�lad���nda bir kere �al���r
    void Start()
    {
        // Rigidbody component'ini Player objesinden bul ve rb de�i�kenine ata.
        rb = GetComponent<Rigidbody>();
    }

    // Her frame (kare) g�ncellenir. Input (girdi) almak i�in idealdir.
    void Update()
    {
        // Yatay (A, D tu�lar�) ve Dikey (W, S tu�lar�) girdileri al�yoruz.
        // Bu de�erler -1 ile 1 aras�nda yumu�ak bir ge�i�le d�ner.
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
    }

    // Fizik hesaplamalar� i�in belirli ve sabit aral�klarla �al���r.
    // Hareket kodunu burada yazmak daha stabildir.
    void FixedUpdate()
    {
        // Ald���m�z 2D girdiyi (x, y), 3D d�nya hareketine (x, z) �eviriyoruz.
        // Karakterin yukar�/a�a�� (Y ekseni) hareket etmesini istemiyoruz.
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);

        // Rigidbody'nin h�z�n�, hareket y�n� * h�z de�i�kenimizle ayarl�yoruz.
        // Time.fixedDeltaTime ile �arparak frame rate'ten ba��ms�z, p�r�zs�z bir hareket sa�lar�z.
        rb.velocity = movement * moveSpeed;
    }
}