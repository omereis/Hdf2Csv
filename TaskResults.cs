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
using OmerEisCommon;
//-----------------------------------------------------------------------------
namespace Hdf2Csv {
	public class TTaskResults {
		private int m_id;
		private object m_oValue;
//-----------------------------------------------------------------------------
		public int ID {get{return (m_id);}set{m_id=value;}}
		public object Value {get{return (m_oValue);}set{m_oValue=value;}}
//-----------------------------------------------------------------------------
		public TTaskResults () {
			Clear ();
		}
//-----------------------------------------------------------------------------
		public TTaskResults (TTaskResults other) {
			AssignAll (other);
		}
///-----------------------------------------------------------------------------
		protected void Clear () {
			ID = 0;
			Value = null;
		}
//-----------------------------------------------------------------------------
		protected void AssignAll (TTaskResults other) {
			ID = other.ID;
			if (other.Value != null) {
				Value = new object ();
				Value = other.Value;
			}
			else
				Value = null;
		}
//-----------------------------------------------------------------------------
	}
//-----------------------------------------------------------------------------
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//-----------------------------------------------------------------------------
	public class TTaskResultsNum : TTaskResults {
		private double m_dMin;
		private double m_dMax;
		public double Min {get{return (m_dMin);}set{m_dMin=value;}}
		public double Max {get{return (m_dMax);}set{m_dMax=value;}}
		public TTaskResultsNum () : base () {
			Clear ();
		}
		public TTaskResultsNum (TTaskResultsNum other) : base (other) {
			AssignAll (other);
		}
		private new void Clear () {
			Min = Max = 0;
		}
		private new void AssignAll (TTaskResultsNum other) {
			Min = other.Min;
			Max = other.Max;
		}
	}
//-----------------------------------------------------------------------------
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//-----------------------------------------------------------------------------
	public class TTaskResultsValues : TTaskResults {
		private string[] m_aValues;
//-----------------------------------------------------------------------------
		public string[] Values {get{return(m_aValues);}set{m_aValues=value;}}
//-----------------------------------------------------------------------------
		public TTaskResultsValues () : base () {
			Values = null;
		}
//-----------------------------------------------------------------------------
		public TTaskResultsValues (TTaskResultsValues other) : base (other) {
			Values = (string[]) other.Values.Clone();
		}
//-----------------------------------------------------------------------------
	}
}
