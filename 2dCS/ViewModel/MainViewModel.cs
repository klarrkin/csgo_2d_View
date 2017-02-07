using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System;
using System.IO;
using DemoInfo;
using System.Collections.ObjectModel;
using _2dCS.Objects;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;
using _2dCS.Objects.Canvas;
using System.Windows.Media;
using System.Collections.Generic;

namespace _2dCS.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
		 private static Brush COL_T = new SolidColorBrush(Colors.Red);
		 private static Brush COL_CT = new SolidColorBrush(Colors.Blue);
		 private static Brush COL_DEAD = new SolidColorBrush(Colors.Gray);

		 public Dictionary<long, CanvasPlayer> PlCanDict { get; set; }
		 public Dictionary<long, StatusPlayer> PlCTDict { get; set; }
		 public Dictionary<long, StatusPlayer> PlTDict { get; set; }

		 private static string NORMAL_SPEED = "1x";
		 private static string DOUBLE_SPEED = "2x";
		 private static string QUAD_SPEED = "4x";
		 private static string OCTA_SPEED = "8x";
		 private static string SECHSTIME_SPEED = "16x";
		 
		 private enum Speed {NORMAL=1, DOUBLE=2,QUAD=4,OCTA=8,SECHSTIME=16};
		 

		 public double SizeX { get; set; }
		 public double SizeY { get; set; }

		 public DispatcherTimer Timer { get; set; }
		 public ICommand Open { get; set; }
		 public ICommand Start { get; set; }
		 public ICommand Stop { get; set; }
		 public ICommand Faster { get; set; }
		 public DemoParser  Parser { get; set; }

		 public double FFSpeeder { get; set; }
		 public double OriginTickSpeedMs { get; set; }
		 public int TickModulo { get; set; }
		 
		 private string _Debug;
		 public string Debug {
			 get { return _Debug; }
			 set {
				 if (_Debug != value) {
					 this._Debug = value;
					 this.RaisePropertyChanged("Debug");
				 }
			 }
		 }


		 private List<StatusPlayer> _CTPlayer;
		 public List<StatusPlayer> CTPlayer {
			 get { return _CTPlayer; }
			 set {
				 if (_CTPlayer != value) {
					 this._CTPlayer = value;
					 this.RaisePropertyChanged("CTPlayer");
				 }
			 }
		 }


		 private List<StatusPlayer> _TerrorPlayer;
		 public List<StatusPlayer> TerrorPlayer {
			 get { return _TerrorPlayer; }
			 set {
				 if (_TerrorPlayer != value) {
					 this._TerrorPlayer = value;
					 this.RaisePropertyChanged("TerrorPlayer");
				 }
			 }
		 }

		 private List<_2dCS.Objects.Canvas.CanvasPlayer> _CanvasPlayer;
		 public List<_2dCS.Objects.Canvas.CanvasPlayer> CanvasPlayer {
			 get { return _CanvasPlayer; }
			 set {
				 if (_CanvasPlayer != value) {
					 this._CanvasPlayer = value;
					 this.RaisePropertyChanged("CanvasPlayer");
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
    
		 private bool _Running;
		 public bool Running {
			 get { return _Running; }
			 set {
				 if (_Running != value) {
					 this._Running = value;
					 this.RaisePropertyChanged("Running");
				 }
			 }
		 }
    
		 private CSMap _Map;
		 public CSMap Map {
			 get { return _Map; }
			 set {
				 if (_Map != value) {
					 this._Map = value;
					 this.RaisePropertyChanged("Map");
				 }
			 }
		 }


		 
		 private int _ScoreT;
		 public int ScoreT {
			 get { return _ScoreT; }
			 set {
				 if (_ScoreT != value) {
					 this._ScoreT = value;
					 this.RaisePropertyChanged("ScoreT");
				 }
			 }
		 }
    
		 
		 private int _ScoreCT;
		 public int ScoreCT {
			 get { return _ScoreCT; }
			 set {
				 if (_ScoreCT != value) {
					 this._ScoreCT = value;
					 this.RaisePropertyChanged("ScoreCT");
				 }
			 }
		 }
		 		 
		 private string _NameCT;
		 public string NameCT {
			 get { return _NameCT; }
			 set {
				 if (_NameCT != value) {
					 this._NameCT = value;
					 this.RaisePropertyChanged("NameCT");
				 }
			 }
		 }
		 
		 private string _NameT;
		 public string NameT {
			 get { return _NameT; }
			 set {
				 if (_NameT != value) {
					 this._NameT = value;
					 this.RaisePropertyChanged("NameT");
				 }
			 }
		 }

		 private ObservableCollection<CSEvent> _Events;
		 public ObservableCollection<CSEvent> Events {
			 get { return _Events; }
			 set {
				 if (_Events != value) {
					 this._Events = value;
					 this.RaisePropertyChanged("Events");
				 }
			 }
		 }

		 private string _SpeedText = NORMAL_SPEED;
		 public string SpeedText {
			 get { return _SpeedText; }
			 set {
				 if (_SpeedText != value) {
					 this._SpeedText = value;
					 this.RaisePropertyChanged("SpeedText");
				 }
			 }
		 }

		 
		 private bool _HasStarted;
		 public bool HasStarted {
			 get { return _HasStarted; }
			 set {
				 if (_HasStarted != value) {
					 this._HasStarted = value;
					 this.RaisePropertyChanged("HasStarted");
				 }
			 }
		 }
    
		 public MainViewModel(){
			 this.Start = new RelayCommand(StartCmd_Executed, (() => { return !this.Running; }));
			 this.Stop = new RelayCommand(StopCmd_Executed, (() => { return this.Running; }));
			 this.Faster = new RelayCommand(FasterCmd_Executed, PlayStatusCmd_CanExecute);
			 this.Open = new RelayCommand(OpenCmd_Executed, OpenCmd_CanExecute);
			 this.Events = new ObservableCollection<CSEvent>();

			 this.Map = new CSMap("unknown");
			 this.FFSpeeder = (int)Speed.NORMAL;

			 if (IsInDesignMode) {
			     // Code runs in Blend --> create design time data.
			 }
			 else {
			     
			 }
        }

	
		 public void RunTick(object sender, EventArgs e) {
			 DateTime beginn = DateTime.Now;
			 this.Parser.ParseNextTick();
			 DateTime end = DateTime.Now;

			 double parseDuration = (end - beginn).TotalMilliseconds;
			 double delayMs = (OriginTickSpeedMs - parseDuration) / this.FFSpeeder;
			 if (delayMs <= 0) {
				 delayMs = 1;
			 }
			 //this.Debug = "" + parseDuration + "ms";
			 if (this.Timer != null) {
				 this.Timer.Interval = TimeSpan.FromMilliseconds(delayMs);
			 }
			 this.Time = TimeSpan.FromMilliseconds(this.Parser.CurrentTime * 1000);
		 }
		  

		 private void StartCmd_Executed() {
			 this.Timer = new DispatcherTimer();
			 this.Timer.Interval = TimeSpan.FromMilliseconds(100);
			 this.Timer.Tick += RunTick;
			 this.Timer.Start();
			 this.Running = true;
			 this.InitPlayers();
		 }

		private void StopCmd_Executed() {
			 this.Timer.Stop();
			 this.Timer = null;
			 this.Running = false;
			
		 }

		 private void FasterCmd_Executed() {
			 if (this.SpeedText == NORMAL_SPEED) {
				 this.SpeedText = DOUBLE_SPEED;
				 this.FFSpeeder = (int)Speed.DOUBLE;
			 } else if (this.SpeedText == DOUBLE_SPEED) {
				 this.SpeedText = QUAD_SPEED;
				 this.FFSpeeder = (int)Speed.QUAD;
			 } else if (this.SpeedText == QUAD_SPEED) {
				 this.SpeedText = OCTA_SPEED;
				 this.FFSpeeder = (int)Speed.OCTA;
			 } else if (this.SpeedText == OCTA_SPEED) {
				 this.SpeedText = SECHSTIME_SPEED;
				 this.FFSpeeder = (int)Speed.SECHSTIME;
			 } else if (this.SpeedText == SECHSTIME_SPEED) {
				 this.SpeedText = NORMAL_SPEED;
				 this.FFSpeeder = (int)Speed.NORMAL;
			 }
		 }

		 private bool PlayStatusCmd_CanExecute() {
			 return true;
		 }

		 private bool SpeedCmd_CanExecute() {
			 return true;
		 }

		  private bool OpenCmd_CanExecute() {
			  return true;
		  }

		  private void OpenCmd_Executed() {
			  try {
				  Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
				  openFileDialog.Filter = "Demo files (*.dem)|*.dem|All files (*.*)|*.*";
				  openFileDialog.InitialDirectory = KnownFolders.GetPath(KnownFolder.Downloads);

				  if (openFileDialog.ShowDialog() == true) {
					  string fileName = openFileDialog.FileName;
					  this.InitialParser(fileName);
				  }
			  } catch (Exception e) {
				  MessageBox.Show(e.ToString());
			  }
		  }

		  private void InitialParser(string filePath) {
			  this.Events = new ObservableCollection<CSEvent>();

			  FileStream fs = File.OpenRead(filePath);
			  this.Parser = new DemoParser(fs);
				this.Parser.TickDone += new EventHandler<TickDoneEventArgs>(parser_TickDone);
				this.Parser.MatchStarted += new EventHandler<MatchStartedEventArgs>(parser_MatchStarted);
				this.Parser.PlayerKilled += new EventHandler<PlayerKilledEventArgs>(HandlePlayerKilled);
				this.Parser.WeaponFired += new EventHandler<WeaponFiredEventArgs>(HandleWeaponFired);
				this.Parser.RoundStart += new EventHandler<RoundStartedEventArgs>(HandleRoundStarted);
				this.Parser.MatchStarted += new EventHandler<MatchStartedEventArgs>(HandleMatchStarted);
				this.Parser.PlayerHurt += new EventHandler<PlayerHurtEventArgs>(HandlePlayerHurt);
				this.Parser.PlayerTeam += new EventHandler<PlayerTeamEventArgs>(HandleTeamjoin);
				this.Parser.ParseHeader();

				this.HasStarted = false;
				this.Map = new CSMap(this.Parser.Map);
				this.Time = new TimeSpan();

				this.calculatedTicks = 0;
				this.firstPlayerFound = false;
				this.TickModulo = (int)Math.Round(this.Parser.TickRate / 32);
				this.OriginTickSpeedMs = (1000.0 / this.Parser.TickRate);
				this.InitPlayers();
				this.UpdateStatus();

				this.Debug = "speed in ms: "+this.OriginTickSpeedMs;
				CSEvent ev = new CSEvent();
				ev.Bez = "Map geladen.";
				ev.Time = this.Time;
				this.Events.Insert(0, ev);
		  }
		  private void HandlePlayerHurt(object sender, PlayerHurtEventArgs e) {
			  if (e.HealthDamage >= 50 && e.Player.IsAlive) {
				  CSEvent ev = new CSEvent();
				  ev.Bez = String.Format("{0} trifft {1} am {2} für {3} HP", (e.Attacker!= null)?e.Attacker.Name:"unbekannt", e.Player.Name, e.Hitgroup, e.HealthDamage);
				  ev.Time = this.Time;
				  this.Events.Insert(0, ev);
			  }
		  }

		  private void HandleTeamjoin(object sender, PlayerTeamEventArgs e) {
			  this.InitPlayers();
			  this.HasStarted = true;
			  CSEvent ev = new CSEvent();
			  ev.Bez = String.Format("{0} ist team {1} beigetreten.", "unbekannt", e.NewTeam+"");
			  ev.Time = this.Time;
			  this.Events.Insert(0, ev);
		  }

		  private void HandleMatchStarted(object sender, MatchStartedEventArgs e) {
			  this.HasStarted = true;
			  CSEvent ev = new CSEvent();
			  ev.Bez = "Match gestartet.";
			  ev.Time = this.Time;
			  this.Events.Insert(0, ev);
			  //this.InitPlayers();
			  this.UpdateStatus();
		  }

		  private void HandleRoundStarted(object sender,RoundStartedEventArgs e) {
			  CSEvent ev = new CSEvent();
			  ev.Bez = "Runde gestartet.";
			  ev.Time = this.Time;
			  this.Events.Insert(0, ev);

			  this.InitPlayers();
			  this.UpdateStatus();
		  }

		  private bool firstPlayerFound = false;
		  private long calculatedTicks = 0;
		  private void parser_TickDone(object sender, TickDoneEventArgs e) {
			  if (firstPlayerFound) {
				  if (this.Parser.CurrentTick % this.TickModulo == 0) {
					  
					  if (calculatedTicks % 3 == 0) {
						  this.UpdateAllPlayerData();
					  } else {
						  this.UpdatePlayerPosition();
					  }
					  calculatedTicks++;
				  }
			  } else {
				  this.InitPlayers();
			  }
		  }

		  private void UpdateStatus() {
			  this.ScoreCT = this.Parser.CTScore;
			  this.ScoreT = this.Parser.TScore;

			  this.NameCT = this.Parser.CTClanName;
			  this.NameT = this.Parser.TClanName;
		  }
		  //float biggerVectorComp = ((player.ViewDirectionX>player.ViewDirectionY)?player.ViewDirectionX:player.ViewDirectionY)/20;
		  //cvPlayer.ViewX = player.ViewDirectionX / biggerVectorComp;
		  //cvPlayer.ViewY = player.ViewDirectionY / biggerVectorComp;
		  //cvPlayer.Radius = 10;//(int) (this.SizeY * (Map.PlayerSize / this.Map.XSize));

		  private void InitPlayers() {
			  List<CanvasPlayer> canvPl = new List<CanvasPlayer>();
			  List<StatusPlayer> terPl = new List<StatusPlayer>();
			  List<StatusPlayer> ctPl = new List<StatusPlayer>();

			  this.PlCanDict = new Dictionary<long, CanvasPlayer>();
			  this.PlCTDict = new Dictionary<long, StatusPlayer>();
			  this.PlTDict = new Dictionary<long, StatusPlayer>();


			  int i = 0;
			  foreach (var player in this.Parser.PlayingParticipants) {
				  if (!this.PlCanDict.ContainsKey(player.SteamID) && player.SteamID > 0) {
					  firstPlayerFound = true;

					  CanvasPlayer cvPlayer = new CanvasPlayer();
					  cvPlayer.Bez = "" + i;
					  cvPlayer.Radius = 10;
					  cvPlayer.XPosition = -this.SizeX * (player.Position.X - this.Map.XOffset) / this.Map.XSize;
					  cvPlayer.YPosition = this.SizeY * (player.Position.Y + this.Map.YOffset) / this.Map.YSize;
					  cvPlayer.Health = player.HP;

					  cvPlayer.PlayerDao = player;
					  canvPl.Add(cvPlayer);
					  this.PlCanDict.Add(player.SteamID, cvPlayer);

					  StatusPlayer stPl = new StatusPlayer();
					  stPl.PlayerDao = player;
					  stPl.Health = player.HP;
					  stPl.Kills = player.AdditionaInformations.Kills;
					  stPl.Money = player.Money;
					  stPl.Waffe = player.Weapons.ToString();
					  stPl.Bez = "" + i;
					  stPl.Name = player.Name;

					  if (player.Team == Team.Terrorist) {
						  terPl.Add(stPl);
						  this.PlTDict.Add(player.SteamID, stPl);

						  if (player.IsAlive) {
							  cvPlayer.Color = COL_T;
							  stPl.Color = COL_T;
						  }
					  }
					  if (player.Team == Team.CounterTerrorist) {
						  ctPl.Add(stPl);
						  this.PlCTDict.Add(player.SteamID, stPl);

						  if (player.IsAlive) {
							  cvPlayer.Color = COL_CT;
							  stPl.Color = COL_CT;
						  }

					  }
					  if (!player.IsAlive) {
						  cvPlayer.Color = COL_DEAD;
						  stPl.Color = COL_DEAD;
					  }
					  i++;
				  }
			  }
			  this.CanvasPlayer = canvPl;
			  this.TerrorPlayer = terPl;
			  this.CTPlayer = ctPl;

		  }


		  private void UpdatePlayerPosition() {
			  foreach (var player in this.Parser.PlayingParticipants) {
				  if (this.PlCanDict.ContainsKey(player.SteamID)) {
					  CanvasPlayer cvPlayer = this.PlCanDict[player.SteamID];

					  cvPlayer.XPosition = -this.SizeX * (player.Position.X - this.Map.XOffset) / this.Map.XSize;
					  cvPlayer.YPosition = this.SizeY * (player.Position.Y + this.Map.YOffset) / this.Map.YSize;
				  }
			  }
		  }
		  private void UpdateAllPlayerData() {
			  foreach (var player in this.Parser.PlayingParticipants) {
				  if (this.PlCanDict.ContainsKey(player.SteamID)) {
					  CanvasPlayer cvPlayer = this.PlCanDict[player.SteamID];

					  cvPlayer.XPosition = -this.SizeX * (player.Position.X - this.Map.XOffset) / this.Map.XSize;
					  cvPlayer.YPosition = this.SizeY * (player.Position.Y + this.Map.YOffset) / this.Map.YSize;
					  cvPlayer.Health = player.HP;

					  StatusPlayer stPl;
					  if (this.PlTDict.ContainsKey(player.SteamID)) {
						  stPl = this.PlTDict[player.SteamID];
					  } else {
						  stPl = this.PlCTDict[player.SteamID];
					  }

					  if (player.Team == Team.Terrorist) {
						  if (player.IsAlive) {
							  cvPlayer.Color = COL_T;
							  stPl.Color = COL_T;
						  }
					  }
					  if (player.Team == Team.CounterTerrorist) {
						  if (player.IsAlive) {
							  cvPlayer.Color = COL_CT;
							  stPl.Color = COL_CT;
						  }
					  }
					  if (!player.IsAlive) {
						  cvPlayer.Color = COL_DEAD;
						  stPl.Color = COL_DEAD;
						  cvPlayer.Visibility = Visibility.Collapsed;
					  } else {
						  cvPlayer.Visibility = Visibility.Visible;
					  }

					  stPl.PlayerDao = player;
					  stPl.Health = player.HP;
					  stPl.Kills = player.AdditionaInformations.Kills;
					  stPl.Money = player.Money;
					  stPl.Waffe = player.Weapons.ToString();

					  stPl.WeaponType = WeaponType.P;
					  foreach (var weapon in player.Weapons) {
						  if (weapon.Class == EquipmentClass.SMG && stPl.WeaponType != WeaponType.RIFLE) {
							  stPl.WeaponType = WeaponType.SMG;
						  }
						  if (weapon.Class == EquipmentClass.Rifle) {
							  stPl.WeaponType = WeaponType.RIFLE;
						  }
					  }
					  stPl.HasArmor = player.Armor > 0;
					  stPl.HasHelmet = player.HasHelmet;
				  }
			  }
		  }

		  private void parser_MatchStarted(object sender, MatchStartedEventArgs e) {
			  CSEvent ev = new CSEvent();
			  ev.Bez = "Demo gestartet.";
			  ev.Time = this.Time;
			  this.Events.Insert(0, ev);
		  }

		  private void HandlePlayerKilled(object sender, PlayerKilledEventArgs e) {
			  CSEvent ev = new CSEvent();
			  ev.Bez = String.Format("{0} tötet {1} mit {2}", e.Killer.Name, e.Victim.Name, e.Weapon.Weapon);
			  ev.Time = this.Time;
			  this.Events.Insert(0,ev);
		  }
		  private void HandleWeaponFired(object sender, WeaponFiredEventArgs e) {
		  }
    }
}