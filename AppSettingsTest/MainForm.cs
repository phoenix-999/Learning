using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSettingsTest
{
    public partial class MainForm : Form
    {
        ///<summary>
        ///Определяет визуальные элементы
        ///Агрегирует ссылки на классы VisualEvents  и BusinessLogicalEvents, которые инициализирует в закрытом методе InitEventsHandler()
        /// </summary>
        BusinessLogicEvents businessLogicEvents;
        VisualEvents visualEvents;
        public MainForm()
        {
            InitializeComponent();
            InitEventsHandler();
            InitStartSettings();
        }

        void InitStartSettings()
        {
            if (visualEvents != null)
            {
                visualEvents.SetBackgroundColor();
            }
            else
            {
                throw new Exception("Обработчки событий не инициализированы.");
            }
        }

        void InitEventsHandler()
        {
            visualEvents = new VisualEvents(this);
            visualEvents.InitializeEventHandlers();

            businessLogicEvents = new BusinessLogicEvents(); //На данный момент не исползуется
            businessLogicEvents.InitializeBusinessLogicEventHandlers();
        }

        private void btn_changeColor_Click(object sender, EventArgs e)
        {
            this.BackgroundColorDialog.ShowDialog();
            Color newColor = this.BackgroundColorDialog.Color;
            visualEvents.ChangeBackgroundColor(newColor);
        }


    }
}
