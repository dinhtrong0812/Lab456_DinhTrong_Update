using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using componentModel.DataAnnotations;


namespace BigSchool.ViewModels
{
    public class FutureDate : ValidationAttribute 
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "dd/M/yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out DateTime);
            return(isValid && datetime > DateTime.Now);

        }
    }
}