using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SDR.Models
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color c = Color.WhiteSmoke;

            if (value.GetType() == typeof(int))
            {
                int q = (int)value;
                if (q > 0) c = Color.PaleVioletRed ;
                else c = Color.Transparent;
            }

        
            if (value.GetType() == typeof(bool))
            {
                bool q = (bool)value;
                if (q ) c = Color.LightGray;
                else c = Color.Transparent;
            }

            return c;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // You probably don't need this, this is used to convert the other way around
            // so from color to yes no or maybe
            //throw new NotImplementedException();
            return null;
        }

    }

    public class ColorConverterFromHEX: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color c = Color.WhiteSmoke;
            
            if (value != null && value.GetType() == typeof(string))
            {
                c = Color.FromHex(value.ToString());
            }


            return c;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // You probably don't need this, this is used to convert the other way around
            return null;
        }

    }


    public class ColorConverterFromHEXForeColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color cres = Color.Black;
            Color c = Color.WhiteSmoke;

            if (value != null && value.GetType() == typeof(string))
            {
                c = Color.FromHex(value.ToString());
            }


            if (c.R * 0.2126 + c.G * 0.7152 + c.B * 0.0722 > 0.5)
                cres = Color.Black; // bright colors - black font
                
            else
                cres = Color.White; // dark colors - white font

            return cres;


        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // You probably don't need this, this is used to convert the other way around
            return null;
        }

    }




    public class ColorConverterMissioni : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color c = Color.WhiteSmoke;

            if (value.GetType() == typeof(int))
            {
                int q = (int)value;
                if (q == 1) c = Color.LightYellow;
                if (q == 2) c = Color.MistyRose;
                if (q == 3) c = Color.LightGreen;
            }


            return c;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // You probably don't need this, this is used to convert the other way around
            return null;
        }

    }



    public class ColorConverterPosizione : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color c = Color.WhiteSmoke;
            if (value != null && value.GetType() == typeof(string))
            {
                string posizione = (string)value;
                if (!string.IsNullOrEmpty(posizione) && posizione.Length >= 5)
                {
                    string livello = posizione.Substring(4);
                    if (livello == "A") c = Color.DarkBlue;
                    if (livello == "B") c = Color.DarkGreen;
                    if (livello == "C") c = Color.DarkRed;
                    if (livello == "D") c = Color.Purple;
                    if (livello == "E") c = Color.Black;
                    if (livello == "F") c = Color.DarkGoldenrod;
                    if (livello == "G") c = Color.DarkOrange;
                }
            }

            return c;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // You probably don't need this, this is used to convert the other way around
            return null;
        }

    }


    public class ColorConverterPosizioneForeColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color c = Color.Black;

            if (value != null && value.GetType() == typeof(string))
            {
                string posizione = (string)value;
                if (!string.IsNullOrEmpty(posizione) && posizione.Length >= 5)
                {
                    string livello = posizione.Substring(4);
                    if (livello == "A") c = Color.White;
                    if (livello == "B") c = Color.White;
                    if (livello == "C") c = Color.White;
                    if (livello == "D") c = Color.White;
                    if (livello == "E") c = Color.White;
                    if (livello == "F") c = Color.White;
                    if (livello == "G") c = Color.White;
                }
            }

            return c;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // You probably don't need this, this is used to convert the other way around
            return null;
        }

    }
}
