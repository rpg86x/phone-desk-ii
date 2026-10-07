using System;using System.Drawing;using System.Drawing.Drawing2D;using System.Diagnostics;using System.IO;using System.Windows.Forms;
class Phone2:Form{
 Panel body;Label hint;string meter=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),@"ChatGPT\Apps\codex-meter\windows\Codex Meter.exe");
 public Phone2(){string chosen="Oppo Find X5 Pro";try{var mf=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"pds-model2.txt");if(File.Exists(mf))chosen=File.ReadAllText(mf).Trim();}catch{};var wa=Screen.PrimaryScreen.WorkingArea;double ratio=1.0;try{var f=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"phone2-ratio.txt");if(File.Exists(f))double.TryParse(File.ReadAllText(f),System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out ratio);}catch{};Text="Phone Desk II — "+chosen;FormBorderStyle=FormBorderStyle.None;BackColor=Color.Silver;ForeColor=Color.White;Size=new Size((int)(Screen.PrimaryScreen.WorkingArea.Height*ratio),Screen.PrimaryScreen.WorkingArea.Height);Location=new Point(wa.Right-Width,wa.Top);MinimumSize=new Size(350,700);StartPosition=FormStartPosition.CenterScreen;Padding=new Padding(14,62,14,45);Font=new Font("Segoe UI",10);
 body=new Panel{Dock=DockStyle.Fill,BackColor=Color.FromArgb(24,30,43)};Controls.Add(body);var label=new Label{Text="OPPO FIND X5 PRO",ForeColor=Color.FromArgb(92,210,220),Font=new Font("Segoe UI",12,FontStyle.Bold),AutoSize=true,Left=25,Top=55};body.Controls.Add(label);hint=new Label{Text="Tweede telefoon\n\nGebruik het onderste menu voor venstermodus.\n\nCODEX Meter kan hiernaast worden gestart.",ForeColor=Color.Silver,AutoSize=true,Left=25,Top=100};body.Controls.Add(hint);
 var launch=new Button{Text="CODEX Meter openen",Width=250,Height=52,Left=25,Top=210,FlatStyle=FlatStyle.Flat,BackColor=Color.FromArgb(49,98,119),ForeColor=Color.White};launch.Click+=(s,e)=>Launch();body.Controls.Add(launch);
 var menu=new ContextMenuStrip();foreach(string x in new[]{"Altijd op voorgrond","Gebalanceerd","Altijd op achtergrond"}){int n=menu.Items.Count;menu.Items.Add(x,null,(s,e)=>{TopMost=n==0;});}menu.Items.Add(new ToolStripSeparator());menu.Items.Add("CODEX Meter starten",null,(s,e)=>Launch());menu.Items.Add("Telefoon sluiten",null,(s,e)=>Close());ContextMenuStrip=menu;
 MouseDown+=(s,e)=>{if(e.Button==MouseButtons.Left&&e.Y<62&&e.X>Width-52)Close();else if(e.Button==MouseButtons.Left&&e.Y<62&&e.X>Width-90)WindowState=FormWindowState.Minimized;else if(e.Button==MouseButtons.Left&&e.Y<62){ReleaseCapture();SendMessage(Handle,0xA1,new IntPtr(2),IntPtr.Zero);}else if(e.Button==MouseButtons.Left&&e.Y>Height-45)menu.Show(this,e.Location);};Resize+=(s,e)=>Round();Shown+=(s,e)=>Round();}
 [System.Runtime.InteropServices.DllImport("user32.dll")]static extern bool ReleaseCapture();[System.Runtime.InteropServices.DllImport("user32.dll")]static extern IntPtr SendMessage(IntPtr h,int m,IntPtr w,IntPtr l);
 void Launch(){PhoneDeskConfig.OpenMeter(this);}
void Round(){var p=new GraphicsPath();int r=42;p.AddArc(0,0,r,r,180,90);p.AddArc(Width-r,0,r,r,270,90);p.AddArc(Width-r,Height-r,r,r,0,90);p.AddArc(0,Height-r,r,r,90,90);p.CloseFigure();Region=new Region(p);p.Dispose();}
 protected override void OnPaint(PaintEventArgs e){base.OnPaint(e);using(var b=new SolidBrush(Color.White)){e.Graphics.DrawString(Text,Font,b,20,23);e.Graphics.DrawString("—",new Font("Segoe UI",14),b,Width-66,14);e.Graphics.DrawString("×",new Font("Segoe UI",15),b,Width-35,12);e.Graphics.FillRectangle(b,Width/2-30,Height-20,60,3);}}
 [STAThread]static void Main(){Application.EnableVisualStyles();Application.SetCompatibleTextRenderingDefault(false);var f=new Phone2();PhoneDeskConfig.Bind(f,1);Application.Run(f);}
}





