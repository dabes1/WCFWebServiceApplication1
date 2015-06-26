using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Added usings
using System.Runtime.Serialization;

namespace WCFWebServiceApplication1.DataObjects
{
    
    [DataContract]
    public class DataObject1
    {
        private int _id;
        private string _desc;
        private List<int> _list;

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Desc { get; set; }


        [DataMember]
        public List<int> ListInt { get; set; }
    }


    [DataContract]
    public class StateObject
    {
        private int _id;
        private string _abrv;
        private string _name;

        [DataMember]
        public int Id { get { return _id; } set { _id = value; } }

        [DataMember]
        public string Abrv { get { return _abrv; }  set { _abrv = value; } }

        [DataMember]
        public string Name { get { return _name; } set { _name = value; } }
    }


}