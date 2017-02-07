using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Windows.Media;
using DemoInfo;

namespace _2dCS.Objects.Canvas {
	public class StatusPlayer : ViewModelBase {

		public Player PlayerDao { get; set; }

		
		private bool _HasHelmet;
		public bool HasHelmet {
			get { return _HasHelmet; }
			set {
				if (_HasHelmet != value) {
					this._HasHelmet = value;
					this.RaisePropertyChanged("HasHelmet");
				}
			}
		}
    

		private bool _HasArmor;
		public bool HasArmor {
			get { return _HasArmor; }
			set {
				if (_HasArmor != value) {
					this._HasArmor = value;
					this.RaisePropertyChanged("HasArmor");
				}
			}
		}
    

		private WeaponType _WeaponType;
		public WeaponType WeaponType {
			get { return _WeaponType; }
			set {
				if (_WeaponType != value) {
					this._WeaponType = value;
					this.RaisePropertyChanged("WeaponType");
				}
			}
		}
    
		private int _Kills;
		public int Kills {
			get { return _Kills; }
			set {
				if (_Kills != value) {
					this._Kills = value;
					this.RaisePropertyChanged("Kills");
				}
			}
		}

		private int _Money;
		public int Money {
			get { return _Money; }
			set {
				if (_Money != value) {
					this._Money = value;
					this.RaisePropertyChanged("Money");
				}
			}
		}
    

		private int _Health;
		public int Health {
			get { return _Health; }
			set {
				if (_Health != value) {
					this._Health = value;
					this.RaisePropertyChanged("Health");
				}
			}
		}
    
		
		private string _Waffe;
		public string Waffe {
			get { return _Waffe; }
			set {
				if (_Waffe != value) {
					this._Waffe = value;
					this.RaisePropertyChanged("Waffe");
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
    
	}
}
