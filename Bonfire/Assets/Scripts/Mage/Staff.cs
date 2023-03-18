using UnityEngine;

public class Staff : MonoBehaviour
{
    //private Collider2D coll;

    public GameObject laserPrefab;

    // Максимальная длина луча
    public float maxLaserDistance = 5f;

    // Урон, наносимый врагу при контакте с лучом
    public float laserDamage = 10f;

    // Слой, на котором находятся враги
    public LayerMask enemyLayer;

    // Приватные поля хранящие луч, который был создан, и материал, используемый для его визуализации
    private LineRenderer currentLaser;
    private Material laserMaterial;

    // Камера, используемая для определения позиции курсора
    private Camera cam;

    public bool staffCast;

    private void Start()
    {
        staffCast = false;
        cam = Camera.main;
        laserMaterial = laserPrefab.GetComponent<LineRenderer>().material;
    }

    private void Update()
    {
        if (staffCast == true)
        {
            // Определяем позицию курсора в мировых координатах
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            // Создаем луч в позиции курсора
            GameObject laserGo = Instantiate(laserPrefab, mousePos, Quaternion.identity);
            currentLaser = laserGo.GetComponent<LineRenderer>();
            currentLaser.SetPosition(0, mousePos);

            // Направляем луч в сторону курсора
            Vector2 direction = mousePos - (Vector2)currentLaser.transform.position;
            currentLaser.SetPosition(1, currentLaser.transform.position + (Vector3)direction.normalized * 0.1f);

            // Ограничиваем длину луча
            float distance = Mathf.Min(direction.magnitude, maxLaserDistance);
            currentLaser.SetPosition(1, currentLaser.transform.position + (Vector3)direction.normalized * distance);

            // Проверяем контакт с врагами
            RaycastHit2D hit = Physics2D.Raycast(currentLaser.transform.position, direction, distance, enemyLayer);

            /*if (hit)
            {
                // Наносим урон врагу, если луч столкнулся с ним
                EnemyController enemy = hit.collider.GetComponent<EnemyController>();
                if (enemy)
                {
                    enemy.TakeDamage(laserDamage);
                }
            }*/
        }


        if (currentLaser != null)
        {
            float percent = (currentLaser.GetPosition(1) - currentLaser.GetPosition(0)).magnitude / maxLaserDistance;
            laserMaterial.SetFloat("_Percent", percent);
        }

        /*if (Input.GetMouseButtonUp(0))
        {
            // Уничтожаем созданный луч, если кнопка мыши отпущена
            Destroy(currentLaser.gameObject);
        }*/
    }


    /*void Start()
    {
        coll = GetComponent<Collider2D>();
        coll.enabled = false;
    }*/

    /*void Update()
    {
        
    }*/

    public void StaffSpell()
    {
        staffCast = true;
    }

    public void StaffSpellOff()
    {
        staffCast = false;
        // Уничтожаем созданный луч, если кнопка мыши отпущена
        Destroy(currentLaser.gameObject);
    }
}
