using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Wox.Plugin.Bitly.Core;
//using Wox.Infrastructure;
//using Wox.Infrastructure.Storage;

namespace Wox.Plugin.Bitly
{
    public class Main : IPlugin, IPluginI18n, ISettingProvider
    {
        public Main()
        {
            //this._storage = new PluginJsonStorage<Settings>();

            //link api:
            //https://support.bitly.com/hc/en-us/articles/231140388-How-do-I-find-my-API-key-
        }
        private const string Login = "o_4cntrdegel";
        private const string ApiKey = "R_87c977a77dde4824bce2cb64e530bd5a";

        private PluginInitContext _context;
        private BitlyClient _client;
        //private readonly Settings _settings;
        private bool _isEnterPressed;

        private bool API_GlobalKeyboardEvent(int keyevent, int vkcode, SpecialKeyState state)
        {
            _isEnterPressed = vkcode == 13;
            //13
            //System.Windows.Forms.MessageBox.Show(vkcode.ToString());
            //if (this._settings.ReplaceWinR)
            //{
            //    if (keyevent == 256 && vkcode == 82 && state.WinPressed)
            //    {
            //        this._winRStroked = true;
            //        this.OnWinRPressed();
            //        return false;
            //    }
            //    if (keyevent == 257 && this._winRStroked && vkcode == 91)
            //    {
            //        this._winRStroked = false;
            //        this._keyboardSimulator.ModifiedKeyStroke(91, 17);
            //        return false;
            //    }
            //}
            return true;
        }

        public void Init(PluginInitContext context)
        {
            _context = context;
            _context.API.GlobalKeyboardEvent  += new WoxGlobalKeyboardEventHandler(API_GlobalKeyboardEvent);

            _client = new BitlyClient(Login, ApiKey);
        }

        public List<Result> Query(Query query)
        {
            List<Result> results = new List<Result>();
            if (query.FirstSearch.Length > 0)
            {
                //check if is url;
                //Uri uriResult;
                //bool isUri = Uri.TryCreate(query.Search, UriKind.Absolute, out uriResult)
                //    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                if (Uri.IsWellFormedUriString(query.Search, UriKind.Absolute))
                {
                    var shorten = _client.Shorten(query.Search);
                    if (shorten.ErrorCode == 0)
                    {

                        var result = new Result
                        {
                            Title = shorten.Results.NodeKeyVal.ShortUrl,
                            SubTitle = shorten.Results.NodeKeyVal.NodeKey,
                            IcoPath = "Images\\bitly.jpg",
                            Action = e =>
                            {

                                bool ret;
                                try
                                {
                                    Clipboard.SetText(shorten.Results.NodeKeyVal.ShortUrl);
                                    System.Windows.Forms.MessageBox.Show("The link was copied to memory");
                                    //Process.Start(shorten.Results.NodeKeyVal.ShortUrl);
                                    ret = true;
                                }
                                catch (Exception)
                                {
                                    _context.API.ShowMsg(string.Format(_context.API.GetTranslation("wox_plugin_url_canot_open_url"), query.Search));
                                    ret = false;
                                }
                                return ret;
                            }
                        };
                        results.Add(result);
                    }
                    else
                    {
                        results.Add(new Result { Title = "Error", SubTitle = shorten.ErrorMessage, IcoPath = "Images\\bitly.jpg" });
                    }
                }
                else
                {
                    results.Add(new Result { Title = "URL invalid", IcoPath = "Images\\bitly.jpg" });
                }
            }
            return results;
        }

        public string GetTranslatedPluginTitle()
        {
            return _context.API.GetTranslation("wox_plugin_bitly_plugin_name");
        }

        public string GetTranslatedPluginDescription()
        {
            return _context.API.GetTranslation("wox_plugin_bitly_plugin_description");
        }

        public Control CreateSettingPanel()
        {
            return new BitlySettings();
        }
    }
}
