using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject Joystick;
    public GameObject Handler;

    public static Vector2 Direction;

    float _radius;
    Vector2 _currentPos;
    Vector2 _startPos;
    Vector2 _initPos;
    Vector2 _direction;

    void Start()
    {
        _radius = Joystick.GetComponent<RectTransform>().sizeDelta.x / 3;
        _initPos = Joystick.transform.position;
        SetActiveJoystick(false);
    }

    void SetActiveJoystick(bool isActive)
    {
        Joystick.SetActive(isActive);
        Handler.SetActive(isActive);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SetActiveJoystick(true);
        _startPos = Input.mousePosition;
        Joystick.transform.position = _startPos;
        Handler.transform.position = _startPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _currentPos = eventData.position;
        _direction = (_currentPos - _startPos).normalized;
        float distance = (_currentPos - _startPos).sqrMagnitude;

        Vector2 newPos;
        if(distance<_radius)
        {
            newPos = _startPos + (_direction * distance);
        }
        else
        {
            newPos = _startPos + (_direction * _radius);
        }
        Handler.transform.position = newPos;
        Direction = _direction;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _direction = Vector2.zero;
        Joystick.transform.position = _initPos;
        Handler.transform.position = _initPos;
        SetActiveJoystick(false);
        Direction = _direction;
    }
}
