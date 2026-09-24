using System;
using System.Threading;
using System.Reactive;
using Avalonia.Threading;
using ReactiveUI;
using Zafiro.UI.Shell.Utils;
using Zafiro.Avalonia.Dialogs;
using Zafiro.Avalonia.Services;
using Zafiro.Avalonia.Dialogs.Implementations;

namespace ZefiroFortune.Sections
{
    [Section(icon: "fa-houzz", sortIndex: 0)]
    public class HomeViewModel: ReactiveObject
    {
        internal MySqlConnector.MySqlConnection conn;
        private MySqlConnector.MySqlCommand cmd;
        private MySqlConnector.MySqlDataReader reader;
        private int max = 0;
        private Random rnd;
        private int id;
        private string _cookie = string.Empty;
        private bool _continua = true;
        private readonly int tentativi = 10;
        private readonly int millisecondi = 1000;
        public String Message
        {
            get => $"Per ottenere un doppione cliccare sul pulsante per {max} volte.";
        }
        public string Cookie
        {
            get => _cookie;
            set => this.RaiseAndSetIfChanged(ref _cookie, value);
        }

        public bool Continua
        {
            get => _continua;
            set => this.RaiseAndSetIfChanged(ref _continua, value);
        }

        public ReactiveCommand<Unit, Unit> GetCookieCommand { get; }

        public HomeViewModel()
        {
            try
            {
                connect(tentativi);
                GetCookie();
                GetCookieCommand = ReactiveCommand.Create(GetCookie);
            }
            catch (Exception ex)
            {
                IDialog d = DialogService.Create();
                d.ShowOk(ex.Message, "Errore");
                Continua = false;
            }
            rnd = new();
        }

        public void GetCookie()
        {
            try
            {
                id = rnd.Next(1, max);
                cmd = new($"SELECT Testo FROM Barzellette WHERE ID = {id}", conn);
                reader = cmd.ExecuteReader();
                reader.Read();
                Cookie = reader.GetString(0);
                reader.Close();
                Continua = true;    
            }
            catch (Exception ex)
            {
                try
                {
                    connect(tentativi);
                    GetCookie();
                }
                catch (Exception ex2)
                {
                    App.Notifications.Show(ex2.Message, "Errore");
                    Continua = false;
                }
            }
        }

        private void connect(int tentative)
        {
            try
            {
                conn = new("server=numeronesoft.ddns.net;user=guest;database=barzellette;port=3306");
                conn.Open();
                rnd = new();
                cmd = new("SELECT MAX(ID) FROM Barzellette", conn);
                reader = cmd.ExecuteReader();
                reader.Read();
                max = reader.GetInt32(0);
                reader.Close();
            }
            catch (Exception ex)
            {
                if (tentative < 1)
                    throw ex;
                else
                {
                    Thread.Sleep(millisecondi);
                    connect(tentative - 1);
                }
            }
        }
    }
}
