﻿using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Xml;

namespace Control_de_placas.Src.Config
{
    class AppConfig
    {
        /// <summary>
        /// Guarda valores de un tag en key->value
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Save(string tag, string key, string value)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            xmlDoc.SelectSingleNode("//" + tag + "/add[@key='" + key + "']").Attributes["value"].Value = value;
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            ConfigurationManager.RefreshSection(tag);
        }

        /// <summary>
        /// Lee el valor de un tag->key
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Read(string tag, string key)
        {
            NameValueCollection vtw = ConfigurationManager.GetSection(tag) as NameValueCollection;
            string valor = vtw[key];
            return valor;
        }
    }
}
