using Appear.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data
{
    public static class EnumHelper
    {
        public static double ToDouble(this DisplayWidth displayWidth)
        {
            switch (displayWidth)
            {
                case DisplayWidth.Large:
                    return 150.0;
                case DisplayWidth.X_Large:
                    return 200.0;
                case DisplayWidth.Small:
                    return 50.0;
                case DisplayWidth.Standard:
                default:
                    return 100.0;
            }
        }
    }
}
