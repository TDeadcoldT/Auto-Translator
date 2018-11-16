using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutoTranslator
{
    public partial class Translator : Form
    {
        private List<string> AvailLangs;
        public Translator()
        {
            InitializeComponent();
        }
        private void Translator_Load(object sender, EventArgs e)
        {

        }

        private void btnDetectSrcLang_Click_1(object sender, EventArgs e)
        {
            var response = RequestService(string.Format(AppCache.UrlDetectSrcLanguage, AppCache.API, txtSrc.Text));
            var dict = JsonConvert.DeserializeObject<IDictionary>(response.Content);

            var statusCode = dict["code"].ToString();
            if (statusCode.Equals("200"))
            {
                lblSrcLang.Text = dict["lang"].ToString();
            }
        }

        private void btnAC_Click_1(object sender, EventArgs e)
        {
            var response = RequestService(string.Format(AppCache.UrlGetAvailableLanguages, AppCache.API, lblSrcLang.Text));
            var dict = JsonConvert.DeserializeObject<IDictionary>(response.Content);
            foreach (DictionaryEntry entry in dict)
            {
                if (entry.Key.Equals("langs"))
                {
                    var availableConverts = (JObject)entry.Value;
                    AvailLangs = new List<string>();

                    cmbAvailableLangs.Items.Clear();
                    foreach (var Lang in availableConverts)
                    {
                        if (!Lang.Equals(lblSrcLang.Text))
                        {
                            cmbAvailableLangs.Items.Add(Lang.Value);
                            AvailLangs.Add(Lang.Key);
                        }
                    }
                }
            }
        }

        private void btnTranslate_Click_1(object sender, EventArgs e)
        {
            var response = RequestService(string.Format(AppCache.UrlTranslateLanguage, AppCache.API, txtSrc.Text, AvailLangs[cmbAvailableLangs.SelectedIndex]));
            var dict = JsonConvert.DeserializeObject<IDictionary>(response.Content);
            var statusCode = dict["code"].ToString();
            if (statusCode.Equals("200"))
            {
                txtDestLang.Text = string.Join(",", dict["text"]);
            }
        }
        private IRestResponse RequestService(string strUrl)
        {
            var client = new RestClient()
            {
                BaseUrl = new Uri(strUrl)
            };
            var request = new RestRequest()
            {
                Method = Method.GET
            };
            return client.Execute(request);
        }
    }
}