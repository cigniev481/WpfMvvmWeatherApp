using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfMvvmWeatherApp.Attribuites
{
    class GeoCoordinateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string coordinateString)
            {
                var isParsed = double.TryParse(coordinateString, out double coordinate);
                
                if (!isParsed)
                    return false;

                return coordinate >= -180 && coordinate <= 180;
            }
            return false;
        }
    }
}
