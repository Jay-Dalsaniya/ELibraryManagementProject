﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagement
{

    public partial class userlogin : System.Web.UI.Page
    {

            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            protected void Page_Load(object sender, EventArgs e)
            {

            }

            // user login
            protected void Button1_Click(object sender, EventArgs e)
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    SqlCommand cmd = new SqlCommand("select * from member_master_tb1 where member_id='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Response.Write("<script>alert('" + dr.GetValue(8).ToString() + "');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid credentials');</script>");
                    }

                }
                catch (Exception ex)
                {

                }
            }
        }
    }
