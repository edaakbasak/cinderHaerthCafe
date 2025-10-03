using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Deðiþkenler
    [Header("Camera Target")]
    public Transform target; // Kameranýn takip edeceði obje (Player'ýmýzýn Transform'u)

    [Header("Camera Settings")]
    public Vector3 offset; // Kameranýn hedeften ne kadar uzakta duracaðý (X, Y, Z mesafesi)

    // LateUpdate, tüm Update fonksiyonlarý çalýþtýktan sonra, her frame'in sonunda çalýþýr.
    // Karakter hareket ettikten sonra kameranýn pozisyonunu güncellemek için en ideal yerdir.
    // Bu, takýlmalarý ve titremeleri önler.
    void LateUpdate()
    {
        // Eðer bir hedefimiz yoksa (mesela Player ölürse) hata vermemesi için kontrol.
        if (target == null)
        {
            return; // Fonksiyondan çýk, aþaðýdaki kodu çalýþtýrma.
        }

        // Bu kameranýn pozisyonunu, hedefin pozisyonu + belirlediðimiz mesafe olarak ayarla.
        transform.position = target.position + offset;
    }
}