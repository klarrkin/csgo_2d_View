using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media.Imaging;

namespace _2dCS.Converter {
	public class StringToImageConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value.GetType() != typeof(string)) {
				throw new InvalidOperationException("The value must be a string");
			}

			return new BitmapImage(new Uri((string)value, UriKind.Relative));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			return null;
		}
	}
}
