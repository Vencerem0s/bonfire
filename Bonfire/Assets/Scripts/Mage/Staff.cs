using UnityEngine;

public class Staff : MonoBehaviour
{
    //private Collider2D coll;

    /*public GameObject laserPrefab;

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
    private Camera cam;*/

    [SerializeField] private float defDistanceRay = 4f;
    public Transform laserFireStartPoint;
    public Transform laserFireEndPoint;
    public LineRenderer m_lineRenderer;
    private RaycastHit2D _hit;
    Transform m_Transform;

    public bool staffCast;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }

    private void Update()
    {
        //m_Transform = GetComponent<Transform>();
        _hit = Physics2D.Raycast(laserFireStartPoint.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), defDistanceRay);
        ShootLaser();
    }

    void ShootLaser()
    {
        //RaycastHit2D _hit = Physics2D.Raycast(laserFireStartPoint.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), defDistanceRay);

        /*if ()
        {

        }*/
        if (Physics2D.Raycast(m_Transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), defDistanceRay))//нужна разница между начальной точкой и тем что пересекает, на эту длину вызывать
        {
            //RaycastHit2D _hit = Physics2D.Raycast(laserFireStartPoint.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), defDistanceRay);
            //Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);// - (Vector2)currentLaser.transform.position;
            Draw2DRay(laserFireStartPoint.position, new Vector3(_hit.point.x, _hit.point.y, 0));
            print("1");
        }
        else
        {
            Draw2DRay(laserFireStartPoint.position, laserFireEndPoint.position);
            print("22");
        }
        //Draw2DRay(laserFireStartPoint.position, _hit);
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }

    /*private void Start()
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

            *//*if (hit)
            {
                // Наносим урон врагу, если луч столкнулся с ним
                EnemyController enemy = hit.collider.GetComponent<EnemyController>();
                if (enemy)
                {
                    enemy.TakeDamage(laserDamage);
                }
            }*//*
        }


        if (currentLaser != null)
        {
            float percent = (currentLaser.GetPosition(1) - currentLaser.GetPosition(0)).magnitude / maxLaserDistance;
            laserMaterial.SetFloat("_Percent", percent);
        }

        *//*if (Input.GetMouseButtonUp(0))
        {
            // Уничтожаем созданный луч, если кнопка мыши отпущена
            Destroy(currentLaser.gameObject);
        }*//*
    }


    *//*void Start()
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
        //Destroy(currentLaser.gameObject);
    }
}
