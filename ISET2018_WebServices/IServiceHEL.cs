using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ISET2018_WebServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceHEL" in both code and config file together.
	[ServiceContract]
	public interface IServiceHEL
	{
		[OperationContract]
		string HelloWorld();

		[OperationContract]
		CompositeType GetDataUsingDataContract(CompositeType composite);

		[OperationContract]
		WS_Personne GetPersonneByID(int nID);
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

	[DataContract]
	public class WS_Personne
	{
		int _ID;
		string _Nom, _Prenom;

		[DataMember]
		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		[DataMember]
		public string Nom
		{
			get { return _Nom; }
			set { _Nom = value; }
		}

		[DataMember]
		public string Prenom
		{
			get { return _Prenom; }
			set { _Prenom = value; }
		}
	}

}
