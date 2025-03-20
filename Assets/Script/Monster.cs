using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 3f;  // 몬스터 이동 속도

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
    }
}
