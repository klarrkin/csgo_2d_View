using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Windows.Media;
using DemoInfo;
using System.Windows;

namespace _2dCS.Objects.Canvas {
	public class CanvasPlayer : ViewModelBase {

		public Player PlayerDao { get; set; }

		
		private double _ViewY;
		public double ViewY {
			get { return _ViewY; }
			set {
				if (_ViewY != value) {
					this._ViewY = value;
					this.RaisePropertyChanged("ViewY");
				}
			}
		}
    

		private double _ViewX;
		public double ViewX {
			get { return _ViewX; }
			set {
				if (_ViewX != value) {
					this._ViewX = value;
					this.RaisePropertyChanged("ViewX");
				}
			}
		}
    

		private int _Radius;
		public int Radius {
			get { return _Radius; }
			set {
				if (_Radius != value) {
					this._Radius = value;
					this.RaisePropertyChanged("Radius");
				}
			}
		}
    
		private Brush  _Color;
		public Brush  Color {
			get { return _Color; }
			set {
				if (_Color != value) {
					this._Color = value;
					this.RaisePropertyChanged("Color");
				}
			}
		}
		
		private string _Bez;
		public string Bez {
			get { return _Bez; }
			set {
				if (_Bez != value) {
					this._Bez = value;
					this.RaisePropertyChanged("Bez");
				}
			}
		}
    
		
		private double _YPosition;
		public double YPosition {
			get { return _YPosition; }
			set {
				if (_YPosition != value) {
					this._YPosition = value;
					this.RaisePropertyChanged("YPosition");
				}
			}
		}
    

		private double _XPosition;
		public double XPosition {
			get { return _XPosition; }
			set {
				if (_XPosition != value) {
					this._XPosition = value;
					this.RaisePropertyChanged("XPosition");
				}
			}
		}

		private Visibility _Visibility;
		public Visibility Visibility {
			get { return _Visibility; }
			set {
				if (_Visibility != value) {
					this._Visibility = value;
					this.RaisePropertyChanged("Visibility");
				}
			}
		}

		
		private string _EllipseFormel;
		public string EllipseFormel {
			get { return _EllipseFormel; }
			set {
				if (_EllipseFormel != value) {
					this._EllipseFormel = value;
					this.RaisePropertyChanged("EllipseFormel");
				}
			}
		}

		
		private int _Health;
		public int Health {
			get { return _Health; }
			set {
				if (_Health != value) {
					this._Health = value;
					//this.BuildEllipse();
				}
			}
		}
	

		private void BuildEllipse() {
			int radius = Radius;
			double arc = this.Health / 100.0 *360;
			double xPos = radius * Math.Sin(45);
			double yPos = radius * Math.Cos(45);

			EllipseFormel = String.Format(
				new System.Globalization.CultureInfo("en-US"),
				"M{0},{1} L{0},0 A{2},{2} 0 0 1 {3},{4} z",
				radius,				// x0
				-radius,				// y0
				radius,				// radius
				xPos + radius,		// x1
				yPos - radius		// y1
				);
		}

    
	}
}
