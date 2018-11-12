using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ISET2018_WebServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceHEL" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select ServiceHEL.svc or ServiceHEL.svc.cs at the Solution Explorer and start debugging.
	public class ServiceHEL : IServiceHEL
	{

		public string HelloWorld()
		{
			return "Hello World";
		}

		public CompositeType GetDataUsingDataContract(CompositeType composite)
		{
			if (composite == null)
				throw new ArgumentNullException("composite");
			if (composite.BoolValue)
				composite.StringValue += "Suffix";
			return composite;
		}

		public WS_Personne GetPersonneByID(int nID)
		{
			string chConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/WS_Data.mdf") + "';Integrated Security=True;Connect Timeout=30";
			WS_Personne p = new WS_Personne();
			SqlConnection Con = new SqlConnection(chConn);
			Con.Open();
			SqlCommand Com = new SqlCommand("SELECT Nom, Pre FROM WS_Personne WHERE ID=" + nID.ToString(), Con);
			SqlDataReader dr = Com.ExecuteReader();
			if (dr.Read())
			{
				p.ID = nID;
				p.Nom = dr["Nom"].ToString();
				p.Prenom = dr["Pre"].ToString();
			}
			Con.Close();
			return p;
		}
	}
}
