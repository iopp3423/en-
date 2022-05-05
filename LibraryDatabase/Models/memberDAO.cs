﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net;

namespace LibruryDatabase.Models
{
    internal class memberDAO
    {
        private MySqlConnection conn;

        public MySqlConnection connection()
        {
            conn = Connection.getConnection();
            return conn;
        }

        public bool Login(string id, string password) // 관리자 아이디 로그인
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(Constants.AdminSearchQuery, conn);
            MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

            while (userData.Read())
            {
                if (userData["id"].ToString() == id && userData["pw"].ToString() == password)
                {
                    conn.Close();
                    return Constants.isSucess;
                }
            }
            conn.Close();

            return Constants.isFail;
        }

        public void StoreUserInformation(string id, string pw, string name, string phone, string age, string address) // db 회원가입 정보 저장
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.insertUserQuery, id, pw, name, phone, age, address), conn);
            Command.ExecuteNonQuery();
            conn.Close();
        }

        public bool IsCheckingLogin(string id, string password) // db에 회원존재하면 true, 없으면 fail
        {

            conn.Open();
            MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, conn);
            MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

            while (userData.Read())
            {
                if (userData["id"].ToString() == id && userData["pw"].ToString() == password)
                {
                    conn.Close();
                    return Constants.isSucess;
                }
            }

            conn.Close();
            return Constants.isFail;
        }

        public bool IsCheckingIdOverlap(string id) // db에서 중복아이디 있으면 true, 없으면 false
        {


            conn.Open();
            MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, conn);
            MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

            while (userData.Read())
            {
                if (userData["id"].ToString() == id)
                {
                    conn.Close();
                    return Constants.isSucess;
                }
            }
            conn.Close();
            return Constants.isFail;
        }



    }
}
