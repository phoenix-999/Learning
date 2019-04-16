using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

namespace AppSettingsTest
{
    class VisualEvents
    {
        ///<summary>
        ///Определяет допустимые визуальные события и их обработчики
        ///Методы-обработчики оперируют с экземпляром Form инициализированном в конструкторе
        ///</summary>
        Form form;

        
        delegate void ChangeColor(Color color);
        //Для смены цвета фона
        event ChangeColor ChangeBackgroundColorEvent;

        
        delegate void SetFromAppSettings();
        //Для установки настроек при загрузке
        event SetFromAppSettings SetFromAppSettingsEvent;

        public VisualEvents(Form form)
        {
            this.form = form;
        }

        public void InitializeEventHandlers() 
        {
            ///<summary>
            ///Инициализирует события обработчиками
            /// </summary>
            this.ChangeBackgroundColorEvent += ChangeBackgroundColorHandler;
            this.SetFromAppSettingsEvent += SetStartBackgroundColorHandler;
        }

        void ChangeBackgroundColorHandler(Color color)
        {
            //Смена цвета фона
            form.BackColor = color;
            // Запись нового цвета фона в файл конфигурации
            SaveBackgroundColor(color);
        }

        void SetStartBackgroundColorHandler()
        {
            int r, g, b;
            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

                if (settings["BackgroundColor"] == null) //Если ключ отсутствует - возвращается null
                {
                    return;
                }
                else
                {
                    ParseRGB(settings["BackgroundColor"].Value, out r, out g, out b);

                    Color savedColor = Color.FromArgb(r, g, b);
                    form.BackColor = savedColor;
                }
            }
            catch(ConfigurationErrorsException ex)
            {
                DisplayConfigurationException(ex);
            }

        }

        public void SetSavedSettings()
        {
            SetFromAppSettingsEvent();
        }

        void ParseRGB(string rgb, out int r, out int g, out int b)
        {
            string[] rgbValues = rgb.Split('-');

            r = 0;
            g = 0;
            b = 0;

            int.TryParse(rgbValues[0], out r);
            int.TryParse(rgbValues[1], out g);
            int.TryParse(rgbValues[2], out b);
        }

        void SaveBackgroundColor(Color color)
        {
            ///<summary>
            /// Запись нового цвета фона в файл конфигурации
            /// </summary>

            try
            {
                //Получить экземпляр секции appSettings файла конфигурации в виде коллекции
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

                //Сформировать строку RGB
                string colorRGB = string.Format("{0}-{1}-{2}", color.R, color.G, color.B);

                //Проверить коллекцию на наличия ключа и изменить или добавить новое значение
                if (settings.AllKeys.Contains<string>("BackgroundColor"))
                {
                    settings["BackgroundColor"].Value = colorRGB;
                }
                else
                {
                    settings.Add("BackgroundColor", colorRGB);
                }

                //Сохранение файла конфигурации
                configFile.Save(ConfigurationSaveMode.Modified);
            }
            catch (ConfigurationErrorsException ex)
            {
                DisplayConfigurationException(ex);
            }
            
        }

        public void ChangeBackgroundColor(Color color)
            ///<summary>
            ///Метод интерфейса класса для работы с событием смена цвета фона
            /// </summary>
        {
            this.ChangeBackgroundColorEvent(color);
        }

        void DisplayConfigurationException(Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
