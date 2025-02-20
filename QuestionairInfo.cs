/*****************************************************************************\
|                            QuestionairInfo.cs                               |
\*****************************************************************************/
using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using OmerEisCommon;
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
namespace Hdf2Csv {
	public class TQuestionairInfo {
		private int m_id;
		private string m_strName;
		private string m_strDescription;
//-----------------------------------------------------------------------------
		public int ID {get{return (m_id);}set{m_id=value;}}
		public string Name {get{return (m_strName);}set{m_strName=value;}}
		public string Description {get{return (m_strDescription);}set{m_strDescription=value;}}
//-----------------------------------------------------------------------------
		public TQuestionairInfo () {
			Clear();
		}
//-----------------------------------------------------------------------------
		public TQuestionairInfo (TQuestionairInfo other) {
			AssignAll (other);
		}
//-----------------------------------------------------------------------------
		public void Clear () {
			ID = 0;
			Name = "";
			Description = "";
		}
//-----------------------------------------------------------------------------
		public void AssignAll (TQuestionairInfo other) {
			ID = other.ID;
			Name = other.Name;
			Description = other.Description;
		}
//-----------------------------------------------------------------------------
		public static bool LoadFromDB (MySqlCommand cmd, ref TQuestionairInfo[] aQuestionairs, ref string strErr) {
			ArrayList aList = new ArrayList ();
			bool f = TQuestionairInfoDB.LoadFromDB (cmd, aList, ref strErr);
			if (f) {
				if (aList.Count > 0) {
					aQuestionairs = new TQuestionairInfo[aList.Count];
					for (int n=0 ; n < aList.Count ; n++)
						aQuestionairs[n] = (TQuestionairInfo) aList[n];
				}
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		public bool InsertAsNew (MySqlCommand cmd, ref string strErr) {
			TQuestionairInfoDB qdb = new TQuestionairInfoDB();
			bool f= qdb.InsertAsNew (cmd, ref strErr);
			if (f)
				AssignAll (qdb);
			return (f);
		}
//-----------------------------------------------------------------------------
		public bool DeleteFromDB (MySqlCommand cmd, ref string strErr) {
			TQuestionairInfoDB qdb = new TQuestionairInfoDB();
			return (qdb.DeleteFromDB (cmd, ID, ref strErr));
		}
//-----------------------------------------------------------------------------
		public bool UpdateInDB (MySqlCommand cmd, ref string strErr) {
			TQuestionairInfoDB qdb = new TQuestionairInfoDB(this);
			return (qdb.UpdateInDB (cmd, ref strErr));
		}
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
	}
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//-----------------------------------------------------------------------------
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	internal class TQuestionairInfoDB : TQuestionairInfo {
		private static readonly string Table   = "tblQstnrs";
		private static readonly string FldID   = "qnr_id";
		private static readonly string FldName = "qnr_name";
		private static readonly string FldDesc = "qnr_desc";
//-----------------------------------------------------------------------------
		public TQuestionairInfoDB () : base () {}
//-----------------------------------------------------------------------------
		public TQuestionairInfoDB (TQuestionairInfo other) : base (other) {}
//-----------------------------------------------------------------------------
		public TQuestionairInfoDB (TQuestionairInfoDB other) : base (other) {}
//-----------------------------------------------------------------------------
		public static bool LoadFromDB (MySqlCommand cmd, ArrayList aQuestionairs, ref string strErr) {
			bool f = false;
			MySqlDataReader reader = null;

			try {
				TQuestionairInfoDB qdb = new TQuestionairInfoDB ();
				aQuestionairs.Clear ();
				cmd.CommandText = String.Format ("select * from {0};", Table);
				reader = cmd.ExecuteReader ();
				f = true;
				while ((f) && (reader.Read())) {
					if ((f = qdb.LoadFromReader (reader, ref strErr)) == true)
						aQuestionairs.Add (new TQuestionairInfo (qdb));
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
				Description = TMisc.ReadTextField (reader, FldName, ref strErr);
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
	}
}
//-----------------------------------------------------------------------------
