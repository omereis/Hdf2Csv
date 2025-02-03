/*****************************************************************************\
|                                  main.cs                                     |
\*****************************************************************************/
using MySql.Data.MySqlClient;
using OmerEisCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static HDF5DotNet.H5T;
//-----------------------------------------------------------------------------
namespace Hdf2Csv {
//-----------------------------------------------------------------------------
	public class TUserInfo {
		private int m_id;
		private string m_strLast;
		private string m_strFirst;
		private string m_strEmail;
		private string m_strPhone;
		private string m_strUsername;
		private string m_strPasswd;
//-----------------------------------------------------------------------------
		public int    UserID	{get{return (m_id);}set{m_id=value;}}
		public string LastName	{get{return (m_strLast);}set{m_strLast=value;}}
		public string FirstName	{get{return (m_strFirst);}set{m_strFirst=value;}}
		public string Email		{get{return (m_strEmail);}set{m_strEmail=value;}}
		public string Phone		{get{return (m_strPhone);}set{m_strPhone=value;}}
		public string Username	{get{return (m_strUsername);}set{m_strUsername=value;}}
		public string Passwd	{get{return (m_strPasswd);}set{m_strPasswd=value;}}
//-----------------------------------------------------------------------------
		public TUserInfo () {
			Clear ();
		}
//-----------------------------------------------------------------------------
		public TUserInfo (TUserInfo other) {
			AssignAll (other);
		}
//-----------------------------------------------------------------------------
		public void Clear () {
			UserID		= 0;
			LastName	= "";
			FirstName	= "";
			Email		= "";
			Phone		= "";
			Username	= "";
			Passwd		= "";
		}
//-----------------------------------------------------------------------------
		public void AssignAll (TUserInfo other) {
			UserID		= other.UserID;
			LastName	= other.LastName;
			FirstName	= other.FirstName;
			Email		= other.Email;
			Phone		= other.Phone;
			Username	= other.Username;
			Passwd		= other.Passwd;
		}
//-----------------------------------------------------------------------------
		public string GetFullName() {
			return (FirstName + " " + LastName);
		}
//-----------------------------------------------------------------------------
		public static bool LoadFromDB (MySqlCommand cmd, ref TUserInfo[] aUsers, ref string strErr) {
			bool f=false;
			ArrayList arUsers = new ArrayList ();
			f = TUserInfoDB.LoadFromDB (cmd, arUsers, ref strErr);
			if (f) {
				if (arUsers.Count > 0) {
					aUsers = new TUserInfo[arUsers.Count];
					for (int n=0 ; n < arUsers.Count ; n++)
						aUsers[n] = (TUserInfo) arUsers[n];
				}
				else
					aUsers = null;
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		public bool InsertAsNew (MySqlCommand cmd, ref string strErr) {
			TUserInfoDB user_db = new TUserInfoDB ();
			bool f = user_db.InsertAsNew (cmd, ref strErr);
			if (f)
				AssignAll (user_db);
			return (f);
		}
//-----------------------------------------------------------------------------
		public bool DeleteFromDB (MySqlCommand cmd, ref string strErr) {
			TUserInfoDB user_db = new TUserInfoDB (this);
			return (user_db.DeleteFromDB (cmd, ref strErr));
		}
//-----------------------------------------------------------------------------
		public bool UpdateInDB (MySqlCommand cmd, ref string strErr) {
			TUserInfoDB user_db = new TUserInfoDB (this);
			return (user_db.UpdateInDB (cmd, ref strErr));
		}
	}
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	public class  TUserInfoDB : TUserInfo {
		public static readonly string Table = "tblusers";
		public static readonly string FldID = "user_id";
		public static readonly string FldLast = "last_name";
		public static readonly string FldFirst = "first_name";
		public static readonly string FldEmail = "email";
		public static readonly string FldPhone = "phone";
		public static readonly string FldUser = "username";
		public static readonly string FldPasswd = "password";
//-----------------------------------------------------------------------------
		public TUserInfoDB () : base() {
		}
//-----------------------------------------------------------------------------
		public TUserInfoDB (TUserInfo other) {
			AssignAll (other);
		}
//-----------------------------------------------------------------------------
		public static bool LoadFromDB (MySqlCommand cmd, ArrayList aUsers, ref string strErr) {
			bool f=false;
			aUsers.Clear ();
			MySqlDataReader reader = null;

			try {
				cmd.CommandText = "select * from " + Table;
				reader = cmd.ExecuteReader ();
				TUserInfoDB user_db = new TUserInfoDB ();
				f = true;
				while ((f) && (reader.Read())) {
					if ((f = user_db.LoadFromReader (reader, ref strErr)))
						aUsers.Add (new TUserInfo (user_db));
				}
			}
			catch (Exception e) {
				strErr = e.Message;
				f = false;
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
				Clear ();
				UserID    = TMisc.ReadIntField (reader, FldID, ref strErr);
				FirstName = TMisc.ReadTextField (reader, FldFirst, ref strErr);
				LastName  = TMisc.ReadTextField (reader, FldLast, ref strErr);
				Email     = TMisc.ReadTextField (reader, FldEmail, ref strErr);
				Phone     = TMisc.ReadTextField (reader, FldPhone, ref strErr);
				Username  = TMisc.ReadTextField (reader, FldUser, ref strErr);
				Passwd    = TMisc.ReadTextField (reader, FldPasswd, ref strErr);
				f = true;
			}
			catch (Exception ex) {
				strErr =ex.Message;
				f = false;
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		public new bool DeleteFromDB (MySqlCommand cmd, ref string strErr) {
			bool f = false;

			try {
				cmd.CommandText = String.Format ("delete from {0} where {1}={2}", Table, FldID, UserID);
				cmd.ExecuteNonQuery ();
				f = true;
			}
			catch (Exception ex) {
				strErr =ex.Message;
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		private bool GetNextUserName (MySqlCommand cmd, int id, ref string strUser, ref string strErr) {
			bool f = false;
			string strUsername="";
			int nCount=1;

			try {
				f = true;
				while ((f) && (nCount > 0)) {
					strUsername = String.Format ("user{0}", id);
					f = TMisc.CountItems (cmd, Table, FldUser, strUsername, ref nCount, ref strErr);
					id++;
				}
				strUser = strUsername;
			}
			catch (Exception ex) {
				strErr =ex.Message;
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		public new bool InsertAsNew (MySqlCommand cmd, ref string strErr) {
			bool f = false;
			int id=0;
			string strUser="";

			try {
				if ((f = TMisc.GetFieldMax (cmd, Table, FldID, ref id, ref strErr)) == true) {
					id++;
					f = GetNextUserName (cmd, id, ref strUser, ref strErr);
					cmd.CommandText = String.Format ("insert into {0} ({1},{2}) values ({3},'{4}');", Table, FldID, FldUser, id, strUser);
					cmd.ExecuteNonQuery ();
					UserID = id;
					Username = strUser;
					f = true;
				}
				f = true;
			}
			catch (Exception ex) {
				strErr =ex.Message;
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		public new bool UpdateInDB (MySqlCommand cmd, ref string strErr) {
			bool f=false;

			try {
				ArrayList al = new ArrayList ();
				AddField (al, FldFirst, FirstName);
				AddField (al, FldLast, LastName);
				AddField (al, FldEmail, Email);
				AddField (al, FldPhone, Phone);
				AddField (al, FldUser, Username);
				AddField (al, FldPasswd, Passwd);
				string strSet = "";
				for (int n=0 ; n < al.Count ; n++) {
					strSet += (string) al[n];
					if (n < al.Count - 1)
						strSet += ",";
				}
				if (strSet.Length > 0) {
					cmd.CommandText = String.Format ("update {0} set {1} where {2}={3};", Table, strSet, FldID, UserID);
					cmd.ExecuteNonQuery ();
				}
				f = true;
			}
			catch (Exception ex) {
				strErr =ex.Message;
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		private void AddField (ArrayList al, string strField, string strValue) {
			if (strValue.Trim().Length > 0);
				al.Add (String.Format("{0}={1}", strField, TMisc.GetDBUpdateValue (strValue)));
		}
	}
}
