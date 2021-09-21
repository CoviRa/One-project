using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;


namespace SQL3
{
    class bd
    {
        private string connectionString;//строка соединения с базой данных
        public bd()
        {
            //строка для подключения
            connectionString = @"Data Source = WIN-3R5N0T1HIDI; Initial Catalog = База данных1; Integrated Security = True";
        }
        public bd(string connectionString)
        {
            this.connectionString = connectionString;//устанавливаю указанную строку соединения
        }
        //метод для добавления нового студента
        public int ADD_STUDENT(int ID, string SURNAME, string NAME, int STIPEND, int KURS, string CITY, DateTime BIRTHDAY, int UNIV_ID)
        {
            List<STUDENT> list = new List<STUDENT>();
            SqlConnection con = new SqlConnection(connectionString);//соединение с БД
            con.Open();//открываю соединение
            using (SqlCommand cmd = new SqlCommand("INSERT INTO STUDENT values(@STUDENT_ID, @SURNAME, @NAME, @STIPEND, @KURS, @CITY, @BIRTHDAY, @UNIV_ID)", con))//созданной команде передается имя хранимой процедуры
            {
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@STUDENT_ID", DbType = System.Data.DbType.Int32, Value = ID });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@SURNAME", DbType = System.Data.DbType.String, Value = SURNAME });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@NAME", DbType = System.Data.DbType.String, Value = NAME });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@STIPEND", DbType = System.Data.DbType.Int32, Value = STIPEND });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@KURS", DbType = System.Data.DbType.Int32, Value = KURS });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@CITY", DbType = System.Data.DbType.String, Value = CITY });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@BIRTHDAY", DbType = System.Data.DbType.DateTime, Value = BIRTHDAY });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@UNIV_ID", DbType = System.Data.DbType.Int32, Value = UNIV_ID });
                cmd.CommandType = CommandType.Text;//указываю тип команды
                int count = cmd.ExecuteNonQuery();//вызываю хранимую процедуру и вставляю студента
                return count;
            }
        }

        //метод для удаления студента
        public List<STUDENT> DELETE_STUDENTS(int ID)
        {
            List<STUDENT> list = new List<STUDENT>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (SqlCommand cmd = new SqlCommand("DELETE FROM STUDENT WHERE STUDENT_ID=@STUDENT_ID", con))//using для работы с обьектом
            {
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@STUDENT_ID", DbType = System.Data.DbType.Int32, Value = ID });
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            con.Close();
            return list;
        }
        //метод для изменения записи о студенте
        public List<STUDENT> UPDATE_STUDENTS(int ID, string SURNAME, string NAME, int STIPEND, int KURS, string CITY, DateTime BIRTHDAY, int UNIV_ID)
        {
            List<STUDENT> list = new List<STUDENT>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE STUDENT SET SURNAME=@SURNAME, NAME=@NAME, STIPEND=@STIPEND, KURS=@KURS, CITY=@CITY, BIRTHDAY=@BIRTHDAY, UNIV_ID=@UNIV_ID WHERE STUDENT_ID=@STUDENT_ID", con))//using для работы с обьектом
            {
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@STUDENT_ID", DbType = System.Data.DbType.Int32, Value = ID });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@SURNAME", DbType = System.Data.DbType.String, Value = SURNAME });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@NAME", DbType = System.Data.DbType.String, Value = NAME });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@STIPEND", DbType = System.Data.DbType.Int32, Value = STIPEND });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@KURS", DbType = System.Data.DbType.Int32, Value = KURS });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@CITY", DbType = System.Data.DbType.String, Value = CITY });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@BIRTHDAY", DbType = System.Data.DbType.DateTime, Value = BIRTHDAY });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@UNIV_ID", DbType = System.Data.DbType.Int32, Value = UNIV_ID });
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            con.Close();
            return list;
        }
        //метод для получения всей информации из таблицы STUDENT
        public List<STUDENT> GetStudents()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from STUDENT", con);
            cmd.CommandType = CommandType.Text;
            List<STUDENT> students = new List<STUDENT>();
            try
            {
               con.Open();
               SqlDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                  STUDENT s = new STUDENT();
                  s.STUDENT_ID = (int)reader["sTUDENT_ID"];
                  s.SURNAME = (string)reader["sURNAME"];
                  s.NAME = (string)reader["nAME"];
                  s.STIPEND = (int)reader["sTIPEND"];
                  s.KURS = (int)reader["kURS"];
                  if (reader["cITY"] != DBNull.Value)
                  {
                      s.CITY = (string)reader["cITY"];
                  }
                  s.UNIV_ID = (int)reader["uNIV_ID"];
                  if (reader["bIRTHDAY"] != DBNull.Value)
                  {
                      s.BIRTHDAY = (System.DateTime)reader["bIRTHDAY"];
                  }
                  students.Add(s);
              }
              reader.Close();
              return students;
            }
            catch (SqlException n)
            {
                throw new ApplicationException("Ошибка данных" + n.Message);
            }
            finally
            {
                con.Close();
            }
        }
        //метод для получения ID студента из таблицы STUDENT
        public bool GetID(int ID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select STUDENT_ID from STUDENT", con);
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                bool ok = false;
                while (reader.Read() && !ok)
                {
                    ok = (int)reader["STUDENT_ID"] == ID;

                }
                return ok;
            }
            catch (SqlException n)
            {
                throw new ApplicationException("Ошибка данных" + n.Message);
            }
            finally
            {
                con.Close();
            }
        }
        //метод для получения всей информации из таблицы UNIVERSITY
        public List<Univercity> GetUniver()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * from UNIVERSITY", con);
            cmd.CommandType = CommandType.Text;
            List<Univercity> univercities = new List<Univercity>();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Univercity u = new Univercity();
                    u.UNIV_ID = (int)reader["UNIV_ID"];
                    u.UNIV_NAME = (string)reader["UNIV_NAME"];
                    u.RATING = (int)reader["RATING"];
                    u.CITY = (string)reader["CITY"];
                    univercities.Add(u);
                }
                reader.Close();
                return univercities;
            }
            catch (SqlException n)
            {
                throw new ApplicationException("Ошибка данных" + n.Message);
            }
            finally
            {
                con.Close();
            }
        }
        //метод для обновления информации в таблице
        public List<STUDENT> GetStudentsListUniver()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select s.STUDENT_ID, s.SURNAME, s.NAME, s.STIPEND, s.KURS, s.CITY, s.BIRTHDAY, u.UNIV_NAME from STUDENT s JOIN UNIVERSITY u ON s.UNIV_ID = u.UNIV_ID", con);
            cmd.CommandType = CommandType.Text;
            List<STUDENT> students = new List<STUDENT>();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    STUDENT s = new STUDENT();
                    s.STUDENT_ID = (int)reader["sTUDENT_ID"];
                    s.SURNAME = (string)reader["sURNAME"];
                    s.NAME = (string)reader["nAME"];
                    s.STIPEND = (int)reader["sTIPEND"];
                    s.KURS = (int)reader["kURS"];
                    if (reader["cITY"] != DBNull.Value)
                    {
                        s.CITY = (string)reader["cITY"];
                    }
                    s.UNIV_NAME = (string)reader["uNIV_NAME"];
                    if (reader["bIRTHDAY"] != DBNull.Value)
                    {
                        s.BIRTHDAY = (System.DateTime)reader["bIRTHDAY"];
                    }
                    students.Add(s);
                }
                reader.Close();
                return students;
            }
            catch (SqlException n)
            {
                throw new ApplicationException("Ошибка данных" + n.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}
