using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
// Added usings
using WCFWebServiceApplication1.DataObjects;

namespace WCFWebServiceApplication1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate="Data/{value}")]
        string GetData(string value);

        [OperationContract]
        [WebGet(UriTemplate = "DataJSON/{value})", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetDataJSON(string value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]
        [WebGet(UriTemplate = "DataObject/{id}")]
        DataObject1 GetDataObject(string id);


        [OperationContract]
        [WebGet(UriTemplate = "State/{stateId}")]
        StateObject GetStateInfoById(string stateId);


        // This version defined for XML format.
        // The consuming client (WCFWebServiceConsumer1) must consume using XML formats
        #region - The following attributes works with Visual Studio 2010 MVC4WebApplicationBasic
        //[OperationContract]
        //[WebGet(UriTemplate = "StateXML/{stateId}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml)]
        #endregion
        #region - The following attributes works with Visual Studio 2015 RC project: WCFWebServiceConsumer1 project as well as Visual Studio 2010 MVC4WebApplicationBasic
        [OperationContract]
        [WebGet(UriTemplate = "StateXML/{stateId}", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        #endregion
        StateObject GetStateInfoById_XML(string stateId);


        // This version defined for JSON format.
        // The consuming client (WCFWebServiceConsumer1) must consume using JSON formats
        [OperationContract]
        [WebGet(UriTemplate = "StateJSON/{stateId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        StateObject GetStateInfoById_JSON(string stateId);


    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
