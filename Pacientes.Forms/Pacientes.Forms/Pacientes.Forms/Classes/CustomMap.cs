﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacientes.Forms.Classes;
using Xamarin.Forms.Maps;

namespace Pacientes.Forms.Classes
{
    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }
    }
}