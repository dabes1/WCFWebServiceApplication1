using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
// Added usings
using WCFWebServiceApplication1.DataAccess;
using WCFWebServiceApplication1.DataObjects;

namespace WCFWebServiceApplication1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string GetDataJSON(string value)
        {
            return string.Format("You entered: {0}", value);
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public DataObject1 GetDataObject(string id)
        {
            DataObject1 _out = new DataObject1();

            _out.Id = Convert.ToInt32(id);
            _out.Desc = "DataObject Created for Id:" + id;

            List<int> oList = new List<int>();

            for (int i = 0; i < Convert.ToInt32(id); i++)
                oList.Add(i);

            _out.ListInt = oList;

            return _out;
        }

        public StateObject GetStateInfoById(string stateId)
        {
            StateObject _out = new StateObject();

            _out.Id = Convert.ToInt32(stateId);
            _out.Abrv = SQLAccess.GetAbr(_out.Id);
            _out.Name = SQLAccess.GetName(_out.Id);

            return _out; 
        }


        public StateObject GetStateInfoById_XML(string stateId)
        {
            StateObject _out = new StateObject();

            _out.Id = Convert.ToInt32(stateId);
            _out.Abrv = SQLAccess.GetAbr(_out.Id);
            _out.Name = SQLAccess.GetName(_out.Id);
            _out.StateList = SQLAccess.GetStatesList();

            return _out;
        }

        public StateObject GetStateInfoById_JSON(string stateId)
        {
            StateObject _out = new StateObject();

            _out.Id = Convert.ToInt32(stateId);
            _out.Abrv = SQLAccess.GetAbr(_out.Id);
            _out.Name = SQLAccess.GetName(_out.Id);
            _out.StateList = SQLAccess.GetStatesList();

            return _out;
        }
    }
}
