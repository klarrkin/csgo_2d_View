using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Windows;

namespace _2dCS.Objects {
	public class CSMap : ViewModelBase {


		public CSMap(string name) {
			this.Name = name;
		}

		public int PlayerSize { get; set; }


		
		private string _PathIcon;
		public string PathIcon {
			get { return _PathIcon; }
			set {
				if (_PathIcon != value) {
					this._PathIcon = value;
					this.RaisePropertyChanged("PathIcon");
				}
			}
		}
    

		private string _PathPicture;
		public string PathPicture {
			get { return _PathPicture; }
			set {
				if (_PathPicture != value) {
					this._PathPicture = value;
					this.RaisePropertyChanged("PathPicture");

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
					this.PathPicture = @"maps\" + value + ".png";
					this.PathIcon= @"icons\" + value + ".png";
					this.ReadSettings(@"maps\" + value + ".size");
				}
			}
		}

		public double XOffset { get; set; }
		public double YOffset { get; set; }
		public double XSize { get; set; }
		public double YSize { get; set; }

		private void ReadSettings(string fileName) {
			string line;
			System.IO.StreamReader file = null;
			try {
				 file = new System.IO.StreamReader(fileName);
				while ((line = file.ReadLine()) != null) {
					string[] parts = line.Split('=');
					if (parts[0] == "offset") {
						string[] arOffset = parts[1].Split(',');
						this.XOffset = Int32.Parse(arOffset[0]);
						this.YOffset = Int32.Parse(arOffset[1]);
					}
					if (parts[0] == "size") {
						string[] arSize = parts[1].Split(',');
						this.XSize = Int32.Parse(arSize[0]);
						this.YSize = Int32.Parse(arSize[1]);
					}
					if (parts[0] == "PlayerSize") {
						this.PlayerSize = Int32.Parse(parts[1]);
	
					}
				}
			} catch (Exception e) {
				MessageBox.Show("Unbekannte Map. Es werden nur die Standard-Maps supportet.");
			} finally {
				if (file != null) {
					file.Close();
				}
			}
		}
	}
}
