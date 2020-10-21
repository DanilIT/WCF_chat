using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_chat
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IServiceChat
    {
       
        [OperationContract]
        int Connect(string name); //подключение к сервису

        [OperationContract]
        void Disconnect(int id); 

        [OperationContract(IsOneWay = true)]
        void SendMsg(string msg, int id);
    }

    public interface IServerChatCallback
    {                      //чтобы сервер не ожидал ответа      
        [OperationContract(IsOneWay = true)]
        void MsgCallback(string msg, int id);
    }
}
