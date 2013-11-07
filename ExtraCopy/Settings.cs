using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ExtraCopy
{
    public class Settings
    {
        private const string SETTINGS_FILENAME = "ExtraCopySettings.xml";

        private string m_sSourceDirectory = String.Empty;
        public string SourceDirectory
        {
            get { return this.m_sSourceDirectory; }
            set { this.m_sSourceDirectory = value; }
        }

        private string m_sTargetDirectory = String.Empty;
        public string TargetDirectory
        {
            get { return this.m_sTargetDirectory; }
            set { this.m_sTargetDirectory = value; }
        }

        private static string GetSettingsFile()
        {
            string sFullPath = System.IO.Path.Combine(Application.LocalPath, SETTINGS_FILENAME);

            return sFullPath;
        }

        public static bool SettingsExist()
        {
            string sSettingsFile = GetSettingsFile();
            return System.IO.File.Exists(sSettingsFile);
        }

        public void Save()
        {
            XmlWriter xWriter = new XmlTextWriter(GetSettingsFile(), Encoding.UTF8);
            xWriter.WriteStartDocument(true);

            xWriter.WriteStartElement(XmlNames.SETTINGS);

            xWriter.WriteElementString(XmlNames.SOURCE_DIR, this.m_sSourceDirectory);
            xWriter.WriteElementString(XmlNames.TARGET_DIR, this.m_sTargetDirectory);

            xWriter.WriteEndElement(); // SETTINGS

            xWriter.WriteEndDocument();

            xWriter.Flush();
            xWriter.Close();
        }

        public void Load()
        {
            string sSettingsFilePath = GetSettingsFile();

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(sSettingsFilePath);
            }
            catch
            {
                return;
            }

            XmlNode nodeSettings = xmlDoc.SelectSingleNode("//" + XmlNames.SETTINGS);
            if (nodeSettings == null) return;

            XmlNode nodeSource = nodeSettings.SelectSingleNode("./" + XmlNames.SOURCE_DIR);
            if (nodeSource != null)
            {
                this.m_sSourceDirectory = nodeSource.InnerText;
            }

            XmlNode nodeTarget = nodeSettings.SelectSingleNode("./" + XmlNames.TARGET_DIR);
            if (nodeTarget != null)
            {
                this.m_sTargetDirectory = nodeTarget.InnerText;
            }
        }

        private class XmlNames
        {
            public const string SETTINGS = "ExtraCopySettings";
            public const string SOURCE_DIR = "SourceDirectory";
            public const string TARGET_DIR = "TargetDirectory";
        }
    }
}
