﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PreyPredator2.Contracts
{
     public interface IDisplayable
    {
        void DisplayOn(Canvas canvas);
        void StopDisplaying();
        void UpdateDisplay();
    }
}
