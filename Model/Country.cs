using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Nuntius.Model
{
    class Country
    {
        public string Code { get; set; }
        public string ShortName { get; set; }
        public string CountryName { get; set; }
        public string FillNumber { get; set; }
    }
}