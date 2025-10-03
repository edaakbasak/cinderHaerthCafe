using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Deðiþkenler
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f; // Karakterin hareket hýzý. Inspector'dan deðiþtirilebilir.

    private Rigidbody rb; // Karakterin fiziksel bedeni (Rigidbody component'i)
    private Vector2 moveInput; // Kullanýcýnýn klavye girdisini (WASD) tutacak deðiþken

    // Oyun baþladýðýnda bir kere çalýþýr
    void Start()
    {
        // Rigidbody component'ini Player objesinden bul ve rb deðiþkenine ata.
        rb = GetComponent<Rigidbody>();
    }

    // Her frame (kare) güncellenir. Input (girdi) almak için idealdir.
    void Update()
    {
        // Yatay (A, D tuþlarý) ve Dikey (W, S tuþlarý) girdileri alýyoruz.
        // Bu deðerler -1 ile 1 arasýnda yumuþak bir geçiþle döner.
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
    }

    // Fizik hesaplamalarý için belirli ve sabit aralýklarla çalýþýr.
    // Hareket kodunu burada yazmak daha stabildir.
    void FixedUpdate()
    {
        // Aldýðýmýz 2D girdiyi (x, y), 3D dünya hareketine (x, z) çeviriyoruz.
        // Karakterin yukarý/aþaðý (Y ekseni) hareket etmesini istemiyoruz.
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);

        // Rigidbody'nin hýzýný, hareket yönü * hýz deðiþkenimizle ayarlýyoruz.
        // Time.fixedDeltaTime ile çarparak frame rate'ten baðýmsýz, pürüzsüz bir hareket saðlarýz.
        rb.velocity = movement * moveSpeed;
    }
}