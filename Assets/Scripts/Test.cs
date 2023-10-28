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
    private int _currentMonth;
    private DateTime _currentDate;
    private int num = 35;
    private int _temporary = 1;
    private List<Transform> _slotList = new List<Transform>();

    private void Awake()
    {
        _currentDate = DateTime.Now;
        _currentMonth = _currentDate.Month;
        _dateText.text = string.Format("{0}/{1}", _currentDate.Year, _currentDate.Month);
        InitCalendarSlot();
        SetCalendar();
        Debug.Log(_currentDate.Day);
    }

    public void InitCalendarSlot()
    {
        for (int i = 0; i < num; i++)
        {
            Transform newSlot = Instantiate(_dateSlot, _dateParent);
            newSlot.GetChild(0).GetComponent<Text>().text = " ";
            _slotList.Add(newSlot);
        }
    }

    public void SetCalendar()
    {
        //找到当月的一号是周几
        DateTime firstDayOfMonth = new DateTime(_currentDate.Year, _currentDate.Month, 1);
        int firstDay = (int)firstDayOfMonth.DayOfWeek;
        //获取这个月一共有多少天
        int dayInMonth = DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);
        Debug.Log(dayInMonth);
        //制作日历
        for (int i = firstDay; i < dayInMonth + firstDay; ++i)
        {
            _slotList[i].GetChild(0).GetComponent<Text>().text = _temporary.ToString();
            if (i == (int)_currentDate.Day)
            {
                _slotList[i + firstDay - 1].GetComponent<Image>().color = Color.yellow;
            }
            _temporary++;
        }

        
    }
}
