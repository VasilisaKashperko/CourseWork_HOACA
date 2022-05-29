using HOAChairmanAssistant.Model;
using System;
using System.Globalization;
using System.Windows.Data;

namespace HOAChairmanAssistant.Helpers.Converters
{
    class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
    object parameter, CultureInfo culture)
        {
            if (value == null) return "";
            if (value is OwnerStatus)
            {
                switch ((OwnerStatus)value)
                {
                    case OwnerStatus.Lives:
                        {
                            return "Проживает";
                        }
                    case OwnerStatus.Rents:
                        {
                            return "Сдает";
                        }
                }
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {

            if (value == null) return "";
            switch (value.ToString())
            {
                case "Проживает":
                    {
                        return OwnerStatus.Lives;
                    }
                case "Сдает":
                    {
                        return OwnerStatus.Rents;
                    }
            }
            return null;
        }
    }
}
