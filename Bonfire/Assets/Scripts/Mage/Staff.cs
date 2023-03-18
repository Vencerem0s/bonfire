using UnityEngine;

public class Staff : MonoBehaviour
{
    //private Collider2D coll;

    /*public GameObject laserPrefab;

    // ������������ ����� ����
    public float maxLaserDistance = 5f;

    // ����, ��������� ����� ��� �������� � �����
    public float laserDamage = 10f;

    // ����, �� ������� ��������� �����
    public LayerMask enemyLayer;

    // ��������� ���� �������� ���, ������� ��� ������, � ��������, ������������ ��� ��� ������������
    private LineRenderer currentLaser;
    private Material laserMaterial;

    // ������, ������������ ��� ����������� ������� �������
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
        if (Physics2D.Raycast(m_Transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), defDistanceRay))//����� ������� ����� ��������� ������ � ��� ��� ����������, �� ��� ����� ��������
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
            // ���������� ������� ������� � ������� �����������
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            // ������� ��� � ������� �������
            GameObject laserGo = Instantiate(laserPrefab, mousePos, Quaternion.identity);
            currentLaser = laserGo.GetComponent<LineRenderer>();
            currentLaser.SetPosition(0, mousePos);

            // ���������� ��� � ������� �������
            Vector2 direction = mousePos - (Vector2)currentLaser.transform.position;
            currentLaser.SetPosition(1, currentLaser.transform.position + (Vector3)direction.normalized * 0.1f);

            // ������������ ����� ����
            float distance = Mathf.Min(direction.magnitude, maxLaserDistance);
            currentLaser.SetPosition(1, currentLaser.transform.position + (Vector3)direction.normalized * distance);

            // ��������� ������� � �������
            RaycastHit2D hit = Physics2D.Raycast(currentLaser.transform.position, direction, distance, enemyLayer);

            *//*if (hit)
            {
                // ������� ���� �����, ���� ��� ���������� � ���
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
            // ���������� ��������� ���, ���� ������ ���� ��������
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
        // ���������� ��������� ���, ���� ������ ���� ��������
        //Destroy(currentLaser.gameObject);
    }
}
