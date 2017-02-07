using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace _2dCS.Objects {
	public class CSEvent : ObservableObject{
		
		private int _ID;
		public int ID {
			get { return _ID; }
			set {
				if (_ID != value) {
					this._ID = value;
					this.RaisePropertyChanged("ID");
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

		private TimeSpan _Time;
		public TimeSpan Time {
			get { return _Time; }
			set {
				if (_Time != value) {
					this._Time = value;
					this.RaisePropertyChanged("Time");
				}
			}
		}
    
	}
}
