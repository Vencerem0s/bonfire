using UnityEngine;

public class Staff : MonoBehaviour
{
    //private Collider2D coll;

    public GameObject laserPrefab;

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

            /*if (hit)
            {
                // ������� ���� �����, ���� ��� ���������� � ���
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
            // ���������� ��������� ���, ���� ������ ���� ��������
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
        // ���������� ��������� ���, ���� ������ ���� ��������
        Destroy(currentLaser.gameObject);
    }
}
