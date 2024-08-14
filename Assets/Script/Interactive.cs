using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _maxDistanceRay;
    private Ray _ray;
    private RaycastHit _hit;
    private Outline _lastOutlineObject;
    [SerializeField] private float _draggableObjectDistance;

    private DraggableObject _currentlyDraggedObject = null;




    private void Update()
    {
        Ray();
        DrawRay();
        Interact();

    }
    private void Ray()
    {
        _ray = _playerCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }


    private void DrawRay()
    {
        if (Physics.Raycast(_ray, out _hit, _maxDistanceRay)) // �������� ���� �� ����������� ���������
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green); // ���� ���������� � ��������, �� �� ����� ������� ����� 
        }

        if (_hit.transform == null)
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.red);  // ���� �� ���������� � ��������, �� �� ����� �������� �����

        }

        if (Physics.Raycast(_ray, out _hit, _maxDistanceRay)) //�������� ��������
        {
            if (_hit.transform.gameObject.CompareTag("Item")) // ���� ����� ������� �� ������ c ����� "Item" , �� ��� ����� ��������
            {
                if (_lastOutlineObject != null)
                    _lastOutlineObject.enabled = false;

                _lastOutlineObject = _hit.transform.gameObject.GetComponent<Outline>();
                _lastOutlineObject.enabled = true;
            }
            else if (_lastOutlineObject != null)
            {
                _lastOutlineObject.enabled = false;
                _lastOutlineObject = null;


            }

        }
        else if (_lastOutlineObject != null)
        {
            _lastOutlineObject.enabled = false;
            _lastOutlineObject = null;

        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out _hit, _maxDistanceRay, LayerMask.GetMask("DraggableObject")))
            {
                if (_hit.collider.TryGetComponent(out DraggableObject draggableObject))
                {
                    draggableObject.StartFollowingObject();
                    _currentlyDraggedObject = draggableObject;
                }
            }

        }

        if (_currentlyDraggedObject != null)
        {
            Vector3 targetPosition = _playerCamera.transform.position + _playerCamera.transform.forward * _draggableObjectDistance;
            _currentlyDraggedObject.SetTargetPosition(targetPosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_currentlyDraggedObject != null)
            {
                _currentlyDraggedObject.StopFollowingObject();
                _currentlyDraggedObject = null;
            }
        }

    }


    private void Interact() // �������������� � ������
    {
        if (_hit.transform != null && _hit.transform.GetComponent<Door>()) //���� �� ����� ����� � �������� �� ������ F, �� ��������� �������� "OpenDoor"/"OpenClose"
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.yellow);
            if (Input.GetKeyDown(KeyCode.F))
            {
                _hit.transform.GetComponent<Door>().Open();
            }
        }

    }

}
