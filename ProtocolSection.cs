/*****************************************************************************\
|                            ProtocolSection.cs                               |
\*****************************************************************************/
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-----------------------------------------------------------------------------
using MySql.Data.MySqlClient;
using OmerEisCommon;
using System.Collections;
//-----------------------------------------------------------------------------
namespace Hdf2Csv {
	public class TProtocolSection {
		private int m_id;
		private string m_strDesc;
		private string m_strTitle;
		private int m_nOrder;
		private TProtocolTask[] aTasks;
//-----------------------------------------------------------------------------
		public int ID {get{return (m_id);}set{m_id=value;}}
		public string Description {get{return (m_strDesc);}set{m_strDesc=value;}}
		public string Title {get{return(m_strTitle);}set{m_strTitle=value;}}
		public int Order {get{return (m_nOrder);}set{m_nOrder=value;}}
		public TProtocolTask[] Tasks {get{return (aTasks);}set{aTasks=value;}}
//-----------------------------------------------------------------------------
		public TProtocolSection () {
			Clear ();
		}
//-----------------------------------------------------------------------------
		public TProtocolSection (TProtocolSection other) {
			AssignAll (other);
		}
//-----------------------------------------------------------------------------
		public void Clear () {
			ID = 0;
			Description = "";
			Order = 0;
			Tasks = null;
			Title = "";
		}
//-----------------------------------------------------------------------------
		public void AssignAll (TProtocolSection other) {
			ID = other.ID;
			Description = other.Description;
			Title = other.Title;
			Order = other.Order;
			if (other.Tasks != null)
				Tasks = (TProtocolTask[]) other.Tasks.Clone();
			else
				Tasks = null;
		}
//-----------------------------------------------------------------------------
		public int TasksCount() {
			int nCount = 0;

			if (Tasks != null)
				nCount = Tasks.Length;
			return (nCount);
		}
//-----------------------------------------------------------------------------
		public static bool LoadFromDB (MySqlCommand cmd, int idProtocol, ref TProtocolSection[] aSections, ref string strErr) {
			ArrayList aList = new ArrayList ();
			bool fLoad = TProtocolSectionDB.LoadFromDB (cmd, idProtocol, aList, ref strErr);
			if (fLoad) {
				if (aList.Count > 0) {
					aSections = new TProtocolSection[aList.Count];
					for (int n=0 ; n < aList.Count ; n++)
						aSections[n] = (TProtocolSection) aList[n];
				}
				else
					aSections = null;
			}
			return (fLoad);
		}
	}
	public class TProtocolSectionDB : TProtocolSection {
		private static readonly string Table = "tblSections";
		private static readonly string FldID = "section_id";
		private static readonly string FldOrder = "sect_order";
		private static readonly string FldTitle = "section_title";
  		private static readonly string FldDesc = "section_desc";
		public TProtocolSectionDB() : base() {}
		public TProtocolSectionDB (TProtocolSection other): base(other) {}
//-----------------------------------------------------------------------------
		public static bool LoadFromDB (MySqlCommand cmd, int idProtocol, ArrayList aList, ref string strErr) {
			bool fLoad;
			MySqlDataReader reader=null;

			try {
				cmd.CommandText = String.Format ("select * from {0} where {1}={2}'",
								TProtocolTaskDB.TasksView, TProtocolInfoDB.FldID, idProtocol);
				fLoad = true;
			}
			catch (Exception ex) {
				strErr = ex.Message;
				fLoad = false;
			}
			finally {
				if (reader != null)
					reader.Close();
			}
			return (fLoad);
		}
	}
}
