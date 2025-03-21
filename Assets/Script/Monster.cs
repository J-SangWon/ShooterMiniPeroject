using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 3f;  // 몬스터 이동 속도
    public int health = 5;    // 몬스터 체력 (초기값 5)

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;  // 왼쪽으로 이동

        // 화면 왼쪽 끝을 벗어나면 제거
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Player와 충돌 감지
        {
            Debug.Log($"{gameObject.name}이(가) Player와 충돌함!");
            // Player가 죽는 처리는 Player 스크립트에서 하면 됨.
        }



<<<<<<< Updated upstream
        if (other.CompareTag("Shot"))
        {
            // Shot과 충돌 시 체력 감소
            health -= 1;
            Destroy(other.gameObject); // 총알은 삭제

            Debug.Log($"{gameObject.name}이(가) Shot과 충돌하여 체력 감소! 현재 체력: {health}");

            // 체력이 0 이하일 때 몬스터 삭제
            if (health <= 0)
            {
                Destroy(gameObject);
                Debug.Log($"{gameObject.name}이(가) 체력이 0 이하로 감소하여 삭제됨!");
            }
=======
        //if (other.CompareTag("Shot"))
        //{
        //    // Shot과 충돌 시 체력 감소
        //    health -= 1;
        //    Destroy(other.gameObject); // 총알은 삭제

        //    Debug.Log($"{gameObject.name}이(가) Shot과 충돌하여 체력 감소! 현재 체력: {health}");

        //    // 체력이 0 이하일 때 몬스터 삭제
        //    if (health <= 0)
        //    {
        //        Destroy(gameObject);
        //        Debug.Log($"{gameObject.name}이(가) 체력이 0 이하로 감소하여 삭제됨!");
        //    }
>>>>>>> Stashed changes
        }
    }

