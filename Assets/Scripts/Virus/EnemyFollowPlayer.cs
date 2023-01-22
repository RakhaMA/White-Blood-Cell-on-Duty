using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    
    //buat mampung posisi player
    private Transform player;
    //buat nampung jarak pandang
    public float jarakPandang;
    //buat nampung jarakTembak
    public float shootingRange;
    //buat nampung bullet
    public GameObject bullet;
    //buat nampung posisi menembak
    public GameObject bulletPosisi;
    //membuat fire rate
    public float fireRate = 1f;
    //membuat waktu fire lagi
    public float fireLagi;


    // Start is called before the first frame update
    void Start()
    {
        //ini cari tag player terus disimpan transform posisinya ke player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {   
        //ini mengambil nilai jarak antar 2 objeck kemudian disimpan
        float distanceFromPlayer =Vector2.Distance(player.position, transform.position);

    //misal kalo masuk jarak pandang di ikuti, tapi kalo masuk ke jarak shoot berhenti
        if (distanceFromPlayer < jarakPandang && distanceFromPlayer > shootingRange)
        {
             //ini dia ngeupdate posisi virus dgn posisi vector yg diubah menyesuaikan player
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        } else if (distanceFromPlayer <= shootingRange && fireLagi < Time.time)
        {
            Instantiate(bullet, bulletPosisi.transform.position, Quaternion.identity);
            fireLagi = Time.time + fireRate;
        }

       
    }

    
    /// Callback to draw gizmos only if the object is selected.
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        // membentuk field lingkaran di gameobject
        Gizmos.DrawWireSphere(transform.position,jarakPandang);
        Gizmos.DrawWireSphere(transform.position,shootingRange);
    }
}
