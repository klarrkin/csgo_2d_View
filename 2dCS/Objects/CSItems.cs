using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace _2dCS.Objects {
	public class CSItems :ObservableObject {

		private static int PRIO_MAIN = 5;
		private static int PRIO_SEC = 4;
		private static int PRIO_GREN = 4;
		private static int PRIO_EQ = 4;
		private static int PRIO_WEST= 4;
		private static int PRIOBOMB = 6;

		private int _Priority;
		public int Priority {
			get { return _Priority; }
			set {
				if (_Priority != value) {
					this._Priority = value;
					this.RaisePropertyChanged("Priority");
				}
			}
		}
		
		private string _Name;
		public string Name {
			get { return _Name; }
			set {
				if (_Name != value) {
					this._Name = value;
					this.RaisePropertyChanged("Name");
				}
			}
		}

		private string _Status;
		public string Status {
			get { return _Status; }
			set {
				if (_Status != value) {
					this._Status = value;
					this.RaisePropertyChanged("Status");
				}
			}
		}
	}
}
