using UnityEngine;

public class Staff : MonoBehaviour
{
    public Transform laserFireStartPoint;
    public Transform laserFireEndPoint;
    public LineRenderer m_lineRenderer;

    private void Start()
    {
        m_lineRenderer.enabled = false;
    }

    private void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        m_lineRenderer.SetPosition(0, laserFireStartPoint.position);
        m_lineRenderer.SetPosition(1, laserFireEndPoint.position);

        Vector2 direction = laserFireEndPoint.position - laserFireStartPoint.position;

        RaycastHit2D _hit = Physics2D.Raycast(laserFireStartPoint.position, direction.normalized, direction.magnitude);

        if(_hit)
        {
            m_lineRenderer.SetPosition(1, _hit.point);
        }
    }

    public void StaffSpell()
    {
        //из этих скриптов нужно осуществить плавное появление луча
        m_lineRenderer.enabled = true;
    }

    public void StaffSpellOff()
    {
        m_lineRenderer.enabled = false;
    }
}
