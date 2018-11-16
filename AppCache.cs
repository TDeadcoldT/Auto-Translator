using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTranslator
{
    class AppCache
    {
        public static string API { get; set; } = @"trnsl.1.1.20180430T193137Z.fdcc61dfc1579250.59e7a39bff911d25dc534414106571a99606a113";
        public static string UrlGetAvailableLanguages { get; } = @"https://translate.yandex.net/api/v1.5/tr.json/getLangs?key={0}&ui={1}";
        public static string UrlDetectSrcLanguage { get; } = @"https://translate.yandex.net/api/v1.5/tr.json/detect?key={0}&text={1}";
        public static string UrlTranslateLanguage { get; } = @"https://translate.yandex.net/api/v1.5/tr.json/translate?key={0}&text={1}&lang={2}";
    }
}
