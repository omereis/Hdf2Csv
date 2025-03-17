/*****************************************************************************\
|                              ProtocolInfo.cs                                |
\*****************************************************************************/
using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
//-----------------------------------------------------------------------------
using MySql.Data.MySqlClient;
using OmerEisCommon;
using System.IO;
//-----------------------------------------------------------------------------
namespace Hdf2Csv {
	public class TProtocolInfo {
		private int m_id;
		private string m_strName;
		private string m_strDescription;
		private TProtocolSection[] m_aSections;
//-----------------------------------------------------------------------------
		public int ID {get{return (m_id);}set{m_id=value;}}
		public string Name {get{return (m_strName);}set{m_strName=value;}}
		public string Description {get{return (m_strDescription);}set{m_strDescription=value;}}
		public TProtocolSection[] Sections {get{return(m_aSections);}set{m_aSections=value;}}
//-----------------------------------------------------------------------------
		public TProtocolInfo () {
			Clear();
		}
//-----------------------------------------------------------------------------
		public TProtocolInfo (TProtocolInfo other) {
			AssignAll (other);
		}
//-----------------------------------------------------------------------------
		public void Clear () {
			ID = 0;
			Name = "";
			Description = "";
			Sections = null;
		}
//-----------------------------------------------------------------------------
		public void AssignAll (TProtocolInfo other) {
			ID = other.ID;
			Name = other.Name;
			Description = other.Description;
			Sections = (other.Sections == null ? null : (TProtocolSection[]) other.Sections.Clone());
		}
//-----------------------------------------------------------------------------
		public static bool LoadFromDB (MySqlCommand cmd, ref TProtocolInfo[] aProtocols, ref string strErr) {
			ArrayList aList = new ArrayList ();
			bool f = TProtocolInfoDB.LoadFromDB (cmd, aList, ref strErr);
			if (f) {
				if (aList.Count > 0) {
					aProtocols = new TProtocolInfo[aList.Count];
					for (int n=0 ; n < aList.Count ; n++)
						aProtocols[n] = (TProtocolInfo) aList[n];
				}
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		public bool InsertAsNew (MySqlCommand cmd, ref string strErr) {
			TProtocolInfoDB qdb = new TProtocolInfoDB();
			bool f= qdb.InsertAsNew (cmd, ref strErr);
			if (f)
				AssignAll (qdb);
			return (f);
		}
//-----------------------------------------------------------------------------
		public bool DeleteFromDB (MySqlCommand cmd, ref string strErr) {
			TProtocolInfoDB qdb = new TProtocolInfoDB();
			return (qdb.DeleteFromDB (cmd, ID, ref strErr));
		}
//-----------------------------------------------------------------------------
		public bool UpdateInDB (MySqlCommand cmd, ref string strErr) {
			TProtocolInfoDB qdb = new TProtocolInfoDB(this);
			return (qdb.UpdateInDB (cmd, ref strErr));
		}
//-----------------------------------------------------------------------------
		public string ToHtml () {
			string strHtml = THtmlMisc.FormatHeading (EHtmlHeading.H2, Name);
			strHtml += THtmlMisc.FormatDiv (Description);
			strHtml = THtmlMisc.FormatPage (strHtml);
			//strHtml += OmerEisCommon.THtmlMisc.
			//THtmlMisc.FormatHeading 
			//FormatHeader (H1,this.Name);
			return (strHtml);
		}
//-----------------------------------------------------------------------------
		public int SectionsCount() {
			int nCount = 0;

			if (Sections != null)
				nCount = Sections.Length;
			return (nCount);
		}
//-----------------------------------------------------------------------------
		public bool LoadFromDB (MySqlCommand cmd, ref string strErr) {
			bool fLoad;
			TProtocolInfoDB protocol_db = new TProtocolInfoDB(this);
			if ((fLoad = protocol_db.LoadFromDB (cmd, ID, ref strErr)) == true)
				AssignAll (protocol_db);
			return (fLoad);
		}
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
	}
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//-----------------------------------------------------------------------------
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	internal class TProtocolInfoDB : TProtocolInfo {
		private static readonly string Table   = "tblProtocols";
		public static readonly string FldID   = "protocol_id";
		private static readonly string FldName = "protocol_name";
		private static readonly string FldDesc = "protocol_desc";
//-----------------------------------------------------------------------------
		public TProtocolInfoDB () : base () {}
//-----------------------------------------------------------------------------
		public TProtocolInfoDB (TProtocolInfo other) : base (other) {}
//-----------------------------------------------------------------------------
		public TProtocolInfoDB (TProtocolInfoDB other) : base (other) {}
//-----------------------------------------------------------------------------
		public static bool LoadFromDB (MySqlCommand cmd, ArrayList aProtocols, ref string strErr) {
			bool f = false;
			MySqlDataReader reader = null;

			try {
				TProtocolInfoDB qdb = new TProtocolInfoDB ();
				aProtocols.Clear ();
				cmd.CommandText = String.Format ("select * from {0};", Table);
				reader = cmd.ExecuteReader ();
				f = true;
				while ((f) && (reader.Read())) {
					if ((f = qdb.LoadFromReader (reader, ref strErr)) == true)
						aProtocols.Add (new TProtocolInfo (qdb));
				}
			}
			catch (Exception ex) {
				f = false;
				strErr = ex.Message;
			}
			finally {
				if (reader != null)
					reader.Close ();
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		private bool LoadFromReader (MySqlDataReader reader, ref string strErr) {
			bool f = false;

			try {
				Clear();
				ID = TMisc.ReadIntField (reader, FldID);
				Name = TMisc.ReadTextField (reader, FldName, ref strErr);
				Description = TMisc.ReadTextField (reader, FldDesc, ref strErr);
				f = true;
			}
			catch (Exception ex) {
				strErr = ex.Message;
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		public new bool InsertAsNew (MySqlCommand cmd, ref string strErr) {
			int id=0;
			bool f = false;
			
			try {
				TMisc.GetFieldMax (cmd, Table, FldID, ref id, ref strErr);
				if ((f = TMisc.GetFieldMax (cmd, Table, FldID, ref id, ref strErr)) == true) {
					cmd.CommandText = String.Format ("insert into {0} ({1}) values ({2});", Table, FldID, id + 1);
					cmd.ExecuteNonQuery ();
					ID = id + 1;
				}
			}// feldman 053-310-4388
			catch (Exception ex) {
				strErr = ex.Message;
			}
			return (f);//israel shiff 054-857-1780
		}
//-----------------------------------------------------------------------------
		public bool DeleteFromDB (MySqlCommand cmd, int id, ref string strErr) {
			bool f = false;

			try {
				cmd.CommandText = String.Format ("delete from {0} where {1}={2}", Table, FldID, id);
				cmd.ExecuteNonQuery ();
				f = true;
			}
			catch (Exception ex) {
				strErr = ex.Message;
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		public new bool UpdateInDB (MySqlCommand cmd, ref string strErr) {
			bool f = false;

			try {
				ArrayList al = new ArrayList ();
				TMisc.AddUpdateField (al, FldName, Name);
				TMisc.AddUpdateField (al, FldDesc, Description);
				string strSet = TMisc.GetSqlUpdateSet (al);
				if (strSet.Length > 0) {
					cmd.CommandText = String.Format ("update {0} set {1} where {2}={3};", Table, strSet, FldID, ID);
					cmd.ExecuteNonQuery ();
				}
				f = true;
			}
			catch (Exception ex) {
				strErr = ex.Message;
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		public bool LoadFromDB (MySqlCommand cmd, int id, ref string strErr) {
			bool fLoad=false;
			MySqlDataReader reader = null;

			try {
				cmd.CommandText = String.Format ("select * from {0} where {1}={2};", Table, FldID, id);
				reader = cmd.ExecuteReader ();
				if (reader.Read ()) {
					if (LoadFromReader (reader, ref strErr)) {
						fLoad = LoadSectionsTasks (cmd, ref strErr);
					}
				}
				fLoad = true;
			}
			catch (Exception ex) {
				strErr = ex.Message;
				fLoad = false;
			}
			finally {
				if (reader != null)
					reader.Close ();
			}
			return (fLoad);
		}
//-----------------------------------------------------------------------------
		public bool LoadSectionsTasks (MySqlCommand cmd, ref string strErr) {
			TProtocolSection[] aSections=null;
			bool fLoad;

			if ((fLoad = TProtocolSection.LoadFromDB (cmd, ID, ref aSections, ref strErr)) == true) {
				if (aSections != null)
					Sections = (TProtocolSection[]) aSections.Clone();
				else
					Sections = null;
			}
			return (fLoad);
		}
//-----------------------------------------------------------------------------
	}
}
//-----------------------------------------------------------------------------
