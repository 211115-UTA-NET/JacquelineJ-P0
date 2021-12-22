﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP0
{
    public class OrderController
    {
        public void add()
        {

            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            string sqlQuery;

            StringBuilder stringbuilderObject = new StringBuilder();
            stringbuilderObject.Append("INSERT INTO Orders (OrderID,CustomerId,ProductID,Quantity) VALUES");
            stringbuilderObject.Append("(5006, 1104, 4, 7),");
            stringbuilderObject.Append("(5006, 1104, 7, 2)");
            sqlQuery = stringbuilderObject.ToString();

            Console.WriteLine("Insert Orders query : "+sqlQuery);
            objDB.Insert(sqlQuery, connectionObj);
            Console.WriteLine("Insert Complete...");

            /*
            Console.WriteLine("Enter Number of products : ");
            int numberOfProducts = Convert.ToInt32(Console.ReadLine());
            if (numberOfProducts > 1)
            {
                stringbuilderObject.Append("INSERT INTO Orders (OrderID,CustomerId,ProductID,Quantity) VALUES");
                //stringbuilderObject.Append("(1106, 6, 6, 7");
                //stringbuilderObject.Append("(1106, 6, 5, 2");
                stringbuilderObject.Append("(orderId,");
                Console.WriteLine("Enter CustomerId");
                stringbuilderObject.Append(Console.ReadLine());
                Console.WriteLine("Enter ProductID");
                stringbuilderObject.Append(Console.ReadLine());
                Console.WriteLine("Enter Product Quantity : ");
                stringbuilderObject.Append(Console.ReadLine());
                sqlQuery = stringbuilderObject.ToString();
                Console.WriteLine("Inserting into Order table: "+sqlQuery);
                objDB.Insert(sqlQuery, connectionObj);
                Console.WriteLine("Insert Complete...");
            }
            else {
                stringbuilderObject.Append("INSERT INTO Orders (OrderID,CustomerId,ProductID,Quantity) VALUES");
                stringbuilderObject.Append("(orderId,");
                Console.WriteLine("Enter CustomerId");
                stringbuilderObject.Append(Console.ReadLine());
                Console.WriteLine("Enter ProductID");
                stringbuilderObject.Append(Console.ReadLine());
                Console.WriteLine("Enter Product Quantity : ");
                stringbuilderObject.Append(Console.ReadLine());
                sqlQuery = stringbuilderObject.ToString();
                Console.WriteLine("Inserting into Order table: "+sqlQuery);
                objDB.Insert(sqlQuery, connectionObj);
                Console.WriteLine("Insert Complete...");
            }
            */
            //conn.Close();
        }
        public void getOrders(string orderId)
        {
            SqlConnectionApp objDB = new SqlConnectionApp();
            SqlConnection connectionObj = objDB.DBConnection();
            List<Orders> orderList = new List<Orders>();

            string orderSelectQuery = "Select * from Orders";

            StringBuilder stringBuilderObj = new StringBuilder();
            stringBuilderObj.Append(orderSelectQuery);
            if (orderId != null && orderId.Length > 0)
            {
                int id = Convert.ToInt32(orderId);
                stringBuilderObj.Append(" Where orderid = " + orderId);
            }
            string query = stringBuilderObj.ToString();

            Console.WriteLine("OrderController : results : Fetching from Order table : " + query);
            try
            {
                SqlDataReader reader = objDB.FetchProducts(query, connectionObj);
                Orders orderObj = null;

                using (reader)
                {
                    while (reader.Read())
                    {
                        orderObj = new Orders();
                        orderObj.OrderID = reader.GetInt32(0);
                        orderObj.CustomerId = reader.GetInt32(1);
                        orderObj.ProductId = reader.GetInt32(2);
                        orderObj.Quantity = reader.GetInt32(3);
                        orderObj.OrderTime = reader.GetDateTime(4);
                        orderList.Add(orderObj);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Query Not Executed : " + ex.Message);
            }
            finally { connectionObj.Close(); }
            foreach (Orders item in orderList)
            {
                Console.WriteLine("Order-Id: " + item.OrderID + "  Customer-Id: " + item.CustomerId + " Product-Id: " + item.ProductId + " Quantity :  " +item.Quantity);

            }
            Console.WriteLine("Fetch Complete...");

        }
    }
}
