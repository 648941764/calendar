using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private Text _dateText;
    [SerializeField] private Transform _dateParent;
    [SerializeField] private Transform _dateSlot;
    [SerializeField] private Button _reduceBtn, _increseBtn;
    private DateTime _currentDate;
    private int _num = 42;
    private int _temporary = 1;
    private List<Transform> _slotList = new List<Transform>();
    private DateTime _firstDayOfMonth;
    private int _dayInMonth;
    private int _initDay;
    private DateTime _initDate;

    private void Awake()
    {
        _currentDate = DateTime.Now;
        _initDay = _currentDate.Day;
        _initDate = _currentDate;
        _dateText.text = string.Format("{0}/{1}", _currentDate.Year, _currentDate.Month);
        InitCalendarSlot();
        SetCalendar();
        _reduceBtn.GetComponent<Button>().onClick.AddListener(OnReduceBtnClicked);
        _increseBtn.GetComponent<Button>().onClick.AddListener(OnIncreaseBtnClicked);
    }

    public void InitCalendarSlot()
    {
        for (int i = 0; i < _num; i++)
        {
            Transform newSlot = Instantiate(_dateSlot, _dateParent);
            newSlot.GetChild(0).GetComponent<Text>().text = " ";
            _slotList.Add(newSlot);
        }
    }

    private void Update()
    {
        if (_currentDate == _initDate)
        {
            _slotList[_initDay - 1].GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            _slotList[_initDay - 1].GetComponent<Image>().color = Color.clear;
        }
    }

    public void SetCalendar()
    {
        _temporary = 1;
        //找到当月的一号是周几
        _firstDayOfMonth = new DateTime(_currentDate.Year, _currentDate.Month, 1);
        int firstDay = (int)_firstDayOfMonth.DayOfWeek;
        //获取这个月一共有多少天
        _dayInMonth = DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);
        //制作日历
        for (int i = firstDay; i < _dayInMonth + firstDay; ++i)
        {
            _slotList[i].GetChild(0).GetComponent<Text>().text = _temporary.ToString();
            //if (i == (int)_currentDate.Day - 1)
            //{
            //    _slotList[i + firstDay].GetComponent<Image>().color = Color.yellow;
            //}
            _temporary++;
        }
    }

    public void ClearCalendar()
    {
        foreach (Transform slot in _slotList)
        {
            slot.GetChild(0).GetComponent<Text>().text = " ";
        }
    }

    public void OnReduceBtnClicked()
    {
        ClearCalendar();
        if (_currentDate.Month > 1)
        {
            _currentDate = new DateTime(_currentDate.Year, _currentDate.Month - 1, 1);
            SetCalendar();
        }
        else if(_currentDate.Month <= 1)
        {
            _currentDate = new DateTime(_currentDate.Year - 1, 12, _currentDate.Day);
            SetCalendar();
        }
        _dateText.text = string.Format("{0}/{1}", _currentDate.Year, _currentDate.Month);
    }

    public void OnIncreaseBtnClicked()
    {
        ClearCalendar();
        if (_currentDate.Month == 12)
        {
            _currentDate = new DateTime(_currentDate.Year + 1, 1, _currentDate.Day);
            SetCalendar();
            Debug.Log("执行加年份");
        }
        else if (_currentDate.Month < 12)
        {
            _currentDate = new DateTime(_currentDate.Year, _currentDate.Month + 1, 1);
            SetCalendar();
            Debug.Log("执行加月份");
        }
        _dateText.text = string.Format("{0}/{1}", _currentDate.Year, _currentDate.Month);
    }
}
