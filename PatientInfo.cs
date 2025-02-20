/*****************************************************************************\
|                              PatientInfo.cs                                 |
\*****************************************************************************/
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using OmerEisCommon;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-----------------------------------------------------------------------------
using System.Collections;
using Microsoft.VisualBasic.ApplicationServices;
using MySqlX.XDevAPI.Relational;
using System.IO;
using System.Linq.Expressions;
//-----------------------------------------------------------------------------
namespace Hdf2Csv {
	public class TPatientInfo {
				private int m_nPatientID;
		private string m_strCode;
		private int m_yob;
		private double m_rHeight;
		private double m_rWeight;
		private int m_gender;
//-----------------------------------------------------------------------------
		public int PatientID {get{return (m_nPatientID);}set{m_nPatientID=value;}}
		public string Code {get{return (m_strCode);}set{m_strCode=value;}}
		public int YOB {get{return (m_yob);}set{m_yob=value;}}
		public double Height {get{return (m_rHeight);}set{m_rHeight=value;}}
		public double Weight {get{return (m_rWeight);}set{m_rWeight=value;}}
		public int Gender {get{return (m_gender);}set{m_gender=value;}}
//-----------------------------------------------------------------------------
		public TPatientInfo () {
			Clear ();
		}
//-----------------------------------------------------------------------------
		public TPatientInfo (TPatientInfo other) {
			AssignAll (other);
		}
//-----------------------------------------------------------------------------
		public void Clear () {
			PatientID = 0;
			Code      = "";
			YOB       = 0;
			Height    = 0;
			Weight    = 0;
			Gender    = 0;
		}
//-----------------------------------------------------------------------------
		public void AssignAll (TPatientInfo other) {
			PatientID = other.PatientID;
			Code      = other.Code;
			YOB       = other.YOB;
			Height    = other.Height;
			Weight    = other.Weight;
			Gender    = other.Gender;
		}
//-----------------------------------------------------------------------------
		public string GetCurrentAge() {
			string strAge = "";

			if (YOB > 0) {
				int nAge = TMisc.GetCurrentYear() - YOB;
				strAge = nAge.ToString();
			}
			return (strAge);
		}
//-----------------------------------------------------------------------------
		public string GetGenderName () {
			string strGender="";

			if (Gender == 1)
				strGender = "Female";
			else if (Gender == 2)
				strGender = "Male";
			return (strGender);
	}
//-----------------------------------------------------------------------------
		public static bool LoadFromDB (MySqlCommand cmd, ref TPatientInfo[] aPatients, ref string strErr) {
			ArrayList a = new ArrayList();
			aPatients = null;
			bool f = TPatientInfoDB.LoadFromDB (cmd, a, ref strErr);
			if (f) {
				if (a.Count > 0) {
					aPatients = new TPatientInfo[a.Count];
					for (int n=0 ; n < a.Count; n++)
						aPatients[n] = (TPatientInfo) a[n];
				}
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		public static bool SuggestPatientCode (MySqlCommand cmd, ref string strCode, ref string strErr) {
			return (TPatientInfoDB.SuggestPatientCode (cmd, ref strCode, ref strErr));
		}
//-----------------------------------------------------------------------------
		public bool InsertAsNew (MySqlCommand cmd, ref string strErr) {
			TPatientInfoDB patient_db = new TPatientInfoDB (this);
			
			bool f = patient_db.InsertAsNew (cmd, ref strErr);
			if (f)
				AssignAll (patient_db);
			return (f);
		}
//-----------------------------------------------------------------------------
		public bool UpdateInDB (MySqlCommand cmd, ref string strErr) {
			TPatientInfoDB patient_db = new TPatientInfoDB (this);
			return (patient_db.UpdateInDB (cmd, ref strErr));
		}
//-----------------------------------------------------------------------------
		public bool DeleteFromDB (MySqlCommand cmd, ref string strErr) {
			TPatientInfoDB patient_db = new TPatientInfoDB (this);
			return (patient_db.DeleteFromDB (cmd, ref strErr));
		}
//-----------------------------------------------------------------------------
		public static string GetRandomPatientCode () {
			string strCode = "";
			char c1 = TMisc.GetRandomChar(), c2 = TMisc.GetRandomChar();;
			Random rnd = new Random();
			int nCode = rnd.Next (0,99);
			strCode = String.Format ("{0}{1}{2}", c1, c2, nCode.ToString("D2"));
			return (strCode);
		}
//-----------------------------------------------------------------------------
		public string GetHeight () {
			string strHeight="";

			if (Height > 0)
				strHeight = Height.ToString ();
			return (strHeight);
		}
//-----------------------------------------------------------------------------
		public string GetWeight() {
			string strWeight="";

			if (Weight > 0)
				strWeight = Weight.ToString ();
			return (strWeight);
		}
//-----------------------------------------------------------------------------
}
//-----------------------------------------------------------------------------
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//-----------------------------------------------------------------------------
	public class  TPatientInfoDB : TPatientInfo {
		private static readonly string Table = "tblPatients";
		private static readonly string FldID = "patient_id";
		private static readonly string FldCode = "code";
		private static readonly string FldYOB = "yob";
		private static readonly string FldHeight = "height";
		private static readonly string FldWeight = "weight";
		private static readonly string FldGender = "gender";
//-----------------------------------------------------------------------------
		public TPatientInfoDB () : base () {	}
		public TPatientInfoDB (TPatientInfo other) : base (other) {	}
//-----------------------------------------------------------------------------
		public static bool LoadFromDB (MySqlCommand cmd, ArrayList aPatients, ref string strErr) {
			bool f=false;
			MySqlDataReader reader = null;

			try {
				TPatientInfoDB patient = new TPatientInfoDB ();
				aPatients.Clear ();
				cmd.CommandText = String.Format ("select * from {0};", Table);
				reader = cmd.ExecuteReader ();
				f = true;
				while ((f) && (reader.Read())) {
					if ((f = patient.LoadFromReader (reader, ref strErr)) == true)
						aPatients.Add (new TPatientInfo (patient));
				}

			}
			catch (Exception ex) {
				strErr = ex.Message;
			}
			finally {
				if (reader != null)
					reader.Close();
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		private bool LoadFromReader (MySqlDataReader reader, ref string strErr) {
			bool f = false;

			try {
				Clear ();
				PatientID = TMisc.ReadIntField (reader, FldID, ref strErr);
				Code      = TMisc.ReadTextField (reader, FldCode, ref strErr);
				YOB       = TMisc.ReadIntField (reader, FldYOB, ref strErr);
				Height    = TMisc.ReadRealField (reader, FldHeight, ref strErr);
				Weight    = TMisc.ReadRealField (reader, FldWeight, ref strErr);
				Gender    = TMisc.ReadIntField (reader, FldGender, ref strErr);
				f = true;
			}
			catch (Exception ex) {
				strErr = ex.Message;
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		public new bool InsertAsNew (MySqlCommand cmd, ref string strErr) {
			bool f = false;
			int id=0;

			try {
				string strCode="";
				if (TMisc.GetFieldMax (cmd, Table, FldID, ref id, ref strErr)) {
					if (SuggestPatientCode (cmd, ref strCode, ref strErr)) {
						cmd.CommandText = String.Format ("insert into {0} ({1},{2}) values ({3},'{4}');",
									Table, FldID, FldCode, id + 1, strCode);
						cmd.ExecuteNonQuery ();
						PatientID = id + 1;
						Code = strCode;
						f = true;
					}
				}
			}
			catch (Exception ex) {
				strErr = ex.Message;
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		public static bool CountItems (MySqlCommand cmd, string strTable, string strField, ref int nCount, ref string strErr, string strValue=null) {
			bool f = false;
			MySqlDataReader reader = null;

			try {
				string strSql = String.Format ("select count(*) from {0}", strTable);
				if (strValue != null) {
					string strWhere = String.Format (" where {0}='{1}'", strField, strValue);
					strSql += strWhere;
				}
				cmd.CommandText = strSql;
				reader = cmd.ExecuteReader ();
				if (reader.Read ()) {
					nCount = reader.GetInt32(0);
					f = true;
				}
			}
			catch (Exception ex) {
				strErr=ex.Message;
				nCount = -1;
			}
			finally {
				if (reader != null)
					reader.Close ();
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		public static bool SuggestPatientCode (MySqlCommand cmd, ref string strCode, ref string strErr) {
			int nCount=0;
			bool f = false;
			string str="";

			do {
				str = GetRandomPatientCode ();
				f = CountItems (cmd, Table, FldCode, ref nCount, ref strErr, str);
			} while ((f) && (nCount > 0));
			if (f)
				strCode = str;
			return (f);
		}
//-----------------------------------------------------------------------------
		public new bool UpdateInDB (MySqlCommand cmd, ref string strErr) {
			bool f = false;
			ArrayList al = new ArrayList ();

			try {
				TMisc.AddUpdateField (al, FldYOB, YOB);
				TMisc.AddUpdateField (al, FldHeight, Height);
				TMisc.AddUpdateField (al, FldWeight, Weight);
				TMisc.AddUpdateField (al, FldGender, Gender);
				string strSet = TMisc.GetSqlUpdateSet (al);
				if (strSet.Length > 0) {
					cmd.CommandText = String.Format ("update {0} set {1} where {2}={3};", Table, strSet, FldID, PatientID);
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
		public new bool DeleteFromDB (MySqlCommand cmd, ref string strErr) {
			bool f = false;

			try {
				cmd.CommandText = String.Format ("delete from {0} where {1}={2};", Table, FldID, PatientID);
				cmd.ExecuteNonQuery ();
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
