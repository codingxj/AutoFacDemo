using System;
using Auto.Interface;

namespace Auto.Services
{
    public class calculator: Icalculator
    {
        public int Plus(int i,int j)
        {
            return i + j;
        }
    }
}
