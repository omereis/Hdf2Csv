/*****************************************************************************\
|                              ProtocolTask.cs                                |
\*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-----------------------------------------------------------------------------
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using OmerEisCommon;
//-----------------------------------------------------------------------------
namespace Hdf2Csv {
	public class TProtocolTask {
		private int m_id;
		private int m_nOrder;
		private string m_strDesc;
		private TTaskResults[] m_aTasks;
//-----------------------------------------------------------------------------
		public int ID {get {return (m_id);}set{m_id=value;}}
		public int Order {get {return (m_nOrder);}set{m_nOrder=value;}}
		public string Desc {get {return (m_strDesc);}set{m_strDesc=value;}}
		public TTaskResults[] Tasks {get {return (m_aTasks);}set{m_aTasks=value;}}
//-----------------------------------------------------------------------------
		public TProtocolTask () {
			Clear ();
		}
//-----------------------------------------------------------------------------
		public TProtocolTask (TProtocolTask other) {
			AssignAll (other);
		}
//-----------------------------------------------------------------------------
		private void Clear () {
			ID = 0;
			Order = 0;
			Desc = "";
			Tasks = null;
		}
//-----------------------------------------------------------------------------
		private void AssignAll (TProtocolTask other) {
			ID = other.ID;
			Order  = other.Order;
			Desc  = other.Desc;
			Tasks  = (TTaskResults[]) other.Tasks.Clone ();
		}
//-----------------------------------------------------------------------------
	}
	public class TProtocolTaskDB : TProtocolTask {
		public static readonly string TasksView = "vProtocolSectionsTasks";
	}
}
