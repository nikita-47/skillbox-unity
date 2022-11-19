using System;

public struct PinsState
{
    public PinsState(int first, int second, int third)
    {
        _first = first;
        _second = second;
        _third = third;
    }

    private int _first;
    private int _second;
    private int _third;

    public int First
    {
        get => _first;
        private set {
            _first = value;
            if (_first is > 9 or < 1)
            {
                throw new Exception();
            }
        }
    }

    public int Second
    {
        get => _second;
        private set {
            _second = value;
            if (_second is > 9 or < 1)
            {
                throw new Exception();
            }
        }
    }

    public int Third
    {
        get => _third;
        private set {
            _third = value;
            if (_third is > 9 or < 1)
            {
                throw new Exception();
            }
        }
    }

    public void UpdatePins(int first, int second, int third)
    {
        PinsState prevState = this;

        try
        {
            First += first;
            Second += second;
            Third += third;
        }
        catch (Exception)
        {
            this = prevState;
        }
    }
}
