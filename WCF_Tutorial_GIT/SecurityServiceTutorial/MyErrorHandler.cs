using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace SecurityServiceTutorial
{
    class MyErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            try
            {
                Console.WriteLine("Сработал IErrorHandler.HandleError. Тип исключения: {0}", error.GetType());
            }
            catch
            { }

            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            string excMessage = error.Message;
            FaultException<string> faultException = new FaultException<string>("Any Error", excMessage);
            MessageFault messageFault = faultException.CreateMessageFault();
            fault = Message.CreateMessage(version, messageFault, faultException.Action);
        }
    }
}
