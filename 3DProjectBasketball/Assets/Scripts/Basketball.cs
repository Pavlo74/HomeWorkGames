using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    [SerializeField] Transform _ball;//м€ч
    [SerializeField] Transform _arms;//руки
    [SerializeField] Transform _posOverhead;//м€ч в руках
    [SerializeField] Transform _posDribble;//м€ч на земл≥
    [SerializeField] Transform _target;//кидок

    private bool _isBallInHands = true;//€кщо м€ч в руках
    private bool _isBallFlying = false;
    private float _t = 0;//в≥дл≥к часу польоту
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));//керуванн€ клав≥шами
        transform.position += direction * _speed * Time.deltaTime;
        transform.LookAt(transform.position + direction);//зм≥нна напр€мку персонажа

        if(_isBallInHands)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                _ball.position = _posOverhead.position;
                _arms.localEulerAngles = Vector3.right * 180;

                transform.LookAt(_target.position);//при нажатт≥ на проб≥л, дивитис€ на к≥льце
            }
            else
            {
                _ball.position = _posDribble.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5));//дл€ прижк≥в м€ча
                _arms.localEulerAngles = Vector3.right * 0;
            }

            if (Input.GetKeyUp(KeyCode.Space))//при в≥дпускан≥ проб≥лу, м€ч не в руках, а в польот≥ ≥ починаЇтьс€ в≥дл≥к часу
            {
                _isBallInHands = false;
                _isBallFlying = true;
                _t = 0;
            }
        }

       

        if(_isBallFlying)//€кщо м€ч летить
        {
            _t += Time.deltaTime;
            float duration = 0.5f;//тривал≥сть
            float t01 = _t / duration;//час польоту под≥лити на тривал≥сть

            Vector3 a = _posOverhead.position;
            Vector3 b = _target.position;
            Vector3 pos = Vector3.Lerp(a, b, t01);

            Vector3 arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f);//рух по дуз≥
            _ball.position = pos + arc;

            if(t01 >= 1)//€к виконуЇтьс€ умова то м€ч перестаЇ лет≥ти
            {
                _isBallFlying = false;
                _ball.GetComponent<Rigidbody>().isKinematic = false;//реал≥стичне пад≥нн€
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!_isBallInHands && !_isBallFlying)
        {
            _isBallInHands=true;
            _ball.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
